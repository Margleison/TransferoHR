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

        private GenericEntity Create(
            string createdby = "",
            string updatedby = ""
            ) 
        {
            return new GenericEntity
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = createdby,
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = updatedby
            }; 
        }
        [Fact]
        public void Validate_ShouldThrowException_WhenCreatedByIsEmpty()
        {
            // Arrange
            var entity = Create(createdby: "");

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => entity.Validate());

            //Assert
            Assert.Equal("Created By cannot be empty", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowException_WhenUpdatedAtIsNotNullButUpdatedByIsEmpty()
        {
            // Arrange
            var entity = Create(createdby: "Admin", updatedby: " ");
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

        [Fact]
        public void Activate_Ok()
        {
            // Arrange
            var entity = Create();

            //Act
            entity.Status = EntityStatusEnum.Inactive;

            entity.Status = EntityStatusEnum.Active;

            //Assert
            Assert.Equal(EntityStatusEnum.Active, entity.Status);
        }

        [Fact]
        public void Deactivate_Ok()
        {
            //Arrange
            var entity = Create();

            //Act
            entity.Status = EntityStatusEnum.Inactive;

            //Assert
            Assert.Equal(EntityStatusEnum.Inactive, entity.Status);
        }

    }
}
