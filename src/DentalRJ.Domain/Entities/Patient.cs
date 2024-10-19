using DentalRJ.Domain.Entities.Base;
using DentalRJ.Domain.Enums;
using DentalRJ.Domain.Exceptions;
using DentalRJ.Domain.Validators;
using System.ComponentModel.DataAnnotations;
namespace DentalRJ.Domain.Entities
{
	public class Patient : NamedBaseEntity
    {
        [MaxLength(11)]
        public string CPF { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(10)]
        public string? PostalCode { get; set; } = string.Empty;
        [MaxLength(100)]
        public string? CityName { get; set; } = string.Empty;

        [StringLength(2, MinimumLength = 2)]
        public string StateCode
        {
            get => ((StateCodeEnum)Enum.Parse(typeof(StateCodeEnum), this.stateCode)).ToString();
            set => this.stateCode = value;
        }
        private string stateCode = string.Empty;

        private bool IsOlderThan5Years()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            int age = today.Year - BirthDate.Year;

            // Verifica se a data de aniversário deste ano já passou
            if (today < BirthDate.AddYears(age))
            {
                age--;
            }

            return age >= 5;
        }

        public override void Validate()
        {
            base.Validate();
            DomainException.When(String.IsNullOrWhiteSpace(CPF), "CPF cannot be empty!");
            DomainException.When(!CPFValidator.Validate(CPF), "Invalid CPF!");
            DomainException.When(String.IsNullOrWhiteSpace(Email), "Email cannot be empty!");
            DomainException.When(!EmailValidador.Validate(Email), "Invalid Email!");
            DomainException.When(BirthDate.Year < 1930, "The patient must have been born after 1930!");
            DomainException.When(IsOlderThan5Years() == false, "Patient must be over 5 years of age!");
        }
    }
}

