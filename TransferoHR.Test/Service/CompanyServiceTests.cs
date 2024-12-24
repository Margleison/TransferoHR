using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Runtime.ConstrainedExecution;
using TransferoHR.Domain.Enums;
using TransferoHR.Infra.Database;
using TransferoHR.Infra.Repositories;
using TransferoHR.Services.Exceptions;
using TransferoHR.Services.Implementation;
using TransferoHR.Services.Interfaces;
using TransferoHR.Services.Model;
using TransferoHR.Services.Model.Generic;

public class CompanyServiceTests
{
    private readonly IMapper _mapper;
    private readonly ICompanyRepository _repo;
    private readonly CompanyService _companyService;
    private readonly HRContext _context;
    public CompanyServiceTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile());
        });
        _mapper = config.CreateMapper();

        var options = new DbContextOptionsBuilder<HRContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        // Inicializa o repositório
        _context = new HRContext(options);
        _repo = new CompanyRepository(_context);


        _companyService = new CompanyService(_mapper, _repo);
    }
    public void Dispose()
    {
        // Limpeza do banco em memória após os testes
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    private CompanyCreateModel CreateModel(
        string name = "HR",
        string cnpj = "32.657.259/0001-04"
        )
    {
        return new CompanyCreateModel
        {
            Name = name,
            CNPJ = cnpj
        };
    }

    private CompanyUpdateModel UpdateModel(
        string name = "TransferoRH",
        string cnpj = "32.657.259/0001-04")
    {
        return new CompanyUpdateModel
        {
            Name = name,
            CNPJ = cnpj
        };
    }

    [Fact]
    public async Task Insert_ShouldThrowException_WhenCNPJIsDuplicate()
    {
        var create = CreateModel();
        await _companyService.Insert(create, "Admin");

        var NewName = create.Name + "_Transfero";
        var createModel = CreateModel(name: NewName);

        var exception = await Assert.ThrowsAsync<ServiceException>(async () => await _companyService.Insert(createModel, "admin"));
        Assert.Contains($"Company CNPJ already exists. [Value={createModel.CNPJ}]", exception.Message);
    }


    [Fact]
    public async Task Insert_Ok()
    {
        // Arrange
        var createModel = CreateModel();

        // Act
        var collaborator = await _companyService.Insert(createModel, "admin");

        // Assert
        Assert.NotNull(collaborator);
        Assert.True(collaborator.CNPJ == createModel.CNPJ, "CNPJs are different");
    }

    [Fact]
    public async Task Update_ShouldThrowsException_WhenNotExists()
    {
        //Arrenge
        var createModel = Guid.NewGuid();
        var updateCompany = UpdateModel();

        //Act
        var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _companyService.Update(createModel, updateCompany, "Admin"); });

        //Assert
        Assert.Contains("Company does not exist", exception.Message);
    }


    [Fact]
    public async Task Update_ShouldThrowException_WhenCNPJWillBeDuplicated()
    {
        var create = CreateModel();
        await _companyService.Insert(create, "Admin");

        var create2 = CreateModel(cnpj: "11.480.809/0001-84", name: create.Name + "zz");
        var toUpdate = await _companyService.Insert(create2, "Admin");


        var updateCompany = UpdateModel(cnpj: create.CNPJ);

        var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _companyService.Update(toUpdate.Id, updateCompany, "Admin"); });
        Assert.Contains($"Company CNPJ already exists. [Value={toUpdate.CNPJ}]", exception.Message);
    }

    [Fact]
    public async Task Update_Ok()
    {
        //Arrenge
        var create = CreateModel();
        var createCompany = await _companyService.Insert(create, "Admin");

        var NewName = create.Name + "Transfero";
        var updateModel = UpdateModel(name: NewName);

        //Act
        await _companyService.Update(createCompany.Id, updateModel, updateBy: "admin");

        //Assert
        var read = await _repo.GetAsync(createCompany.Id);
        Assert.Equal(read.Id, createCompany.Id);
    }

    [Fact]
    public async Task Delete_ShouldThrowsException_WhenNotExists()
    {
        //Arrenge
        var create = Guid.NewGuid();

        //Act
        var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _companyService.Delete(create, "Admin"); });

        //Assert
        Assert.Contains("Company does not exist.", exception.Message);
    }

    [Fact]
    public async Task Delete_Ok()
    {
        //Arrenge
        var create = CreateModel();
        var insertCompany = await _companyService.Insert(create, "Admin");

        //Act
        await _companyService.Delete(insertCompany.Id, "Admin");

        //Assert
        var readDelete = await _repo.GetAsync(insertCompany.Id);
        Assert.Null(readDelete);
    }

    [Fact]
    public async Task Activate_ShouldThrowsException_WhenAlreadyActivate()
    {
        //Arrenge
        var create = CreateModel();
        var insertCompany = await _companyService.Insert(create, "Admin");

        var read = await _repo.GetAsync(insertCompany.Id);


        //Act
        var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _companyService.Activate(insertCompany.Id, "Admin"); });

        //Assert
        Assert.Contains($"Company already active. [Id={insertCompany.Id}]", exception.Message);
    }

    [Fact]
    public async Task Activate_Ok()
    {//Arrenge
        var create = CreateModel();
        var insertCompany = await _companyService.Insert(create, "Admin");
        insertCompany.Status = EntityStatusEnum.Inactive;
        await _repo.ChangeStatusAsync(insertCompany);

        //Act
        await _companyService.Activate(insertCompany.Id, "Admin");
        var read = await _repo.GetAsync(insertCompany.Id);

        //Assert
        Assert.NotNull(read);
        Assert.Equal(read.Id, insertCompany.Id);
        Assert.Equal(read.Status, EntityStatusEnum.Active);
    }

    [Fact]
    public async Task Deactivate_ShouldThrowsException_WhenNotExist()
    {
        //Arrange
        var create = Guid.NewGuid();

        //Act
        var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _companyService.Deactivate(create, "Admin"); });

        //Assert
        Assert.Contains($"Company does not exist. [Id={create}]", exception.Message);
    }
    [Fact]
    public async Task Deactivate_ShouldThrowsException_WhenAlreadyDeactivate()
    {
        //Arrange
        var createModel = CreateModel();
        var insertModel = await _companyService.Insert(createModel, "Admin");
        insertModel.Status = EntityStatusEnum.Inactive;
        await _repo.ChangeStatusAsync(insertModel);

        //Act
        var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _companyService.Deactivate(insertModel.Id, "Admin"); });
      
        //Assert
        Assert.Contains($"Company already deactive. [Id={insertModel.Id}]", exception.Message);

    }

    [Fact]
    public async Task Deactivate_Ok()
    {
        //Arrange
        var create = CreateModel();
        var insertModel = await _companyService.Insert(create, "Admin");
        insertModel.Status = EntityStatusEnum.Inactive;

        //Act
        await _repo.ChangeStatusAsync(insertModel);
        var read = await _repo.GetAsync(insertModel.Id);

        //Assert
        Assert.NotNull(read);
        Assert.Equal(read.Id, insertModel.Id);
        Assert.Equal(read.Status, EntityStatusEnum.Inactive);
    }
}