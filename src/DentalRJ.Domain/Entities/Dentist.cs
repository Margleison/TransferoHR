using DentalRJ.Domain.Entities.Base;
using DentalRJ.Domain.Exceptions;
using DentalRJ.Domain.Validators;
using System.ComponentModel.DataAnnotations;
namespace DentalRJ.Domain.Entities
{
	public class Dentist : NamedBaseEntity
	{

        [MaxLength(11)]
        public string CPF { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(10)]
        public string CRO { get; set; } = string.Empty;


        #region Relationship
            public ICollection<DentistDentistry> DentistDentistries { get; set; } = new List<DentistDentistry>();
        #endregion

        private bool IsOlderThan18()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            int age = today.Year - BirthDate.Year;

            // Verifica se a data de aniversário deste ano já passou
            if (today < BirthDate.AddYears(age))
            {
                age--;
            }

            return age >= 18;
        }

        public override void Validate()
        {
            base.Validate();
            DomainException.When(String.IsNullOrWhiteSpace(CPF), "CPF cannot be empty!");
            DomainException.When(!CPFValidator.Validate(CPF), "Invalid CPF!");
            DomainException.When(String.IsNullOrWhiteSpace(Email), "Email cannot be empty!"); ;
            DomainException.When(!EmailValidador.Validate(Email), "Invalid Email!");
            DomainException.When(String.IsNullOrWhiteSpace(CRO), "CRO cannot be empty!");
            DomainException.When(BirthDate.Year < 1960, "The Dentist must have been born after 1960!");
            DomainException.When(IsOlderThan18() == false, "Dentist must be over 18 years of age!");
        }
    }
}

