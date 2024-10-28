using TransferoHR.Domain.Validators;
using TransferoHR.Domain.Exceptions;
using TransferoHR.Domain.Entities.Generic;
using TransferoHR.TransferoDomain.Validators;
using TransferoHR.Domain.Enums;


namespace TransferoHR.Domain.Entities
{
    public class Collaborator : GenericNamedEntity
    {

        public required string CPF { get; set; }
        public required string Email { get; set; }
        public required string WorkEmail { get; set; }
        public required GenderEnum Gender { get; set; }
        public required string Country { get; set; }
        public required string Rg { get; set; }
        public required DateOnly BirthDate { get; set; }
        public required string Nationality { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string PostalCode { get; set; }
        public string? EmergencyContact { get; set; }
        public required string PhoneNumber { get; set; } 
        public required string BankName { get; set; }
        public required string AccountName { get; set; }
        public required string BankBranch { get; set; }
        public required string Pixkey { get; set; }
        
    public override void Validate()
        {
            base.Validate();
            DomainException.When(string.IsNullOrWhiteSpace(PhoneNumber), "PhoneNumber cannot be empty!");
            DomainException.When(PhoneNumberValidator.Validate(PhoneNumber) == false, "Invalid PhoneNumber!");

            base.Validate();
            DomainException.When(string.IsNullOrWhiteSpace(PostalCode), "Postal Code cannot be empty!");
            DomainException.When(PostalCodeValidator.Validate(PostalCode) == false, "Invalid Postal Code!");

            base.Validate();
            DomainException.When(string.IsNullOrWhiteSpace(CPF), "CPF cannot be empty!");
            DomainException.When(CPFValidator.Validate(CPF) == false, "Invalid CPF!");

            base.Validate();
            DomainException.When(string.IsNullOrWhiteSpace(Rg), "RG cannot be empty!");
            DomainException.When(RGValidator.Validate(Rg) == false, "Invalid RG!");
            
            base.Validate();
            DomainException.When(string.IsNullOrWhiteSpace(Email), "Email cannot be empty!");
            DomainException.When(EmailValidador.Validate(Email) == false, "Invalid Email!");

            base.Validate();
            DomainException.When(string.IsNullOrWhiteSpace(WorkEmail), "WorkEmail cannot be empty!");
            DomainException.When(EmailValidador.Validate(WorkEmail) == false, "Invalid WorkEmail!");

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
        }
    }
}
   

