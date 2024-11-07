using System;
using System.Security.Principal;
using TransferoHR.Domain.Entities.Generic;
using TransferoHR.Domain.Enums;
using TransferoHR.Domain.Exceptions;
using Xunit;

namespace TransferoHR.Tests.Domain.Entities
{
    public class GenericEntityTests
    {


        [Fact]
        public void Validate_ShouldThrowException_WhenCreatedByIsEmpty()
        {
            // Arrange
            var entity = new GenericEntity
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = string.Empty
            };

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Created By cannot be empty", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowException_WhenUpdatedAtIsNotNullButUpdatedByIsEmpty()
        {
            // Arrange
            var entity = new GenericEntity
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = string.Empty
            };

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Updated By cannot be empty", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowException_WhenUpdatedByIsNotNullButUpdatedAtIsNull()
        {
            // Arrange
            var entity = new GenericEntity
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = null,
                UpdatedBy = "Updater"
            };

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Updated At cannot be empty", exception.Message);
        }

        [Fact]
        public void Validate_ShouldNotThrowException_WhenUpdatedByAndUpdatedAtAreBothNull()
        {
            // Arrange
            var entity = new GenericEntity
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = null,
                UpdatedBy = null
            };

            // Act & Assert
            var exception = Record.Exception(() => entity.Validate());
            Assert.Null(exception);
        }
    }
}
