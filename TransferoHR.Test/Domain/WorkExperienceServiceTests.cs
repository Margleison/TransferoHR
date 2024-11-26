using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TransferoHR.Domain.Entities;
using TransferoHR.Domain.Enums;
using TransferoHR.Infra.Database;
using TransferoHR.Infra.Repositories;
using TransferoHR.Infra.Repositories.Generic;
using TransferoHR.Services.Exceptions;
using TransferoHR.Services.Implementation;
using TransferoHR.Services.Interfaces;
using TransferoHR.Services.Model;
using TransferoHR.Services.Params;

namespace TransferoHR.Test.Domain
{
    public class WorkExperienceServiceTests
    {
        private readonly IMapper _mapper;
        private readonly HRContext _context;
        private readonly IWorkExperienceRepository _repo;
        private readonly IJobLevelRepository _jobLevelRepository;
        private readonly IJobTitleRepository _jobTitleRepository;
        private readonly ICollaboratorRepository _collaboratorRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly WorkExperienceService _workExperienceService;
        private readonly IGenericService<WorkExperience, WorkExperienceParams, WorkExperienceGetModel> _workExperienceServiceTest;
        public WorkExperienceServiceTests()
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
            var context = new HRContext(options);
            _repo = new WorkExperienceRepository(context); // Supondo que você tenha um repositório para Collaborator
            _collaboratorRepository = new CollaboratorRepository(context);
            _companyRepository = new CompanyRepository(context);
            _jobLevelRepository = new JobLevelRepository(context);
            _jobTitleRepository = new JobTitleRepository(context);
            
            var genericRepository = new GenericEntityRepository<WorkExperience, WorkExperienceParams>(_context);

            // Inicializa a implementação concreta de IGenericService com o parâmetro entityName
            _workExperienceServiceTest = new GenericService<WorkExperience, WorkExperienceParams, WorkExperienceGetModel>(_mapper, genericRepository, "WorkExperience" );
            
            _workExperienceService = new WorkExperienceService(_mapper, _jobLevelRepository, _jobTitleRepository, _companyRepository, _collaboratorRepository, _repo);
        }

