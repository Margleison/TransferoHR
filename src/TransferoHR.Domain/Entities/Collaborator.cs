using TransferoHR.Domain.Validators;
using TransferoHR.Domain.Exceptions;
using TransferoHR.Domain.Entities.Generic;
using TransferoHR.TransferoDomain.Validators;
using TransferoHR.Domain.Enums;
using System.ComponentModel.DataAnnotations;


namespace TransferoHR.Domain.Entities
{
    public class Collaborator : GenericNamedEntity
    {
        public required NationalityEnum Nationality { get; set; }
        public string? CPF { get; set; }
        public string? DNI { get; set; }
        [MaxLength(40)]
        public required string Email { get; set; }
        [MaxLength(40)]
        public required string WorkEmail { get; set; }
        public GenderEnum? Gender { get; set; }
        [MaxLength(40)]
        public required string Country { get; set; }
        public required string RG { get; set; }
        public required DateOnly BirthDate { get; set; }
        [MaxLength(60)]
        public required string Address { get; set; }
        [MaxLength(20)]
        public required string City { get; set; }
        [MaxLength(20)]
        public required string State { get; set; }
        public required string PostalCode { get; set; }
        public string? EmergencyContact { get; set; }
        public required string? PhoneNumber { get; set; } 
        public required string BankName { get; set; }
        public required string AccountName { get; set; }
        public required string BankBranch { get; set; }
        public required string Pixkey { get; set; }



        public override void Validate()
        {
            //base.Validate();
            //DomainException.When(string.IsNullOrWhiteSpace(PhoneNumber), "PhoneNumber cannot be empty!");
            //DomainException.When(PhoneNumberValidator.Validate(PhoneNumber) == false, "Invalid PhoneNumber!");

            {
                if (Nationality == NationalityEnum.Brasileiro)
                {
                    DomainException.When(string.IsNullOrWhiteSpace(CPF), "CPF is required for Brazilian citizens and cannot be empty!");
                    base.Validate();
                    DomainException.When(CPFValidator.Validate(CPF) == false, "Invalid CPF!");
                }

                else if (Nationality == NationalityEnum.Argentino)
                {
                    DomainException.When(string.IsNullOrWhiteSpace(DNI), "DNI is required for Argentine citizens and cannot be empty!");
                    base.Validate();
                    DomainException.When(DniValidator.Validate(DNI) == false, "Invalid DNI!");
                }




                base.Validate();
                DomainException.When(string.IsNullOrWhiteSpace(PostalCode), "Postal Code cannot be empty!");
                DomainException.When(PostalCodeValidator.Validate(PostalCode) == false, "Invalid Postal Code!");


                base.Validate();
                DomainException.When(string.IsNullOrWhiteSpace(RG), "RG cannot be empty!");
                DomainException.When(RGValidator.Validate(RG) == false, "Invalid RG!");

                base.Validate();
                DomainException.When(string.IsNullOrWhiteSpace(Email), "Email cannot be empty!");
                DomainException.When(EmailValidador.Validate(Email) == false, "Invalid Email!");
                DomainException.When(Email.Length > 40, "Email cannot exceed 40 characters");


                base.Validate();
                DomainException.When(string.IsNullOrWhiteSpace(WorkEmail), "WorkEmail cannot be empty!");
                DomainException.When(EmailValidador.Validate(WorkEmail) == false, "Invalid WorkEmail!");
                DomainException.When(WorkEmail.Length > 40, "Work Email cannot exceed 40 characters");


                base.Validate();
                DomainException.When(string.IsNullOrWhiteSpace(BankName), "BankName cannot be empty!");
                DomainException.When(BankNameValidator.Validate(BankName) == false, "Invalid BankName!");

                base.Validate();
                DomainException.When(string.IsNullOrWhiteSpace(AccountName), "AccountName cannot be empty!");
                DomainException.When(AccountNameValidator.Validate(AccountName) == false, "Invalid AccountName!");

                base.Validate();
                DomainException.When(string.IsNullOrWhiteSpace(BankBranch), "BankBranch cannot be empty!");
                DomainException.When(BankBranchValidator.Validate(BankBranch) == false, "Invalid BankBranch!");

                base.Validate();
                DomainException.When(string.IsNullOrWhiteSpace(Pixkey), "Pixkey cannot be empty!");
                DomainException.When(PixKeyValidator.Validate(Pixkey) == false, "Invalid Pixkey!");

                base.Validate();
                DomainException.When(string.IsNullOrWhiteSpace(City), "City cannot be empty!");
                DomainException.When(CityValidator.Validate(City) == false, "Invalid City!");
                DomainException.When(City.Length > 20, "City cannot exceed 20 characters");
                
                base.Validate();
                DomainException.When(string.IsNullOrWhiteSpace(Address), "Address cannot be empty!");
                DomainException.When(Address.Length > 60, "Address cannot exceed 60 characters");
            }
        }
    }
}
   

