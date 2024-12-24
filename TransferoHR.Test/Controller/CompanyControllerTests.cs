using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransferoHR.Domain.Entities;
using TransferoHR.Domain.Enums;
using TransferoHR.Infra.Database;
using TransferoHR.Infra.Repositories;
using TransferoHR.Services.Implementation;
using TransferoHR.Services.Interfaces;
using TransferoHR.Services.Model;
using TransferoHR.Services.Params;
using TransferoHR.Services.Params.Generic;
using TransferoHR.WebApi.Controllers;

public class CompanyControllerTests
{
    private readonly IMapper _mapper;
    private readonly ICompanyRepository _repo;
    private readonly CompanyController _companyController;
    private readonly CompanyService _companyService;
    private readonly HRContext _context;
    public CompanyControllerTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile());
        });
        _mapper = config.CreateMapper();

        var options = new DbContextOptionsBuilder<HRContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        _context = new HRContext(options);

        _repo = new CompanyRepository(_context);

        _companyService = new CompanyService(_mapper, _repo);

        _companyController = new CompanyController(_companyService, _mapper);
    }
    public void Dispose()
    {
        // Limpeza do banco em memória após os testes
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    private CompanyCreateModel CreateModel(
        string name = "Company Test",
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
        string name = "Company Test",
        string cnpj = "32.657.259/0001-04"
        )
    {
        return new CompanyUpdateModel
        {
            Name = name,
            CNPJ = cnpj
        };
    }

    [Fact]
    public async Task GetById_Ok()
    {
        // Arrange
        var companyCreate = CreateModel();

        // Criação da empresa usando o método da controller
        var insertCompany = await _companyController.Create(companyCreate);
        var createdResult = Assert.IsType<CreatedAtActionResult>(insertCompany);
        var createdCompany = Assert.IsType<CompanyGetModel>(createdResult.Value);

        // Act
        var result = await _companyController.GetById(createdCompany.Id);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var company = Assert.IsType<CompanyGetModel>(okResult.Value);
        Assert.Equal("Company Test", company.Name);
    }

    [Fact]
    public async Task GetAll_Ok()
    {
        // Arrange
        var companyCreate = CreateModel();
        var insertCompany = await _companyController.Create(companyCreate);
        var createdResult = Assert.IsType<CreatedAtActionResult>(insertCompany);
        var createdCompany = Assert.IsType<CompanyGetModel>(createdResult.Value);

        var companyParams = new CompanyParams();

        // Act
        var result = await _companyController.GetAll(companyParams);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var companies = Assert.IsType<List<CompanyGetModel>>(okResult.Value);
        Assert.Contains(companies, c => c.Id == createdCompany.Id && c.Name == "Company Test");
    }

    [Fact]
    public async Task Create_Ok()
    {
        //Arrange
        var companyCreate = CreateModel(name: "TransferoHR", cnpj: "30.934.964/0001-78");

        var insertCompany = await _companyController.Create(companyCreate);
        var createdResult = Assert.IsType<CreatedAtActionResult>(insertCompany);
        var createdCompany = Assert.IsType<CompanyGetModel>(createdResult.Value);

        // Act
        var result = await _companyController.GetById(createdCompany.Id);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var company = Assert.IsType<CompanyGetModel>(okResult.Value);
        Assert.Equal("TransferoHR", company.Name);
    }

    [Fact]
    public async Task Update_Ok()
    {
        //Arrange
        var companyCreate = CreateModel();

        var insertCompany = await _companyController.Create(companyCreate);
        var createdResult = Assert.IsType<CreatedAtActionResult>(insertCompany);
        var createdCompany = Assert.IsType<CompanyGetModel>(createdResult.Value);

        var updateModel = UpdateModel(createdCompany.Name = "TransferoHR", createdCompany.CNPJ);

        //Act
        var companyUpdate = await _companyController.Update(createdCompany.Id, updateModel);

        //Assert
        Assert.IsType<NoContentResult>(companyUpdate);

        //AditionalValidates
        var getResult = await _companyController.GetById(createdCompany.Id);
        var okResult = Assert.IsType<OkObjectResult>(getResult);
        var updatedCompany = Assert.IsType<CompanyGetModel>(okResult.Value);
        Assert.Equal("TransferoHR", updatedCompany.Name);
    }

    [Fact]
    public async Task Delete_Ok()
    {
        //Arrange
        var companyCreate = CreateModel(name: "TransferoHR", cnpj: "30.934.964/0001-78");

        var insertCompany = await _companyController.Create(companyCreate);
        var createdResult = Assert.IsType<CreatedAtActionResult>(insertCompany);
        var createdCompany = Assert.IsType<CompanyGetModel>(createdResult.Value);

        var result = await _companyController.GetById(createdCompany.Id);
        // Act

        var deleteCompany = await _companyController.Delete(createdCompany.Id);

        //Assert
        Assert.IsType<NoContentResult>(deleteCompany);
    }

    [Fact]
    public async Task Activate_Ok()
    {
        //Arrange
        var companyCreate = CreateModel(name: "TransferoHR", cnpj: "30.934.964/0001-78");


        var insertCompany = await _companyController.Create(companyCreate);
        var createdResult = Assert.IsType<CreatedAtActionResult>(insertCompany);
        var createdCompany = Assert.IsType<CompanyGetModel>(createdResult.Value);

        // Desativa a empresa
        var deactivateCompany = await _companyController.Deactivate(createdCompany.Id);
        Assert.IsType<NoContentResult>(deactivateCompany);


        var deactivatedResult = await _companyController.GetById(createdCompany.Id);
        var deactivatedOkResult = Assert.IsType<OkObjectResult>(deactivatedResult); // Valida que a empresa foi desativada (a verificação dependerá da implementação)
        var deactivatedCompany = Assert.IsType<CompanyGetModel>(deactivatedOkResult.Value);

        //Act
        var activateCompany = await _companyController.Activate(createdCompany.Id);
        Assert.IsType<NoContentResult>(activateCompany); // Valida que a ativação foi executada


        var result = await _companyController.GetById(createdCompany.Id);
        var okResult = Assert.IsType<OkObjectResult>(result);
        var company = Assert.IsType<CompanyGetModel>(okResult.Value);

        // Assert
        Assert.Equal(createdCompany.Id, company.Id);
    }

    [Fact]
    public async Task Deactivate_Ok()
    {
        //Arrange
        var companyCreate = CreateModel(name: "TransferoHR", cnpj: "30.934.964/0001-78");


        var insertCompany = await _companyController.Create(companyCreate);
        var createdResult = Assert.IsType<CreatedAtActionResult>(insertCompany); //Cria a company
        var createdCompany = Assert.IsType<CompanyGetModel>(createdResult.Value);

        // Desativa a empresa
        var deactivateCompany = await _companyController.Deactivate(createdCompany.Id);//Desativa a company

        //Assert
        Assert.IsType<NoContentResult>(deactivateCompany);
    }
}