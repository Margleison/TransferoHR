using System.Xml.Linq;
using TransferoHR.Domain.Entities;
using TransferoHR.Domain.Entities.Generic;
using TransferoHR.Domain.Enums;
using TransferoHR.Domain.Exceptions;

namespace TransferoHR.Test.Domain
{
    public class CompanyTests
    {
        [Fact]
        public void Validate_ShouldThrowException_WhenCNPJIsEmpty()
        {
            var entity = new Company
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "string.Empty",
                Name = "EquipeX",
                CNPJ = ""
            };
            var exception = Assert.Throws<DomainException>(()=> entity.Validate());
            Assert.Equal("CNPJ cannot be empty!", exception.Message);

        }
        [Fact]
        public void Validate_ShouldThrowException_WhenCNPJisInvalid()
        {
            var entity = new Company
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Margleison",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "Nesse tempo ai",
                Name = "Equipe X",
                CNPJ = ".438.522/0001-42"
            };
            var exception = Assert.Throws<DomainException>(()=> entity.Validate());
            Assert.Equal("Invalid CNPJ!", exception.Message );
        }
    }
}
