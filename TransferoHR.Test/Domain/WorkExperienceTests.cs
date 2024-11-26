using TransferoHR.Domain.Entities;
using TransferoHR.Domain.Enums;
using TransferoHR.Domain.Exceptions;
using TransferoHR.Infra.Database;
using TransferoHR.Infra.Repositories;
using TransferoHR.Services.Interfaces;

namespace TransferoHR.Test.Domain {
    public class WorkExperienceTests
    {
        
        private WorkExperience Create(
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

        [Fact]
        public void Validate_ShouldThrowException_WhenStartDateIsEqualToEndDate()
        {
            // Arrange
            var entity = Create(
                startDate: DateOnly.Parse("2024-01-01"),
                endDate: DateOnly.Parse("2024-01-01")  // StartDate é igual a EndDate
            );

            // Act
            var exception = Assert.Throws<DomainException>(() => entity.Validate());

            // Assert
            Assert.Equal("Start Date and End Date cannot be the same.", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowException_WhenEndDateIsBeforeStartDate()
        {
            // Arrange
            var entity = Create(
                startDate: DateOnly.Parse("2024-01-01"),
                endDate: DateOnly.Parse("2023-12-31")  // EndDate é antes de StartDate
            );

            // Act
            var exception = Assert.Throws<DomainException>(() => entity.Validate());

            // Assert
            Assert.Equal("End Date cannot be earlier than Start Date.", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowException_WhenCompanyIdIsEmpty()
        {
            // Arrange
            var entity = Create(
                startDate: DateOnly.Parse("2024-01-01"),
                endDate: DateOnly.Parse("2025-01-01")
            );

            // Act
            var exception = Assert.Throws<DomainException>(() => entity.Validate());

            // Assert 
            Assert.Equal("Company ID cannot be empty.", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowException_WhenJobTitleIdIsEmpty()
        {
            // Arrange
            var entity = Create(

                startDate: DateOnly.Parse("2024-01-01"),
                endDate: DateOnly.Parse("2025-01-01"),
                companyId: Guid.NewGuid()
            );

            // Act
            var exception = Assert.Throws<DomainException>(() => entity.Validate());

            // Assert
            Assert.Equal("Job Title ID cannot be empty.", exception.Message);
        }

        [Fact]
        public async void Validate_ShouldThrowException_WhenJobLevelIdIsEmpty()
        {
            // Arrange
            var entity = Create(

                startDate: DateOnly.Parse("2024-01-01"),
                endDate: DateOnly.Parse("2025-01-01"),
                companyId: Guid.NewGuid(),
                jobTitleId: Guid.NewGuid()
            );

            // Act
            var exception = Assert.Throws<DomainException>(() => entity.Validate());

            // Assert
            Assert.Equal("Job Level ID cannot be empty.", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowException_WhenLeaderIdIsEmpty()
        {
            // Arrange
            var entity = Create(
                startDate: DateOnly.Parse("2024-01-01"),
                endDate: DateOnly.Parse("2025-01-01"),
                companyId: Guid.NewGuid(),
                jobTitleId: Guid.NewGuid(),
                jobLevelId: Guid.NewGuid(),
                leaderId: Guid.Empty  // LeaderId é vazio
            );

            // Act
            var exception = Assert.Throws<DomainException>(() => entity.Validate());

            // Assert
            Assert.Equal("Leader ID cannot be empty.", exception.Message);
        }

        [Fact]
        public void Validate_ShouldNotThrowException_WhenAllRequiredParamsAreProvided()
        {
            // Arrange
            var entity = Create(
                startDate: DateOnly.Parse("2024-01-01"),
                endDate: DateOnly.Parse("2025-01-01"),
                collaboratorId : Guid.NewGuid(),
                companyId: Guid.NewGuid(),
                jobTitleId: Guid.NewGuid(),
                jobLevelId: Guid.NewGuid(),
                leaderId: Guid.NewGuid()
            );

            // Act
            var exception = Record.Exception(() => entity.Validate());

            // Assert
            Assert.Null(exception);  // Espera-se que não haja exceção
        }
    }
}

