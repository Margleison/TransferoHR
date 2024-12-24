using Microsoft.EntityFrameworkCore;
using AutoMapper;
using TransferoHR.Domain.Enums;
using TransferoHR.Services.Implementation;
using TransferoHR.Services.Model;
using TransferoHR.Services.Interfaces;
using TransferoHR.Infra.Repositories;
using TransferoHR.Services.Exceptions;
using TransferoHR.Infra.Database;
using System.Data.Entity;

namespace TransferoHR.Test.Service
{
    public class CollaboratorServiceTests
    {
        private readonly IMapper _mapper;
        private readonly ICollaboratorRepository _repo;
        private readonly CollaboratorService _collaboratorService;
        private readonly HRContext _context;
        public CollaboratorServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile()); // Supondo que você tenha um perfil de mapeamento configurado.
            });
            _mapper = config.CreateMapper();

            // Configuração do In-Memory Database
            var options = new DbContextOptionsBuilder<HRContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            // Inicializa o repositório
            _context = new HRContext(options);
            _repo = new CollaboratorRepository(_context); // Supondo que você tenha um repositório para Collaborator

            // Inicializa o serviço com o repositório e o mapper
            _collaboratorService = new CollaboratorService(_mapper, _repo);
        }
        public void Dispose()
        {
            // Limpeza do banco em memória após os testes
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        private CollaboratorCreateModel CreateModel(
            string cpf = "06590176795",
            string name = "John DOE",
            string rg = "35.216.967-5",
            string email = "JohnDoe@gmail.com",
            string workEmail = "Margleison@transfero.com",
            string country = "Brasil",
            GenderEnum gender = GenderEnum.Man,
            NationalityEnum nationality = NationalityEnum.Brazilian,
            string city = "Nova Iguaçy",
            DateOnly? birthDate = null,
            string state = "RJ",
            string postalCode = "26291-221",
            string phoneNumber = "(21) 98116-5068",
            string bankBranch = "001",
            string bankName = "Nubank",
            string bankAccount = "001",
            string pixKey = "06590176795",
            string address = "Rua joaquim da silva maia quadra d")

        {
            return new CollaboratorCreateModel
            {
                CPF = cpf,
                Name = name,
                RG = rg,
                Email = email,
                WorkEmail = workEmail,
                Country = country,
                Gender = GenderEnum.Man,
                Nationality = NationalityEnum.Brazilian,
                City = city,
                BirthDate = birthDate ?? new DateOnly(2023, 1, 1),
                State = state,
                PostalCode = postalCode,
                PhoneNumber = phoneNumber,
                BankBranch = bankBranch,
                BankName = bankName,
                BankAccount = bankAccount,
                PixKey = pixKey,
                Address = address,

            };
        }


        #region Insert
        [Fact]
        public async Task Insert_ShouldThrowException_WhenCpfIsDuplicated()
        {
            // Arrange
            var createModelToPrepare = CreateModel();
            await _collaboratorService.Insert(createModelToPrepare, "admin");

            var newName = createModelToPrepare.Name + "";
            var createModeltoTest = CreateModel(name: newName);


            // Act
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => await _collaboratorService.Insert(createModeltoTest, "admin"));


            // Assert
            Assert.Contains($"Collaborator CPF already exists. [Value={createModeltoTest.CPF}]", exception.Message);
        }
        [Fact]
        public async Task Insert_ShouldThrowException_WhenRGIsDuplicated()
        {
            // Arrange
            var createModelToPrepare = CreateModel();
            await _collaboratorService.Insert(createModelToPrepare, "admin");
            var newName = createModelToPrepare.Name + "xxxxxxxx";
            var newCpf = "06590176795";
            var createModeltoTest = CreateModel(name: newName, cpf: newCpf);


            // Act
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => await _collaboratorService.Insert(createModeltoTest, "admin"));


            // Assert
            Assert.Contains($"Collaborator RG already exists. [Value={createModeltoTest.RG}]", exception.Message);
        }

        [Fact]
        public async Task Insert_ShouldThrowException_WhenEmailIsDuplicated()
        {
            // Arrange -> Cria um collaborador InMemory
            var createModelToPrepare = CreateModel();
            await _collaboratorService.Insert(createModelToPrepare, "admin");

            // Cria um segundo collaborator com nome diferente e email igual assim validando se os emails estão duplicados
            var newName = createModelToPrepare.Name + "xxxxxxx";
            var newCpf = "56718578720";
            var newRG = "35.216.357-9";
            var newEmail = "JohnDOE@gmail.com";
            var createModeltoTest = CreateModel(name: newName, rg: newRG, cpf: newCpf, email: newEmail);


            // Act-> executa o que eu quero criar com o meu CreateModelToTest
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => await _collaboratorService.Insert(createModeltoTest, "admin"));


            // Assert -> Verifica/Testa se
            Assert.Contains($"Collaborator Email already exists. [Value={createModeltoTest.Email}]", exception.Message);
        }

        [Fact]
        public async Task Insert_Ok()
        {
            // Arrange
            var createModel = CreateModel();

            // Act
            var collaborator = await _collaboratorService.Insert(createModel, "admin");

            // Assert
            Assert.NotNull(collaborator);
            Assert.True(collaborator.CPF == createModel.CPF, "CPFs are different");
            Assert.True(collaborator.RG == createModel.RG, "RGs are different");
            Assert.True(collaborator.Email == createModel.Email, "Emails are different");
            Assert.True(collaborator.WorkEmail == createModel.WorkEmail, "WorkEmails are different");
            Assert.True(collaborator.Country == createModel.Country, "Countrys are different");
            Assert.True(collaborator.City == createModel.City, "Citys are different");
            Assert.True(collaborator.PostalCode == createModel.PostalCode, "PostalCodes are different");
            Assert.True(collaborator.PhoneNumber == createModel.PhoneNumber, "PhoneNumbers are different");
            Assert.True(collaborator.BankBranch == createModel.BankBranch, "BankBranchs are different");
            Assert.True(collaborator.BankName == createModel.BankName, "BankNames are different");
            Assert.True(collaborator.BankAccount == createModel.BankAccount, "AccountNames are different");
            Assert.True(collaborator.Pixkey == createModel.PixKey, "PixKeys are different");
            Assert.True(collaborator.Address == createModel.Address, "Address are different");
            Assert.True(collaborator.State == createModel.State, "States are different");
        }
        #endregion

        #region Update
        [Fact]
        public async Task Update_ShouldThrowException_WhenUpdateCPFToRepeated()
        {
            //Arrange -> preparo
            var createModel = CreateModel(rg: "35.216.967.8", phoneNumber: "21981165068", email: "margleison.silva@gmail.com", workEmail: "margleison.silva@transfero.com", bankBranch: "001", bankName: "Nubank", bankAccount: "001005655145", state: "RJ", postalCode: "26291-221", city: "Nova Iguaçu", address: "rua joaquim da silva maia quadra d lote 20");
            var initialCollaborator = await _collaboratorService.Insert(createModel, "admin");

            var newName = createModel.Name = "Sejo Wellitu";
            var newCpf = "06590176795";
            var toUpdate = await _collaboratorService.Insert(CreateModel(name: newName, cpf: newCpf), "admin");

            var idToUpdate = toUpdate.Id;


            // Act -> Executa
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => await _collaboratorService.Update(idToUpdate, toUpdate, "admin"));

            // Assert -> 
            Assert.Contains($"Collaborator CPF already exists. [Value={toUpdate.CPF}]", exception.Message);
        }

        [Fact]
        public async Task Update_ShouldThrowException_WhenUpdateEmailToRepeated()
        {
            //Arreng -> Criando collaborator
            var createModel = CreateModel();
            var initialCollaborator = await _collaboratorService.Insert(createModel, "admin");

            //Criando novo collaborator Collaborator
            var newName = createModel.Name = "Pedro Rodrigues";
            var newCpf = "06590176795";
            var NewRG = "35.216.485";
            var toUpdate = await _collaboratorService.Insert(CreateModel(name: newName, cpf: newCpf, rg: NewRG), "admin");

            var idToUpdate = toUpdate.Id;


            var exception = await Assert.ThrowsAsync<ServiceException>(async () => await _collaboratorService.Update(idToUpdate, toUpdate, "admin"));


            Assert.Contains($"Collaborator CPF already exists. [Value={toUpdate.CPF}]", exception.Message);
        }
        #endregion


        [Fact]
        public async Task Delete_ShouldThrowsException_WhenCollaboratorNotExists()
        {
            //Arrenge
            var idNotExist = Guid.NewGuid();

            //Act
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _collaboratorService.Delete(idNotExist, "admin"); });

            //Assert
            Assert.Contains($"Collaborator does not exist. [Id={idNotExist}]", exception.Message);
        }

        [Fact]
        public async Task Delete_ShouldThrowException_Collaborator_AlreadyDeleted()
        { // Arrange
            var createModel = CreateModel();
            var collaborator = await _collaboratorService.Insert(createModel, "admin");
            await _collaboratorService.Delete(collaborator.Id, "admin");


            //Act
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => await _collaboratorService.Delete(collaborator.Id, "admin"));

            // Assert
            Assert.Contains($"Collaborator does not exist. [Id={collaborator.Id}]", exception.Message);
        }

        [Fact]
        public async Task Delete_Ok()
        {
            //Arrenge
            var collaboratorCreateModel = CreateModel();
            var collaboratorInsert = await _collaboratorService.Insert(collaboratorCreateModel, "admin");

            //Act
            await _collaboratorService.Delete(collaboratorInsert.Id, "admin");
            var readDelete = await _repo.GetAsync(collaboratorInsert.Id);

            //Assert
            Assert.Null(readDelete);
        }
        [Fact]
        public async Task Activate_ShouldThrowException_WhenActivateIsNotExists()
        {
            //Arrange
            var activateId = Guid.NewGuid();

            //Act
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _collaboratorService.Activate(activateId, "Admin"); });

            //Assert
            Assert.Contains($"Collaborator does not exist. [Id={activateId}]", exception.Message);
        }

        [Fact]
        public async Task Activate_ShouldThrowsException_WhenAlreadyActivate()
        {
            //Arrange
            var activeCreateModel = CreateModel();
            var insertActivate = await _collaboratorService.Insert(activeCreateModel, "Admin");

            var readDeactivate = await _repo.GetAsync(insertActivate.Id);

            //Act
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _collaboratorService.Activate(insertActivate.Id, "Admin"); });

            //Assert
            Assert.Contains($"Collaborator already active. [Id={insertActivate.Id}]", exception.Message);
        }

        [Fact]
        public async Task Activate_Ok()
        {
            //Arrange
            var deactiveCreateModel = CreateModel();
            var insertDeactivate = await _collaboratorService.Insert(deactiveCreateModel, "Admin");
            await _collaboratorService.Deactivate(insertDeactivate.Id, "Admin");

            var readDeactivate = await _repo.GetAsync(insertDeactivate.Id);

            //Act
            await _collaboratorService.Activate(insertDeactivate.Id, "Admin");

            //Assert
            var readActivate = await _repo.GetAsync(insertDeactivate.Id);
            Assert.Equal(readActivate.Id, readDeactivate.Id);
        }

        [Fact]
        public async Task Deactivate_ShoulThrowException_WhenNotExists()
        {
            //Arrange
            var deactiveId = Guid.NewGuid();

            //Act
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _collaboratorService.Deactivate(deactiveId, "admin"); });

            //Assert
            Assert.Contains($"Collaborator does not exist. [Id={deactiveId}]", exception.Message);
        }

        [Fact]
        public async Task Deactivate_ShoulThrowsException_WhenAlreadyDeactivate()
        {
            //Arrange
            var createModel = CreateModel();
            var insertModel = await _collaboratorService.Insert(createModel, "Admin");
            insertModel.Status = EntityStatusEnum.Inactive;
            await _repo.ChangeStatusAsync(insertModel);

            //Act
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _collaboratorService.Deactivate(insertModel.Id, "Admin"); });

            //Assert
            Assert.Contains($"Collaborator already deactive. [Id={insertModel.Id}]", exception.Message);
        }

        [Fact]
        public async Task Deactivate_Ok()
        {   //Arrange
            var deactiveCreateModel = CreateModel();
            var collaboratorCreateModel = await _collaboratorService.Insert(deactiveCreateModel, "admin");

            //Act
            await _collaboratorService.Deactivate(collaboratorCreateModel.Id, "Admin");


            //Assert
            var readDeactivate = await _repo.GetAsync(collaboratorCreateModel.Id);
            Assert.Equal(readDeactivate.Id, collaboratorCreateModel.Id);
        }
    }
}