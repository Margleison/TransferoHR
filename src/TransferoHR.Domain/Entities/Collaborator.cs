using TransferoHR.Domain.Validators;
using TransferoHR.Domain.Exceptions;
using TransferoHR.Domain.Entities.Generic;
using TransferoHR.TransferoDomain.Validators;
using TransferoHR.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.ComponentModel;


namespace TransferoHR.Domain.Entities
{
    public class Collaborator : GenericNamedEntity
    {
        public required NationalityEnum Nationality { get; set; }
        public string? CPF { get; set; }
 
        [DisplayName("Foreign Identification Document")]
        public string? ForeignIdentificationDocument { get; set; }

        [MaxLength(40)]
        public required string Email { get; set; }

        [DisplayName("Birth Date")]
        public required DateOnly BirthDate { get; set; }
        
        [MaxLength(60)]
        public required string Address { get; set; }

        [MaxLength(20)]
        [DisplayName("City Of Address")]
        public required string City { get; set; }

        [MaxLength(20)]
        public required string State { get; set; } //se brasileiro, validar se e um dos estados

        [DisplayName("Postal Code")]
        public required string PostalCode { get; set; }// se brasileiro, checar

        [DisplayName("Phone Number")]
        public required string PhoneNumber { get; set; } // se brasileiro, checar

        [MaxLength(40)]
        [DisplayName("Work Email")]
        public required string WorkEmail { get; set; }
        public GenderEnum? Gender { get; set; }

        [MaxLength(40)]
        public required string Country { get; set; } //se o Nationality = 0, Obrigatorio, Country = Nationality.

        public required string RG { get; set; } //, se brasileiro, obrigatorio           // OrgaoEmissor, se brasileiro, obrigatorio

        [DisplayName("Emergency Contact")]
        public string? EmergencyContact { get; set; }
        
        [DisplayName("Bank Name")]
        public required string BankName { get; set; }

        [DisplayName("Bank Branch")]
        public required string BankBranch { get; set; }

        [DisplayName("Bank Account")]
        public required string BankAccount { get; set; }

        [DisplayName("Pix Key")]
        public required string Pixkey { get; set; }

        //V A L I D A T E S 
        private void ValidadeIdentification()
        {
            if (Nationality == NationalityEnum.Brazilian)
            {
                ValidateStringEmptyAndLenght("CPF", CPFValidator.Validate);
                ForeignIdentificationDocument = null;
            }
            else
            {
                ValidateStringEmptyAndLenght("ForeignIdentificationDocument");
                CPF = null;
            }
        }
        private void ValidateRG()
        {
            if (Nationality == NationalityEnum.Brazilian)
            {
                ValidateStringEmptyAndLenght("RG");
            }
            else
            {
                RG = "";
            }
        }

        private void ValidatePhoneNumber()
        {
            ValidateStringEmptyAndLenght("PhoneNumber");
            DomainException.When(Nationality == NationalityEnum.Brazilian && PhoneNumberValidator.Validate(PhoneNumber) == false, "Invalid PhoneNumber!");
        }

        private void ValidateEmail()
        {
            ValidateStringEmptyAndLenght("Email", EmailValidador.Validate);
        }

        private void ValidateWorkEmail()
        {
            ValidateStringEmptyAndLenght("WorkEmail", EmailValidador.Validate);
        }

        private void ValidateBank()
        {
            ValidateStringEmptyAndLenght("BankBranch", BankBranchValidator.Validate);

            ValidateStringEmptyAndLenght("BankName", BankNameValidator.Validate);

            ValidateStringEmptyAndLenght("BankAccount", AccountNameValidator.Validate);
        }

        private void ValidateAddress() 
        {
            if (Nationality == NationalityEnum.Brazilian)
            {
                // Verifica se o estado é um dos estados brasileiros válidos
                if (!Enum.TryParse<BrazilianStates>(State, out _))
                {
                    throw new DomainException("Invalid state");

                }

                ValidateStringEmptyAndLenght("PostalCode", PostalCodeValidator.Validate);
            }

            ValidateStringEmptyAndLenght("State");

            ValidateStringEmptyAndLenght("City", CityValidator.Validate);

            ValidateStringEmptyAndLenght("Address");
        }

        public override void Validate()
        {
            {
                base.Validate();
                ValidadeIdentification();
                ValidateRG();
                ValidatePhoneNumber();
                ValidateEmail();
                ValidateWorkEmail();
                ValidateBank();
                ValidateAddress();
            }
        }
    }
}
   

