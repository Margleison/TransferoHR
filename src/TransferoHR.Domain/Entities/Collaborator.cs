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

        public required string Address { get; set; }

        [MaxLength(20)]
        [DisplayName("City Of Address")]
        public required string City { get; set; }

        [MaxLength(20)]
        public required string State { get; set; } //sealed brasileiro, validar se e um dos estados

        [DisplayName("Postal Code")]
        public required string PostalCode { get; set; }//, se brasileiro, checar

        [DisplayName("Phone Number")]
        public required string PhoneNumber { get; set; } //, se brasileiro, checar

        [MaxLength(40)]
        [DisplayName("Work Email")]
        public required string WorkEmail { get; set; }
        public GenderEnum? Gender { get; set; }

        [MaxLength(40)]
        public required string Country { get; set; } //se o Nationality = 0, Obrigatorio, Country = Nationality.


        public required string RG { get; set; } //, se brasileiro, obrigatorio           // OrgaoEmissor, se brasileiro, obrigatorio

        [MaxLength(60)]
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
        private bool CompletedBankAccount()
        {
            return !string.IsNullOrWhiteSpace(BankName) && !string.IsNullOrWhiteSpace(BankBranch) && !string.IsNullOrWhiteSpace(BankAccount);
        }

        private void ValidateEmail()
        {
            ValidateStringEmptyAndLenght("Email");
            DomainException.When(EmailValidador.Validate(Email) == false, "Invalid Email!");
            var maxLenght = GetMaxLength("Email");
            DomainException.When(WorkEmail.Length > maxLenght, $"Email cannot exceed{maxLenght}characters");
        }

        private void ValidateWorkEmail()
        {
            ValidateStringEmptyAndLenght("WorkEmail"); 
            DomainException.When(EmailValidador.Validate(WorkEmail) == false, "Invalid Work Email!");
            var maxLenght = GetMaxLength("WorkEmail");
            DomainException.When(WorkEmail.Length > maxLenght, $"Work Email cannot exceed{maxLenght}characters");

        }

        private void ValidateCollaboradorBank()
        {
            ValidateStringEmptyAndLenght("ForeignIdentificationDocument");
            DomainException.When(BankBranchValidator.Validate(BankBranch) == false, "Invalid BankBranch!");

            ValidateStringEmptyAndLenght("ForeignIdentificationDocument");
            DomainException.When(BankNameValidator.Validate(BankName) == false, "Invalid BankName!");

            ValidateStringEmptyAndLenght("BankAccount");
            DomainException.When(AccountNameValidator.Validate(BankAccount) == false, "Invalid BankAccount!");
        }

        private void ValidateCollaboratorAddress() 
        {
            var maxLenght = GetMaxLength("State");
            DomainException.When(State.Length > maxLenght, $"State cannot exceed {maxLenght} characters");

            DomainException.When(PostalCodeValidator.Validate(PostalCode) == false, "Invalid Postal Code!");

            maxLenght = GetMaxLength("City");
            DomainException.When(City.Length > maxLenght, $"City cannot exceed {maxLenght} characters");
            DomainException.When(CityValidator.Validate(City) == false, "Invalid City!");

            maxLenght = GetMaxLength("Address");
            DomainException.When(Address.Length > maxLenght, $"Address cannot exceed {maxLenght} characters");
        }


        public override void Validate()
        {
            {
                base.Validate();
                if (Nationality == NationalityEnum.Brazilian)
                {
                    ValidateStringEmptyAndLenght("CPF");
                    DomainException.When(string.IsNullOrWhiteSpace(CPF), "CPF is required for Brazilian citizens!");
                    DomainException.When(CPFValidator.Validate(CPF) == false, "Invalid CPF!");
                    ForeignIdentificationDocument = "";
                }
                else
                {
                    ValidateStringEmptyAndLenght("ForeignIdentificationDocument");
                    DomainException.When(string.IsNullOrWhiteSpace(ForeignIdentificationDocument), "ForeignIdentificationDocument is required for Argentine citizens!");
                    DomainException.When(ForeignIdentificationDocumentValidator.Validate(ForeignIdentificationDocument) == false, "Invalid ForeignIdentificationDocument!");
                    CPF = "";
                }

                ValidateStringEmptyAndLenght("RG");

                ValidateStringEmptyAndLenght("PhoneNumber");
                DomainException.When(PhoneNumberValidator.Validate(PhoneNumber) == false, "Invalid PhoneNumber!");

                
                
                ValidateEmail();
                ValidateWorkEmail();
                ValidateCollaboradorBank();
                ValidateCollaboratorAddress();
            }
        }
    }
}
   