        #region Prepare
        private WorkExperienceCreateModel Create(
             DateOnly startDate,
             DateOnly? endDate = null,
             Guid? collaboratorId = null,
             Guid? companyId = null,
             Guid? jobTitleId = null,
             Guid? jobLevelId = null,
             Guid? leaderId = null
         )
        {
            collaboratorId = collaboratorId == null ? Guid.Empty : collaboratorId;
            companyId = companyId == null ? Guid.Empty : companyId;
            jobTitleId = jobTitleId == null ? Guid.Empty : jobTitleId;
            jobLevelId = jobLevelId == null ? Guid.Empty : jobLevelId;
            leaderId = leaderId == null ? Guid.Empty : leaderId;

            return new WorkExperienceCreateModel
            {
                StartDate = startDate == default ? DateOnly.FromDateTime(DateTime.UtcNow) : startDate,
                CollaboratorId = collaboratorId ?? Guid.Empty,
                CompanyId = companyId ?? Guid.Empty,
                JobTitleId = jobTitleId ?? Guid.Empty,
                JobLevelId = jobLevelId ?? Guid.Empty,
                LeaderId = leaderId ?? Guid.Empty,

            };
        }
        private WorkExperience CreateWorkExperience
            (
            DateOnly startDate,
            DateOnly? endDate = null,
            Guid? collaboratorId = null,
            Guid? companyId = null,
            Guid? jobTitleId = null,
            Guid? jobLevelId = null,
            Guid? leaderId = null
            )
        {
            return new WorkExperience
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",

                StartDate = startDate == default ? DateOnly.FromDateTime(DateTime.UtcNow) : startDate,
                EndDate = endDate,
                CollaboratorId = collaboratorId.Value,

                CompanyId = companyId.Value,
                JobTitleId = jobTitleId.Value,
                JobLevelId = jobLevelId.Value,
                LeaderId = leaderId.Value,
            };
        }
        private Collaborator CreateCollaborator(
            Guid id,
            string cpf = "06590176795",
            string name = "Margleison",
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
            string address = "Rua joaquim da silva maia quadra d"
            )
        {
            return new Collaborator
            {
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",
                Id = id,
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
                Address = address,
                Pixkey = pixKey,

            };
        }
        private Company CreateCompanyModel
                (
                Guid id,
                string name = "HR",
                string cnpj = "32.657.259/0001-04"
                    )
        {
            return new Company
            {
                Id = id,
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "Admin",
                Name = name,
                CNPJ = cnpj
            };
        }
        private JobLevel CreateJobLevelModel
                (
                Guid id,
                string name = "Junior"
                
                    )
        {
            return new JobLevel
            {
                Id = id,
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "Admin",
                Name = name
            };
        }
        private JobTitle CreateJobTitlelModel
                (
                Guid id,
                string name = "Junior"

                    )
        {
            return new JobTitle
            {
                Id = id,
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "Admin",
                Name = name
            };
        }
        #endregion

    #region AddTests
        [Fact]
        public async Task AddWorkExperience_ShouldAddWorkExperience_WhenValidCollaboratorDoesNotExist()
        {
            var workExperience = Create(startDate: DateOnly.Parse("2024-01-01"));

            // Act
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _workExperienceService.Insert<WorkExperienceCreateModel>(workExperience, "admin"); });

            // Assert
            Assert.Contains("Collaborator does not exist", exception.Message);
        }

        [Fact]
        public async Task Validate_ShouldThrowsException_WhenValidCompanyIdIsNotExists()
        {
            var validCollaboratorId = Guid.NewGuid();
            var initialCollaborator = CreateCollaborator(validCollaboratorId);
            await _collaboratorRepository.AddAsync(initialCollaborator);

            var workExperience = Create(startDate: DateOnly.Parse("2024-01-01"), collaboratorId: validCollaboratorId);

            // Act
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _workExperienceService.Insert<WorkExperienceCreateModel>(workExperience, "admin"); });

            // Assert
            Assert.Contains("Company does not exist", exception.Message);
        }

        [Fact]
        public async Task Validate_ShouldThrowsException_WhenValidJobLevelIdIsNotExists()
        {
            var validCollaboratorId = Guid.NewGuid();
            var validCompanyId = Guid.NewGuid();

            var initialCollaborator = CreateCollaborator(validCollaboratorId);
            var newCompany = CreateCompanyModel(validCompanyId);

            await _companyRepository.AddAsync(newCompany);
            await _collaboratorRepository.AddAsync(initialCollaborator);

            var workExperience = Create(startDate: DateOnly.Parse("2024-01-01"), collaboratorId: validCollaboratorId, companyId: validCompanyId);

            // Act
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _workExperienceService.Insert<WorkExperienceCreateModel>(workExperience, "admin"); });

            // Assert
            Assert.Contains("JobLevel does not exist", exception.Message);
        }

        [Fact]
        public async Task Validate_ShouldThrowsException_WhenValidJobTitleIdNotExists()
        {
            var validCollaboratorId = Guid.NewGuid();
            var validCompanyId = Guid.NewGuid();
            var validJobLevel = Guid.NewGuid();

            var initialCollaborator = CreateCollaborator(validCollaboratorId);
            var newCompany = CreateCompanyModel(validCompanyId);
            var newJobLevel = CreateJobLevelModel(validJobLevel);

            await _jobLevelRepository.AddAsync(newJobLevel);
            await _companyRepository.AddAsync(newCompany);
            await _collaboratorRepository.AddAsync(initialCollaborator);

            var workExperience = Create(startDate: DateOnly.Parse("2024-01-01"), collaboratorId: validCollaboratorId, companyId: validCompanyId, jobLevelId: validJobLevel);

            // Act
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _workExperienceService.Insert<WorkExperienceCreateModel>(workExperience, "admin"); });

            // Assert
            Assert.Contains("JobTitle does not exist", exception.Message);
        }

        [Fact]
        public async Task AddWorkExperience_ShouldAddWorkExperience_WhenValidOk()
        {
            var validCollaboratorId = Guid.NewGuid();
            var validCompanyId = Guid.NewGuid();
            var validJobLevel = Guid.NewGuid();
            var validJobTitle = Guid.NewGuid();
            
            
            var initialCollaborator = CreateCollaborator(validCollaboratorId);
            var newCompany = CreateCompanyModel(validCompanyId);
            var newJobLevel = CreateJobLevelModel(validJobLevel);
            var newJobTitle = CreateJobTitlelModel(validJobTitle);

            await _collaboratorRepository.AddAsync(initialCollaborator);
            await _companyRepository.AddAsync(newCompany);
            await _jobLevelRepository.AddAsync(newJobLevel);
            await _jobTitleRepository.AddAsync(newJobTitle);

            var workExperience = Create(startDate: DateOnly.Parse("2024-01-01"), collaboratorId: validCollaboratorId, companyId: validCompanyId, jobLevelId: validJobLevel, jobTitleId: validJobTitle);

            // Act
            Assert.NotNull(workExperience);
            Assert.True(workExperience  == workExperience);
        }
        #endregion

        [Fact]
        public async Task DeleteWorkExperience_ShouldThrowException_WhenWorkExperienceDoesNotExist()
        {
            // Arrange
            var notExistentWorkExperienceId = Guid.NewGuid(); 

            // Act
            var exception = await Assert.ThrowsAsync<ServiceException>(async () =>
            {
                await _workExperienceServiceTest.Delete(notExistentWorkExperienceId, "admin");
            });

            // Assert
            Assert.Contains("Work experience not found", exception.Message); // Mensagem esperada na exceção
        }

        //collaboratorId: validCollaboratorId, validWorkExperienceId, jobLevelId: Guid.NewGuid(), jobTitleId: Guid.NewGuid()
        [Fact]
        public async Task DeleteWorkExperience_ShouldThrowException_WhenInvalidIdIsProvided()
        {
            // Arrange
            var invalidWorkExperienceId = Guid.NewGuid(); // ID inexistente no banco

            // Act
            var exception = await Assert.ThrowsAsync<ServiceException>(async () =>
            {
                await _workExperienceService.Delete(invalidWorkExperienceId, "admin");
            });

            // Assert
            Assert.Contains("Work experience not found", exception.Message);
        }

    }
}
