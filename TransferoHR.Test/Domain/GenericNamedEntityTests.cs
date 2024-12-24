
using TransferoHR.Domain.Entities.Generic;
using TransferoHR.Domain.Enums;
using TransferoHR.Domain.Exceptions;

namespace TransferoHR.Test.Domain.Entities
{
    public class GenericNamedEntityTests
    {
            private GenericNamedEntity Create(
            
            string name = ""
            
            ) 
        {
            return new GenericNamedEntity
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "CreateBy",
                Name = name
            };
        }


        [Fact]
        public void Validate_ShouldThrowException_WhenNameIsEmpty()
        {

            var namedEntity = Create(name: " ");

            var exception = Assert.Throws<DomainException>(() => namedEntity.Validate());
            Assert.Equal("Name cannot be empty", exception.Message);
        }

        [Fact]
        public void ValidateShoulThrowException_WhenNameExceedsMaxLenght()
        {
            var namedEntity = Create(name: new string('c', 101));
            
            var exception = Assert.Throws<DomainException>(() => namedEntity.Validate());
            
            Assert.Equal("Name cannot exceed 100 characters", exception.Message);
        }

        [Fact]
        public void Validate_OK_WhenDataValid()
        {

            var namedEntity = Create(name: "Sergio");

            var exception = Record.Exception(() => namedEntity.Validate());
            
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
