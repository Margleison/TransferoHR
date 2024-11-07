
using TransferoHR.Domain.Entities.Generic;
using TransferoHR.Domain.Enums;
using TransferoHR.Domain.Exceptions;

namespace TransferoHR.Test.Domain.Entities
{
    public class NamedGeneticentityTests
    {
        [Fact]
        public void Validate_ShouldThrowException_WhenNameIsEmpty()
        {

            var namedEntity = new GenericNamedEntity()
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "CreateBy",
                Name = string.Empty
            };

            var exception = Assert.Throws<DomainException>(() => namedEntity.Validate());
            Assert.Equal("Name cannot be empty!", exception.Message);
        }

        [Fact]
        public void ValidateShoulThrowException_WhenNameExceedsMaxLenght()
        {
            var namedEntity = new GenericNamedEntity()
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "System",
                Name = new string('c', 101)
            };
            var exception = Assert.Throws<DomainException>(() => namedEntity.Validate());
            Assert.Equal("Name cannot exceed 100 characters", exception.Message);
        }

        [Fact]
        public void Validate_OK_WhenDataValid()
        {

            var namedEntity = new GenericNamedEntity()
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "CreateBy",
                Name = "xxx"
            };

            var exception = Record.Exception(() => namedEntity.Validate());
            Assert.Null(exception);
        }
    }
}
