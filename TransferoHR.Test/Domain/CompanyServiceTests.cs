using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using TransferoHR.Infra.Database;
using TransferoHR.Infra.Repositories;
using TransferoHR.Services.Exceptions;
using TransferoHR.Services.Implementation;
using TransferoHR.Services.Interfaces;
using TransferoHR.Services.Model;

public class CompanyServiceTests
{
    private readonly IMapper _mapper;
    private readonly ICompanyRepository _repo;
    private readonly CompanyService _companyService;

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
        var context = new HRContext(options);
        _repo = new CompanyRepository(context);


        _companyService = new CompanyService(_mapper, _repo);
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
}