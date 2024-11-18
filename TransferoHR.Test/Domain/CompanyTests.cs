using System.Xml.Linq;
using TransferoHR.Domain.Entities;
using TransferoHR.Domain.Entities.Generic;
using TransferoHR.Domain.Enums;
using TransferoHR.Domain.Exceptions;

namespace TransferoHR.Test.Domain
{
    public class CompanyTests
    {
        private Company Create(
            string name = "",
            string cnpj = ""
            )
        {
            return new Company
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "Admin",
                Name = name,
                CNPJ = cnpj
            };
        }


        [Fact]
        public void Validate_ShouldThrowException_WhenCNPJIsEmpty()
        {
            //Arrenge
            var entity = Create(name: "HR", cnpj: " ");

            //Action       
            var exception = Assert.Throws<DomainException>(() => entity.Validate());

            //Assert
            Assert.Equal("CNPJ cannot be empty", exception.Message);

        }
        [Fact]
        public void Validate_ShouldThrowException_WhenCNPJisInvalid()
        {
            //Arrenge
            var entity = Create(name: "HR", cnpj: "035620.3064192063");

            //Action
            var exception = Assert.Throws<DomainException>(() => entity.Validate());

            //Assert
            Assert.Equal("Invalid CNPJ", exception.Message);

        }

        [Fact]
        public void Validate_Ok() 
        {
            var entity = Create(name: "HR", cnpj: "32.657.259/0001-04");

            entity.Validate();

            Assert.True(true);
        }
    }
}
