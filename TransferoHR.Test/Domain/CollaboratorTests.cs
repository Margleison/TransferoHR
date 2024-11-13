﻿using TransferoHR.Domain.Entities;
using TransferoHR.Domain.Enums;
using TransferoHR.Domain.Exceptions;

namespace TransferoHR.Test.Domain
{
    public class CollaboratorTests
    {

        private Collaborator Create(
                NationalityEnum nationality = NationalityEnum.Brazilian,
                string cpf = "",
                string foreignIdentificationDocument = "",
                string email = "",
                string workEmail = "",
                string rg = "",
                string pixkey = "",
                string country = "",
                DateOnly birthDate = new DateOnly(),
                string address = "",
                string city = "",
                string state = "",
                string postalCode = "",
                string phoneNumber = "(21) 98116-5068",
                string bankBranch = "",
                string emergencyContact = "",
                string bankName = "",
                string bankAccount = "",
                GenderEnum gender = GenderEnum.Man
        )
        {
            return new Collaborator
            {
                Id = Guid.NewGuid(),
                Status = EntityStatusEnum.Active,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "System",
                Name = "Name",
                CPF = cpf,
                ForeignIdentificationDocument = foreignIdentificationDocument,
                RG = rg,
                Email = email,
                WorkEmail = workEmail,
                Country = country,
                Gender = gender,
                BirthDate = birthDate,
                Nationality = nationality,
                Address = address,
                City = city,
                State = state,
                PostalCode = postalCode,
                PhoneNumber = phoneNumber,
                EmergencyContact = emergencyContact,
                BankBranch = bankBranch,
                BankName = bankName,
                BankAccount = bankAccount,
                Pixkey = pixkey
            };
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenBrazilianAndCPFIsNullOrEmpty()
        {
            // Arrange
            var entity = Create();

            // Act
            var exception = Assert.Throws<DomainException>(() => entity.Validate());

            // Assert
            Assert.Equal("CPF cannot be empty", exception.Message);
        }
        [Fact]
        public void Validate_ShouldThrowsException_WhenBrazilianAndCPFIsInvalid()
        {
            // Arrange
            var entity = Create(cpf: "010010101010101");

            // Act
            var exception = Assert.Throws<DomainException>(() => entity.Validate());

            // Assert
            Assert.Equal("Invalid CPF!", exception.Message);
        }
        [Fact]
        public void Validate_ShouldThrowsException_WhenArgentineAndForeignIdentificationDocumentIsNullOrEmpty()
        {
            // Arrange
            var entity = Create( nationality: NationalityEnum.Argentine);

            // Act
            var exception = Assert.Throws<DomainException>(() => entity.Validate());

            // Assert
            Assert.Equal("Foreign Identification Document cannot be empty", exception.Message);
        }
        [Fact]
        public void Validate_ShouldThrowsException_WhenArgentineAndForeignIdentificationDocumentIsInvalid()
        {
            // Arrange
            var entity = Create(nationality: NationalityEnum.Argentine, foreignIdentificationDocument: "010010101010101");

            // Act
            var exception = Assert.Throws<DomainException>(() => entity.Validate());

            // Assert
            Assert.Equal("Invalid ForeignIdentificationDocument!", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenRGIsNull()
        {
            // Arrange
            var entity = Create(nationality: NationalityEnum.Argentine, foreignIdentificationDocument: "1111111");

            // Act
            var exception = Assert.Throws<DomainException>(() => entity.Validate());

            Assert.Equal("RG cannot be empty", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenEmailIsEmpty()
        {
            var entity = Create(cpf: "065.901.767-95", rg: "35.216.967.6", email: " ");

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Email cannot be empty", exception.Message);
        }



        [Fact]
        public void Validate_ShouldThrowsException_WhenEmailIsInvalid()
        {
            var entity = Create(cpf: "065.901.767-95", rg: "35.216.967.6", email: "margleison@.com");

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Invalid Email!", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenpMaxLenghtEmailIsInvalid()
        {

            var entity = Create(cpf: "065.901.767-95", rg: "35.216.967.6", email: "margleison.silveira@gmail.commmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm");

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Email cannot exceed 40 characters", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenpPixKeyIsEmpty()
        {

            var entity = Create(nationality: NationalityEnum.Brazilian, cpf: "065.901.767-95",foreignIdentificationDocument: "", rg: "35.216.967.6", email: "margleison.silva@gmail.com", workEmail: "margleison.silva@transfero.com", pixkey: " ");

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Pixkey cannot be empty!", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenpPixKeyIsInvalid()
        {

            var entity = Create(cpf: "065.901.767-95", rg: "35.216.967.6", email: "margleison.silva@gmail.com",workEmail: "margleison.silva@transfero.com", pixkey: "0659017679");

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Invalid Pixkey!", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenpBankBranchIsEmpty()
        {

            var entity = Create( cpf: "065.901.767-95", rg: "35.216.967.6", email: "margleison.silva@gmail.com", workEmail: "margleison.silva@transfero.com", pixkey: "06590176795", bankBranch: " ");

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("BankBranch cannot be empty!", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenpBankBranchIsInvalid()
        {

            var entity = Create( cpf: "065.901.767-95", rg: "35.216.967.6", email: "margleison.silva@gmail.com", workEmail: "margleison.silva@transfero.com", pixkey: "06590176795", bankBranch: "00");

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Invalid BankBranch!", exception.Message);
        }
        [Fact]
        public void Validate_ShouldThrowsException_WhenpBankNameIsEmpty()
        {

            var entity = Create( cpf: "065.901.767-95", rg: "35.216.967.6", email: "margleison.silva@gmail.com", workEmail: "margleison.silva@transfero.com", pixkey: "06590176795", bankBranch: "001", bankName: " " );

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("BankName cannot be empty!", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenpBankNameIsInvalid()
        {

            var entity = Create( cpf: "065.901.767-95", rg: "35.216.967.6", email: "margleison.silva@gmail.com", workEmail: "margleison.silva@transfero.com", pixkey: "06590176795", bankBranch: "001", bankName: "07775");

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Invalid BankName!", exception.Message);
        }
        [Fact]
        public void Validate_ShouldThrowsException_WhenpaAccountNameIsEmpty()
        {

            var entity = Create( cpf: "065.901.767-95", rg: "35.216.967.6", email: "margleison.silva@gmail.com", workEmail: "margleison.silva@transfero.com", pixkey: "06590176795", bankBranch: "001", bankName: "Nubank", bankAccount: " ");

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("AccountName cannot be empty!", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenpAccountNameIsInvalid()
        {

            var entity = Create( cpf: "065.901.767-95", rg: "35.216.967.6", email: "margleison.silva@gmail.com", workEmail: "margleison.silva@transfero.com", pixkey: "06590176795", bankBranch: "001", bankName: "Nubank", bankAccount: "001005655145nsdabisdajifdhuiosdaguiosfdapbuisfdaphuosfdaphiosfdaphio");

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Invalid AccountName!", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenpPostalCodeIsEmpty()
        {

            var entity = Create( cpf: "065.901.767-95", rg: "35.216.967.6", email: "margleison.silva@gmail.com", workEmail: "margleison.silva@transfero.com", pixkey: "06590176795", bankBranch: "001", bankName: "Nubank", bankAccount: "001005655145", postalCode: " ");

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Postal Code cannot be empty!", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenpPostalCodeIsInvalid()
        {

            var entity = Create( cpf: "065.901.767-95", rg: "35.216.967.6", email: "margleison.silva@gmail.com", workEmail: "margleison.silva@transfero.com", pixkey: "06590176795", bankBranch: "001", bankName: "Nubank", bankAccount: "001005655145", postalCode: "26291-00");

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Invalid Postal Code!", exception.Message);
        }
        [Fact]
        public void Validate_ShouldThrowsException_WhenpCityIsEmpty()
        {

            var entity = Create( cpf: "065.901.767-95", rg: "35.216.967.6", email: "margleison.silva@gmail.com", workEmail: "margleison.silva@transfero.com", pixkey: "06590176795", bankBranch: "001", bankName: "Nubank", bankAccount: "001005655145", postalCode: "26291-221", city: " ");

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("City cannot be empty!", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenpCityIsInvalid()
        {

            var entity = Create( cpf: "065.901.767-95", rg: "35.216.967.6", email: "margleison.silva@gmail.com", workEmail: "margleison.silva@transfero.com", pixkey: "06590176795", bankBranch: "001", bankName: "Nubank", bankAccount: "001005655145", postalCode: "26291-221", city: "25455");

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Invalid City!", exception.Message);
        }


        [Fact]
        public void Validate_ShouldThrowsException_WhenpMaxLenghtCityIsInvalid()
        {

            var entity = Create( cpf: "065.901.767-95", rg: "35.216.967.6", email: "margleison.silva@gmail.com", workEmail: "margleison.silva@transfero.com", pixkey: "06590176795", bankBranch: "001", bankName: "Nubank", bankAccount: "001005655145", postalCode: "26291-221", city: "Nova Iguaçuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu");

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("City cannot exceed 20 characters", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenpAddressIsEmpty()
        {

            var entity = Create( cpf: "065.901.767-95", rg: "35.216.967.6", email: "margleison.silva@gmail.com", workEmail: "margleison.silva@transfero.com", pixkey: "06590176795", bankBranch: "001", bankName: "Nubank", bankAccount: "001005655145", postalCode: "26291-221", city: "Nova Iguaçu", address: " ");

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Address cannot be empty!", exception.Message);
        }

        [Fact]
        public void Validate_ShouldThrowsException_WhenpMaxLenghtAddressIsInvalid()
        {

            var entity = Create( cpf: "065.901.767-95", rg: "35.216.967.6", email: "margleison.silva@gmail.com", workEmail: "margleison.silva@transfero.com", pixkey: "06590176795", bankBranch: "001", bankName: "Nubank", bankAccount: "001005655145", postalCode: "26291-221", city: "Nova Iguaçu", address: new string('c', 101));

            var exception = Assert.Throws<DomainException>(() => entity.Validate());
            Assert.Equal("Address cannot exceed 60 characters", exception.Message);
        }

    }
}

/*
            * 
               "Margleison@gmail.com",
               "Margleison@transfero.com",
               "Brasil",
               "35.216.967-6",
               DateOnly.Parse("2003-10-18"),
               "address",
               "Nova Iguaçu",
               "Rio de Janeiro",
               "26291-221",
               "(21)98116-5068",
               "(21)98116-5069",
               "001",
               "Nubank",
               "0659017675",
               "001",
               GenderEnum.Man
            * */