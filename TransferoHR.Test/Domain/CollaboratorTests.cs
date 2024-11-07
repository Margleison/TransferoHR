using TransferoHR.Domain.Entities;
using TransferoHR.Domain.Enums;
using TransferoHR.Domain.Exceptions;

namespace TransferoHR.Test.Domain
{
    public class CollaboratorTests
    {
        [Fact]
        public void Validate_ShouldThrowsException_WhenpIfNationalityisBrazilianReturnRequiredCPF()
        {
            var entity = new Collaborator
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",
                Name = "Name",
                Email = "Margleison@gmail.com",
                WorkEmail = "Margleison@transfero.com",
                Country = "Brasil",
                Gender = GenderEnum.Man,
                RG = "35.216.967-6",
                BirthDate = DateOnly.Parse("2003-10-18"),
                Nationality = NationalityEnum.Brasileiro,
                Address = "address",
                City = "Nova Iguaçu",
                State = "Rio de Janeiro",
                PostalCode = "26291-221",
                PhoneNumber = "(21)98116-5068",
                EmergencyContact = "(21)98116-5069",
                BankBranch = "001",
                BankName = "Nubank",
                AccountName = "001",
                Pixkey = "0659017675"
            };

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("CPF is required for Brazilian citizens and cannot be empty!", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenpIfNationalityIsArgentineReturnRequiredDNI()
        {
            var entity = new Collaborator
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",
                Name = "Name",
                Email = "Margleison@gmail.com",
                WorkEmail = "Margleison@transfero.com",
                Country = "Brasil",
                Gender = GenderEnum.Man,
                RG = "35.216.967-6",
                BirthDate = DateOnly.Parse("2003-10-18"),
                Nationality = NationalityEnum.Argentino,
                Address = "address",
                City = "Nova Iguaçu",
                State = "Rio de Janeiro",
                PostalCode = "26291-221",
                PhoneNumber = "(21)98116-5068",
                EmergencyContact = "(21)98116-5069",
                BankBranch = "001",
                BankName = "Nubank",
                AccountName = "001",
                Pixkey = "0659017675"
            };
            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("DNI is required for Argentine citizens and cannot be empty!", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenCPFIsEmpty()
        {
            var entity = new Collaborator
            {
                Nationality = NationalityEnum.Brasileiro,
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",
                CPF = " ",
                Name = "Name",
                Email = "Margleison@gmail.com",
                WorkEmail = "Margleison@transfero.com",
                Country = "Brasil",
                Gender = GenderEnum.Man,
                RG = "35.216.967-6",
                BirthDate = DateOnly.Parse("2003-10-18"),
                Address = "address",
                City = "Nova Iguaçu",
                State = "Rio de Janeiro",
                PostalCode = "26291-221",
                PhoneNumber = "(21)98116-5068",
                EmergencyContact = "(21)98116-5069",
                BankBranch = "001",
                BankName = "Nubank",
                AccountName = "001",
                Pixkey = "06590176795"
            };

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("CPF is required for Brazilian citizens and cannot be empty!", exception.Message);
        }


        [Fact]
        public void Validate_ShouldThrowsException_WhenCPFIsInvalid()
        {
            var entity = new Collaborator
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",
                CPF = "065.000.555-77",
                Name = "Name",
                Email = "Margleison@gmail.com",
                WorkEmail = "Margleison@transfero.com",
                Country = "Brasil",
                Gender = GenderEnum.Man,
                RG = "35.216.967-6",
                BirthDate = DateOnly.Parse("2003-10-18"),
                Nationality = NationalityEnum.Brasileiro,
                Address = "address",
                City = "Nova Iguaçu",
                State = "Rio de Janeiro",
                PostalCode = "26291-221",
                PhoneNumber = "(21)98116-5068",
                EmergencyContact = "(21)98116-5069",
                BankBranch = "001",
                BankName = "Nubank",
                AccountName = "001",
                Pixkey = "06590176795"
            };

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Invalid CPF!", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenEmailIsEmpty()
        {
            var entity = new Collaborator
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",
                CPF = "065.901.767-95",
                Name = "Name",
                Email = " ",
                WorkEmail = " ",
                Country = "Brasil",
                Gender = GenderEnum.Man,
                RG = "35.216.967-6",
                BirthDate = DateOnly.Parse("2003-10-18"),
                Nationality = NationalityEnum.Brasileiro,
                Address = "address",
                City = "Nova Iguaçu",
                State = "Rio de Janeiro",
                PostalCode = "26291-221",
                PhoneNumber = "(21)98116-5068",
                EmergencyContact = "(21)98116-5069",
                BankBranch = "001",
                BankName = "Nubank",
                AccountName = "001",
                Pixkey = "06590176795"
            };

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Email cannot be empty!", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenEmailIsInvalid()
        {
            var entity = new Collaborator
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",
                CPF = "065.901.767-95",
                Name = "Name",
                Email = "Margleison",
                WorkEmail = "Margleison@.com",
                Country = "Brasil",
                Gender = GenderEnum.Man,
                RG = "35.216.967-6",
                BirthDate = DateOnly.Parse("2003-10-18"),
                Nationality = NationalityEnum.Brasileiro,
                Address = "address",
                City = "Nova Iguaçu",
                State = "Rio de Janeiro",
                PostalCode = "26291-221",
                PhoneNumber = "(21)98116-5068",
                EmergencyContact = "(21)98116-5069",
                BankBranch = "001",
                BankName = "Nubank",
                AccountName = "001",
                Pixkey = "06590176795"
            };

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Invalid Email!", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenpPostalCodeIsEmpty()
        {
            var entity = new Collaborator
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",
                CPF = "065.901.767-95",
                Name = "Name",
                Email = "Margleison@gmail.com",
                WorkEmail = "Margleison@transfero.com",
                Country = "Brasil",
                Gender = GenderEnum.Man,
                RG = "35.216.967-6",
                BirthDate = DateOnly.Parse("2003-10-18"),
                Nationality = NationalityEnum.Brasileiro,
                Address = "address",
                City = "Nova Iguaçu",
                State = "Rio de Janeiro",
                PostalCode = " ",
                PhoneNumber = "(21)98116-5068",
                EmergencyContact = "(21)98116-5069",
                BankBranch = "001",
                BankName = "Nubank",
                AccountName = "001",
                Pixkey = "06590176795"
            };

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Postal Code cannot be empty!", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenpPostalCodeIsInvalid()
        {
            var entity = new Collaborator
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",
                CPF = "065.901.767-95",
                Name = "Name",
                Email = "Margleison@gmail.com",
                WorkEmail = "Margleison@transfero.com",
                Country = "Brasil",
                Gender = GenderEnum.Man,
                RG = "35.216.967-6",
                BirthDate = DateOnly.Parse("2003-10-18"),
                Nationality = NationalityEnum.Brasileiro,
                Address = "address",
                City = "Nova Iguaçu",
                State = "Rio de Janeiro",
                PostalCode = "26291-1",
                PhoneNumber = "(21)98116-5068",
                EmergencyContact = "(21)98116-5069",
                BankBranch = "001",
                BankName = "Nubank",
                AccountName = "001",
                Pixkey = "06590176795"
            };

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Invalid Postal Code!", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenpRGCodeIsEmpty()
        {
            var entity = new Collaborator
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",
                CPF = "065.901.767-95",
                Name = "Name",
                Email = "Margleison@gmail.com",
                WorkEmail = "Margleison@transfero.com",
                Country = "Brasil",
                Gender = GenderEnum.Man,
                RG = " ",
                BirthDate = DateOnly.Parse("2003-10-18"),
                Nationality = NationalityEnum.Brasileiro,
                Address = "address",
                City = "Nova Iguaçu",
                State = "Rio de Janeiro",
                PostalCode = "26291-221",
                PhoneNumber = "(21)98116-5068",
                EmergencyContact = "(21)98116-5069",
                BankBranch = "001",
                BankName = "Nubank",
                AccountName = "001",
                Pixkey = "06590176795"
            };
            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("RG cannot be empty!", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenpRGCodeIsInvalid()
        {
            var entity = new Collaborator
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",
                CPF = "065.901.767-95",
                Name = "Name",
                Email = "Margleison@gmail.com",
                WorkEmail = "Margleison@transfero.com",
                Country = "Brasil",
                Gender = GenderEnum.Man,
                RG = ".216.967-6",
                BirthDate = DateOnly.Parse("2003-10-18"),
                Nationality = NationalityEnum.Brasileiro,
                Address = "address",
                City = "Nova Iguaçu",
                State = "Rio de Janeiro",
                PostalCode = "26291-221",
                PhoneNumber = "(21)98116-5068",
                EmergencyContact = "(21)98116-5069",
                BankBranch = "001",
                BankName = "Nubank",
                AccountName = "001",
                Pixkey = "06590176795"
            };
            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Invalid RG!", exception.Message);

        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenpPixKeyIsEmpty()
        {
            var entity = new Collaborator
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",
                CPF = "065.901.767-95",
                Name = "Name",
                Email = "Margleison@gmail.com",
                WorkEmail = "Margleison@transfero.com",
                Country = "Brasil",
                Gender = GenderEnum.Man,
                RG = "35.216.967-6",
                BirthDate = DateOnly.Parse("2003-10-18"),
                Nationality = NationalityEnum.Brasileiro,
                Address = "address",
                City = "Nova Iguaçu",
                State = "Rio de Janeiro",
                PostalCode = "26291-221",
                PhoneNumber = "(21)98116-5068",
                EmergencyContact = "(21)98116-5069",
                BankBranch = "001",
                BankName = "Nubank",
                AccountName = "001",
                Pixkey = " "
            };

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Pixkey cannot be empty!", exception.Message);

        }
        [Fact]
        public void Validate_ShouldThrowsException_WhenpPixKeyIsInvalid()
        {
            var entity = new Collaborator
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",
                CPF = "065.901.767-95",
                Name = "Name",
                Email = "Margleison@gmail.com",
                WorkEmail = "Margleison@transfero.com",
                Country = "Brasil",
                Gender = GenderEnum.Man,
                RG = "35.216.967-6",
                BirthDate = DateOnly.Parse("2003-10-18"),
                Nationality = NationalityEnum.Brasileiro,
                Address = "address",
                City = "Nova Iguaçu",
                State = "Rio de Janeiro",
                PostalCode = "26291-221",
                PhoneNumber = "(21)98116-5068",
                EmergencyContact = "(21)98116-5069",
                BankBranch = "001",
                BankName = "Nubank",
                AccountName = "001",
                Pixkey = "0659017675"
            };

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Invalid Pixkey!", exception.Message);

        }
        [Fact]
        public void Validate_ShouldThrowsException_WhenpBankBranchIsEmpty()
        {
            var entity = new Collaborator
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",
                CPF = "065.901.767-95",
                Name = "Name",
                Email = "Margleison@gmail.com",
                WorkEmail = "Margleison@transfero.com",
                Country = "Brasil",
                Gender = GenderEnum.Man,
                RG = "35.216.967-6",
                BirthDate = DateOnly.Parse("2003-10-18"),
                Nationality = NationalityEnum.Brasileiro,
                Address = "address",
                City = "Nova Iguaçu",
                State = "Rio de Janeiro",
                PostalCode = "26291-221",
                PhoneNumber = "(21)98116-5068",
                EmergencyContact = "(21)98116-5069",
                BankBranch = " ",
                BankName = "Nubank",
                AccountName = "001",
                Pixkey = "06590176795"
            };
            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("BankBranch cannot be empty!", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenpBankBranchIsInvalid()
        {
            var entity = new Collaborator
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",
                CPF = "065.901.767-95",
                Name = "Name",
                Email = "Margleison@gmail.com",
                WorkEmail = "Margleison@transfero.com",
                Country = "Brasil",
                Gender = GenderEnum.Man,
                RG = "35.216.967-6",
                BirthDate = DateOnly.Parse("2003-10-18"),
                Nationality = NationalityEnum.Brasileiro,
                Address = "address",
                City = "Nova Iguaçu",
                State = "Rio de Janeiro",
                PostalCode = "26291-221",
                PhoneNumber = "(21)98116-5068",
                EmergencyContact = "(21)98116-5069",
                BankBranch = "00",
                BankName = "Nubank",
                AccountName = "001",
                Pixkey = "0659017675"
            };

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Invalid BankBranch!", exception.Message);
    }
        [Fact]
        public void Validate_ShouldThrowsException_WhenpMaxLenghtAddressIsInvalid()
        {
            var entity = new Collaborator
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",
                CPF = "065.901.767-95",
                Name = "Name",
                Email = "Margleison@gmail.com",
                WorkEmail = "Margleison@transfero.com",
                Country = "Brasil",
                Gender = GenderEnum.Man,
                RG = "35.216.967-6",
                BirthDate = DateOnly.Parse("2003-10-18"),
                Nationality = NationalityEnum.Brasileiro,
                Address = new string('c', 101),
                City = "Nova Iguaçu",
                State = "Rio de Janeiro",
                PostalCode = "26291-221",
                PhoneNumber = "(21)98116-5068",
                EmergencyContact = "(21)98116-5069",
                BankBranch = "001",
                BankName = "Nubank",
                AccountName = "001",
                Pixkey = "06590176795"
            };
            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Address cannot exceed 60 characters", exception.Message);

        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenpMaxLenghtCityIsInvalid()
        {
            var entity = new Collaborator
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",
                CPF = "065.901.767-95",
                Name = "Name",
                Email = "Margleison@gmail.com",
                WorkEmail = "Margleison@transfero.com",
                Country = "Brasil",
                Gender = GenderEnum.Man,
                RG = "35.216.967-6",
                BirthDate = DateOnly.Parse("2003-10-18"),
                Nationality = NationalityEnum.Brasileiro,
                Address = "Rua Joaquim da Silva Maia",
                City = new string('c', 22),
                State = "Rio de Janeiro",
                PostalCode = "26291-221",
                PhoneNumber = "(21)98116-5068",
                EmergencyContact = "(21)98116-5069",
                BankBranch = "001",
                BankName = "Nubank",
                AccountName = "001",
                Pixkey = "06590176795"
            };
        }
        [Fact]
        public void Validate_ShouldThrowsException_WhenpMaxLenghtEmailIsInvalid()
        {
            var entity = new Collaborator
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",
                CPF = "065.901.767-95",
                Name = "Name",
                Email = "Margleison@gmail.com",
                WorkEmail = "Margleison@transfero.commmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm",
                Country = "Brasil",
                Gender = GenderEnum.Man,
                RG = "35.216.967-6",
                BirthDate = DateOnly.Parse("2003-10-18"),
                Nationality = NationalityEnum.Brasileiro,
                Address = "Rua Joaquim da Silva Maia",
                City = "Nova Iguaçu",
                State = "Rio de Janeiro",
                PostalCode = "26291-221",
                PhoneNumber = "(21)98116-5068",
                EmergencyContact = "(21)98116-5069",
                BankBranch = "001",
                BankName = "Nubank",
                AccountName = "001",
                Pixkey = "06590176795"
            };
            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Work Email cannot exceed 40 characters", exception.Message);
        }
        [Fact]
        public void Validate_ShouldThrowsException_WhenpDNIIsInvalid()
        {
            var entity = new Collaborator
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",
                DNI = "1234",
                Name = "Name",
                Email = "Margleison@gmail.com",
                WorkEmail = "Margleison@transfero.com",
                Country = "Brasil",
                Gender = GenderEnum.Man,
                RG = "35.216.967-6",
                BirthDate = DateOnly.Parse("2003-10-18"),
                Nationality = NationalityEnum.Argentino,
                Address = "Rua Joaquim da Silva Maia",
                City = "Nova Iguaçu",
                State = "Rio de Janeiro",
                PostalCode = "26291-221",
                PhoneNumber = "(21)98116-5068",
                EmergencyContact = "(21)98116-5069",
                BankBranch = "001",
                BankName = "Nubank",
                AccountName = "001",
                Pixkey = "06590176795"
            };
            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Invalid DNI!", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenpDNIIsEmpty()
        {
            var entity = new Collaborator
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",
                DNI = " ",
                Name = "Name",
                Email = "Margleison@gmail.com",
                WorkEmail = "Margleison@transfero.com",
                Country = "Brasil",
                Gender = GenderEnum.Man,
                RG = "35.216.967-6",
                BirthDate = DateOnly.Parse("2003-10-18"),
                Nationality = NationalityEnum.Argentino,
                Address = "Rua Joaquim da Silva Maia",
                City = "Nova Iguaçu",
                State = "Rio de Janeiro",
                PostalCode = "26291-221",
                PhoneNumber = "(21)98116-5068",
                EmergencyContact = "(21)98116-5069",
                BankBranch = "001",
                BankName = "Nubank",
                AccountName = "001",
                Pixkey = "06590176795"
            };
            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("DNI is required for Argentine citizens and cannot be empty!", exception.Message);
        }
    }
} 


