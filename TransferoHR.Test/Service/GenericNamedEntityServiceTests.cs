using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TransferoHR.Domain.Entities.Generic;
using TransferoHR.Domain.Enums;
using TransferoHR.Infra.Database;
using TransferoHR.Infra.Repositories.Generic;
using TransferoHR.Services.Exceptions;
using TransferoHR.Services.Implementation;
using TransferoHR.Services.Interfaces.Generic;
using TransferoHR.Services.Model.Generic;
using TransferoHR.Services.Params.Generic;

#region Context
public class GenericNamedEntityServiceTests
{
    private readonly IMapper _mapper;
    private readonly IGenericNamedEntityRepository<GenericNamedEntity, NamedParams> _repo;
    private readonly GenericNamedService<GenericNamedEntity, NamedParams, NamedGetModel> _genericNamedService;

    public GenericNamedEntityServiceTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile());
        });
        _mapper = config.CreateMapper();

        var options = new DbContextOptionsBuilder<HRContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        var context = new HRContext(options);

        _repo = new GenericNamedEntityRepository<GenericNamedEntity, NamedParams>(context);
        _genericNamedService = new GenericNamedService<GenericNamedEntity, NamedParams, NamedGetModel>(_mapper, _repo, "GenericNamed");
    }

    private NamedCreateModel CreateModel
        (
        string name = "Margleison"
        )
    {
        return new NamedCreateModel
        {
            Name = name
        };
    }
    #endregion


    [Fact]
    public async Task Insert_ShouldThrowException_WhenNameIsDuplicated()
    {
        // Arrange
        var createModel = CreateModel();
        await _genericNamedService.Insert(createModel, "admin");

        var duplicateModel = CreateModel(name: createModel.Name);

        // Act 
        var exception = await Assert.ThrowsAsync<ServiceException>(async () => await _genericNamedService.Insert(duplicateModel, "admin"));

        //Assert
        Assert.Contains($"GenericNamed name already exists. [Name=Margleison]", exception.Message);
    }

    [Fact]
    public async Task Insert_Ok()
    {
        // Arrange
        var createModel = CreateModel();
        var insertModel = await _genericNamedService.Insert(createModel, "admin");

        // Act
        var read = await _repo.GetAsync(insertModel.Id);

        // Assert
        Assert.NotNull(read);
        Assert.Equal(insertModel.Id, read.Id);
    }

    [Fact]
    public async Task Delete_ShouldThrowException_WhenNotExist()
    {
        // Arrange
        var nonexistentId = Guid.NewGuid();

        // Act 
        var exception = await Assert.ThrowsAsync<ServiceException>(async () => await _genericNamedService.Delete(nonexistentId, "admin"));

        //Assert
        Assert.Contains($"GenericNamed does not exist. [Id={nonexistentId}]", exception.Message);
    }

    [Fact]
    public async Task Delete_Ok()
    {
        // Arrange
        var createModel = CreateModel();
        var insertModel = await _genericNamedService.Insert(createModel, "admin");

        // Act
        await _genericNamedService.Delete(insertModel.Id, "admin");

        // Assert
        var deletedEntity = await _repo.GetAsync(insertModel.Id);
        Assert.Null(deletedEntity);
    }

    [Fact]
    public async Task Activete_ShouldThrowsException_WhenNameNotExist()
    {
        //Arrange
        var createModel = Guid.NewGuid();

        //Act
        var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _genericNamedService.Activate(createModel, "admin"); });

        //Assert
        Assert.Contains($"GenericNamed does not exist. [Id={createModel}]", exception.Message);
    }

    [Fact]
    public async Task Activate_ShouldThrowsException_WhenAlreadyActive()
    {
        //Arrange
        var createModel = CreateModel();
        var insertModel = await _genericNamedService.Insert(createModel, "Admin");

        //Act
        var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _genericNamedService.Activate(insertModel.Id, "Admin"); });

        //Assert
        Assert.Contains($"GenericNamed already active. [Id={insertModel.Id}]",exception.Message);
    }
    [Fact]
    public async Task Activate_Ok()
    {
        //Arrange
        var createModel = CreateModel();
        var insertModel = await _genericNamedService.Insert(createModel, "Admin");
        await _genericNamedService.Deactivate(insertModel.Id, "Admin");

        //Act
        await _genericNamedService.Activate(insertModel.Id,"Admin");
        var read = await _repo.GetAsync(insertModel.Id);
        
       
        //Assert
        Assert.NotNull(insertModel);
        Assert.Equal(read.Id, insertModel.Id);
    }

    [Fact]
    public async Task Deactivate_ShowlThrowsException_WhenNotExist()
    {
        //Arrange
        var createModel = Guid.NewGuid();

        //Act
        var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _genericNamedService.Deactivate(createModel, "Admin"); });

        //Assert
        Assert.Contains($"GenericNamed does not exist. [Id={createModel}]",exception.Message);
    }

    [Fact]
    public async Task Deactivate_ShouldThrowsException_WhenAlreadyDeactive()
    {
        //Arrange
        var createModel = CreateModel();
        var insertModel = await _genericNamedService.Insert(createModel, "Admin");
        insertModel.Status = EntityStatusEnum.Inactive;
        await _repo.ChangeStatusAsync(insertModel);

        //Act
        var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _genericNamedService.Deactivate(insertModel.Id, "Admin"); });

        //Assert
        Assert.Contains($"GenericNamed already deactive. [Id={insertModel.Id}]", exception.Message);
    }

    [Fact]
    public async Task Deactivate_Ok()
    {
        //Arrange
        var createModel = CreateModel();
        var inserModel = await _genericNamedService.Insert(createModel, "Admin");
        await _genericNamedService.Deactivate(inserModel.Id, "Admin");
        
        //Act
        var read = await _repo.GetAsync(inserModel.Id);

        //Assert
        Assert.NotNull(inserModel);
        Assert.Equal(read.Id, inserModel.Id);
    }
}
