using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using TransferoHR.Domain.Entities;
using TransferoHR.Domain.Enums;
using TransferoHR.Domain.Exceptions;
using TransferoHR.Infra.Database;
using TransferoHR.Infra.Repositories;
using TransferoHR.Infra.Repositories.Generic;
using TransferoHR.Services.Exceptions;
using TransferoHR.Services.Implementation;
using TransferoHR.Services.Interfaces;
using TransferoHR.Services.Model;
using TransferoHR.Services.Model.Generic;
using TransferoHR.Services.Params;

namespace TransferoHR.Test.Service
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
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = config.CreateMapper();

            // Configuração do In-Memory Database
            var options = new DbContextOptionsBuilder<HRContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            // Inicializa o repositório
            var context = new HRContext(options);
            _repo = new WorkExperienceRepository(context);
            _collaboratorRepository = new CollaboratorRepository(context);
            _companyRepository = new CompanyRepository(context);
            _jobLevelRepository = new JobLevelRepository(context);
            _jobTitleRepository = new JobTitleRepository(context);

            var genericRepository = new GenericEntityRepository<WorkExperience, WorkExperienceParams>(_context);

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
        private WorkExperienceUpdateModel UpdateModel(
              DateOnly startDate,
              DateOnly? endDate = null,
              Guid? collaboratorId = null,
              Guid? companyId = null,
              Guid? jobTitleId = null,
              Guid? jobLevelId = null,
              Guid? leaderId = null
            )
        {
            collaboratorId = collaboratorId ?? Guid.Empty;
            companyId = companyId ?? Guid.Empty;
            jobTitleId = jobTitleId ?? Guid.Empty;
            jobLevelId = jobLevelId ?? Guid.Empty;
            leaderId = leaderId ?? Guid.Empty;

            return new WorkExperienceUpdateModel
            {
                StartDate = startDate == default ? DateOnly.FromDateTime(DateTime.UtcNow) : startDate,
                CollaboratorId = collaboratorId.Value,
                EndDate = endDate.Value,
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
        public async Task AddWorkExperience_ShouldAddWorkExperience_WhenCollaboratorDoesNotExist()
        {
            var workExperience = Create(startDate: DateOnly.Parse("2024-01-01"));

            // Act
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _workExperienceService.Insert(workExperience, "admin"); });

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
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _workExperienceService.Insert(workExperience, "admin"); });

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
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _workExperienceService.Insert(workExperience, "admin"); });

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
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _workExperienceService.Insert(workExperience, "admin"); });

            // Assert
            Assert.Contains("JobTitle does not exist", exception.Message);
        }

        [Fact]
        public async Task Insert_Ok()
        {
            // Arrange
            var validCollaboratorId = Guid.NewGuid();
            var validLeaderId = Guid.NewGuid();
            var validCompanyId = Guid.NewGuid();
            var validJobLevel = Guid.NewGuid();
            var validJobTitle = Guid.NewGuid();

            var newCollaborator = CreateCollaborator(validCollaboratorId);
            var newLeader = CreateCollaborator(validLeaderId);
            var newCompany = CreateCompanyModel(validCompanyId);
            var newJobLevel = CreateJobLevelModel(validJobLevel);
            var newJobTitle = CreateJobTitlelModel(validJobTitle);

            await _collaboratorRepository.AddAsync(newCollaborator);
            await _collaboratorRepository.AddAsync(newLeader);
            await _companyRepository.AddAsync(newCompany);
            await _jobLevelRepository.AddAsync(newJobLevel);
            await _jobTitleRepository.AddAsync(newJobTitle);

            // Act
            var newCreateModel = Create(startDate: DateOnly.Parse("2024-01-01"), collaboratorId: validCollaboratorId, companyId: validCompanyId, jobLevelId: validJobLevel, jobTitleId: validJobTitle, leaderId: validLeaderId);
            var newObject = await _workExperienceService.Insert(newCreateModel, "admin");

            // Assert
            var readObject = await _repo.GetAsync(newObject.Id);
            Assert.NotNull(readObject);
            Assert.Equal(newCreateModel.CollaboratorId, readObject.CollaboratorId);
            Assert.Equal(newCreateModel.CompanyId, readObject.CompanyId);
            Assert.Equal(newCreateModel.JobLevelId, readObject.JobLevelId);
            Assert.Equal(newCreateModel.JobTitleId, readObject.JobTitleId);
            Assert.Equal(newCreateModel.LeaderId, readObject.LeaderId);
        }
        #endregion

        #region Delete-Update
        [Fact]
        public async Task DeleteWorkExperience_ShouldThrowException_WhenWorkExperienceDoesNotExist()
        {
            // Arrange
            var notExistentWorkExperienceId = Guid.NewGuid();
            // Act
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _workExperienceService.Delete(notExistentWorkExperienceId, "admin"); });

            // Assert
            Assert.Contains($"Work Experience does not exist. [Id={notExistentWorkExperienceId}]", exception.Message);
        }

        [Fact]
        public async Task DeleteWorkExperience_Ok()
        {
            // Arrange
            var newWorkExperience = CreateWorkExperience(startDate: DateOnly.Parse("2024-01-01"),
                endDate: DateOnly.Parse("2025-01-01"),
                collaboratorId: Guid.NewGuid(),
                companyId: Guid.NewGuid(),
                jobTitleId: Guid.NewGuid(),
                jobLevelId: Guid.NewGuid(),
                leaderId: Guid.NewGuid());

            await _repo.AddAsync(newWorkExperience);
            Assert.True(await _repo.GetAsync(newWorkExperience.Id) != null, "WorkExperience was not created during Arrange phase");

            // Act
            await _workExperienceService.Delete(newWorkExperience.Id, "admin");
            var readDelete = await _repo.GetAsync(newWorkExperience.Id);

            // Assert
            Assert.Null(readDelete); // Nao preciso verificar os ID's de algo que vai retornar nulo, Assert.Equal aqui seria desnecessario
        }

        [Fact]
        public async Task UpdateWorkExperience_ShouldThrowException_WhenWorkExperienceDoesNotExist()
        {
            // Arrange
            var notExistentWorkExperienceId = Guid.NewGuid();
            var updateWorkExperience = UpdateModel(startDate: DateOnly.Parse("2024-02-07"), collaboratorId: Guid.NewGuid(), companyId: Guid.NewGuid(), jobTitleId: Guid.NewGuid(), jobLevelId: Guid.NewGuid(), leaderId: Guid.NewGuid());

            // Act
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => { await _workExperienceService.Update(notExistentWorkExperienceId, updateWorkExperience, "admin"); });

            // Assert
            Assert.Contains("Work Experience does not exist", exception.Message);

        }

        [Fact]
        public async Task UpdateWorkExperience_Ok()
        {
            // Arrange
            var firstCollaboratorId = Guid.NewGuid();
            var secondCollaboratorId = Guid.NewGuid();

            var firstLeaderId = Guid.NewGuid();
            var secondLeaderId = Guid.NewGuid();

            var firstCompanyId = Guid.NewGuid();
            var secondCompanyId = Guid.NewGuid();

            var firstJobTitleId = Guid.NewGuid();
            var secondJobTitleId = Guid.NewGuid();

            var firstJobLevelId = Guid.NewGuid();
            var secondJobLevelId = Guid.NewGuid();

            await _collaboratorRepository.AddAsync(CreateCollaborator(firstCollaboratorId));
            await _collaboratorRepository.AddAsync(CreateCollaborator(secondCollaboratorId));

            await _collaboratorRepository.AddAsync(CreateCollaborator(firstLeaderId));
            await _collaboratorRepository.AddAsync(CreateCollaborator(secondLeaderId));

            await _companyRepository.AddAsync(CreateCompanyModel(firstCompanyId));
            await _companyRepository.AddAsync(CreateCompanyModel(secondCompanyId));

            await _jobTitleRepository.AddAsync(CreateJobTitlelModel(firstJobTitleId));
            await _jobTitleRepository.AddAsync(CreateJobTitlelModel(secondJobTitleId));

            await _jobLevelRepository.AddAsync(CreateJobLevelModel(firstJobLevelId, name: "senior"));
            await _jobLevelRepository.AddAsync(CreateJobLevelModel(secondJobLevelId, name: "junior"));

            var createModel = Create(startDate: DateOnly.Parse("2024-02-11"),
                collaboratorId: firstCollaboratorId,
                companyId: firstCompanyId,
                jobLevelId: firstJobLevelId,
                jobTitleId: firstJobTitleId,
                leaderId: firstLeaderId);

            var newWorkExperience = await _workExperienceService.Insert(createModel, "admin");

            var read = await _repo.GetAsync(newWorkExperience.Id);

            var updateWorkExperience = UpdateModel(startDate: DateOnly.Parse("2024-10-04"),
                collaboratorId: secondCollaboratorId,
                companyId: secondCompanyId,
                jobTitleId: secondJobTitleId,
                jobLevelId: secondJobLevelId,
                leaderId: secondLeaderId);


            // Act
            await _workExperienceService.Update(newWorkExperience.Id, updateWorkExperience, "admin");

            // Assert
            read = await _repo.GetAsync(newWorkExperience.Id);
            Assert.Equal(updateWorkExperience.CollaboratorId, read.CollaboratorId);
            Assert.Equal(updateWorkExperience.CompanyId, read.CompanyId);
            Assert.Equal(updateWorkExperience.JobTitleId, read.JobTitleId);
            Assert.Equal(updateWorkExperience.JobLevelId, read.JobLevelId);
            Assert.Equal(updateWorkExperience.LeaderId, read.LeaderId);
        }

        [Fact]
        public async Task UpdateWorkExperience_ShouldThrowException_WhenEndDateIsEqualStartDate()
        {
            // Arrange
            var firstCollaboratorId = Guid.NewGuid();
            var secondCollaboratorId = Guid.NewGuid();

            var firstLeaderId = Guid.NewGuid();
            var secondLeaderId = Guid.NewGuid();

            var firstCompanyId = Guid.NewGuid();
            var secondCompanyId = Guid.NewGuid();

            var firstJobTitleId = Guid.NewGuid();
            var secondJobTitleId = Guid.NewGuid();

            var firstJobLevelId = Guid.NewGuid();
            var secondJobLevelId = Guid.NewGuid();

            await _collaboratorRepository.AddAsync(CreateCollaborator(firstCollaboratorId));
            await _collaboratorRepository.AddAsync(CreateCollaborator(secondCollaboratorId));

            await _collaboratorRepository.AddAsync(CreateCollaborator(firstLeaderId));
            await _collaboratorRepository.AddAsync(CreateCollaborator(secondLeaderId));

            await _companyRepository.AddAsync(CreateCompanyModel(firstCompanyId));
            await _companyRepository.AddAsync(CreateCompanyModel(secondCompanyId));

            await _jobTitleRepository.AddAsync(CreateJobTitlelModel(firstJobTitleId));
            await _jobTitleRepository.AddAsync(CreateJobTitlelModel(secondJobTitleId));

            await _jobLevelRepository.AddAsync(CreateJobLevelModel(firstJobLevelId, name: "senior"));
            await _jobLevelRepository.AddAsync(CreateJobLevelModel(secondJobLevelId, name: "junior"));
            var createWorkExperience = CreateWorkExperience(startDate: DateOnly.Parse("2024-01-01"), endDate: DateOnly.Parse("2025-01-01"), collaboratorId: firstCollaboratorId, companyId: firstCompanyId, jobLevelId: firstJobLevelId, jobTitleId: firstJobTitleId, leaderId: firstLeaderId);

            var newWorkExperience = await _workExperienceService.Insert(createWorkExperience, "admin");

            var read = await _repo.GetAsync(newWorkExperience.Id);

            var invalidUpdateModel = UpdateModel(startDate: DateOnly.Parse("2025-01-01"), endDate: DateOnly.Parse("2025-01-01"),
                collaboratorId: secondCollaboratorId,
                companyId: secondCompanyId,
                jobTitleId: secondJobTitleId,
                jobLevelId: secondJobLevelId,
                leaderId: secondLeaderId);

            var exception = await Assert.ThrowsAsync<DomainException>(async () => await _workExperienceService.Update(createWorkExperience.Id, invalidUpdateModel, "admin"));

            // Assert
            Assert.Contains("Start Date and End Date cannot be the same.", exception.Message);
        }

        [Fact]
        public async Task UpdateWorkExperience_ShouldThrowException_WhenEndDateIsBeforeStartDate()
        {
            // Arrange
            var firstCollaboratorId = Guid.NewGuid();
            var secondCollaboratorId = Guid.NewGuid();

            var firstLeaderId = Guid.NewGuid();
            var secondLeaderId = Guid.NewGuid();

            var firstCompanyId = Guid.NewGuid();
            var secondCompanyId = Guid.NewGuid();

            var firstJobTitleId = Guid.NewGuid();
            var secondJobTitleId = Guid.NewGuid();

            var firstJobLevelId = Guid.NewGuid();
            var secondJobLevelId = Guid.NewGuid();

            await _collaboratorRepository.AddAsync(CreateCollaborator(firstCollaboratorId));
            await _collaboratorRepository.AddAsync(CreateCollaborator(secondCollaboratorId));

            await _collaboratorRepository.AddAsync(CreateCollaborator(firstLeaderId));
            await _collaboratorRepository.AddAsync(CreateCollaborator(secondLeaderId));

            await _companyRepository.AddAsync(CreateCompanyModel(firstCompanyId));
            await _companyRepository.AddAsync(CreateCompanyModel(secondCompanyId));

            await _jobTitleRepository.AddAsync(CreateJobTitlelModel(firstJobTitleId));
            await _jobTitleRepository.AddAsync(CreateJobTitlelModel(secondJobTitleId));

            await _jobLevelRepository.AddAsync(CreateJobLevelModel(firstJobLevelId, name: "senior"));
            await _jobLevelRepository.AddAsync(CreateJobLevelModel(secondJobLevelId, name: "junior"));
            var createWorkExperience = CreateWorkExperience(startDate: DateOnly.Parse("2024-01-01"), endDate: DateOnly.Parse("2025-01-01"), collaboratorId: firstCollaboratorId, companyId: firstCompanyId, jobLevelId: firstJobLevelId, jobTitleId: firstJobTitleId, leaderId: firstLeaderId);

            var newWorkExperience = await _workExperienceService.Insert(createWorkExperience, "admin");

            var read = await _repo.GetAsync(newWorkExperience.Id);

            var invalidUpdateModel = UpdateModel(startDate: DateOnly.Parse("2025-01-01"), endDate: DateOnly.Parse("2024-01-01"),
                collaboratorId: secondCollaboratorId,
                companyId: secondCompanyId,
                jobTitleId: secondJobTitleId,
                jobLevelId: secondJobLevelId,
                leaderId: secondLeaderId);

            var exception = await Assert.ThrowsAsync<DomainException>(async () => await _workExperienceService.Update(createWorkExperience.Id, invalidUpdateModel, "admin"));

            // Assert
            Assert.Contains("End Date cannot be earlier than Start Date.", exception.Message);
        }


        #endregion
        [Fact]
        public async Task Activate_ShouldThrowException_WhenActivateWorkExperience()
        {
            // Act 
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => await _workExperienceService.Activate(Guid.NewGuid(), "admin"));
            
            //Assert
            Assert.Equal("Activating a WorkExperience is not allowed.", exception.Message);
        }

        [Fact]
        public async Task DeactivateDeactivateWorkExperience()
        {
            // Act 
            var exception = await Assert.ThrowsAsync<ServiceException>(async () => await _workExperienceService.Deactivate(Guid.NewGuid(), "admin"));

            //Assert
            Assert.Equal("Deactivating a WorkExperience is not allowed.", exception.Message);
        }
    }
}