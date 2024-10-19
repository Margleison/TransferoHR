using DentalRJ.Domain.Entities.Base;
using DentalRJ.Domain.Enums;
using DentalRJ.Domain.Exceptions;
using DentalRJ.Domain.Validators;
using System.ComponentModel.DataAnnotations;
namespace DentalRJ.Domain.Entities
{
	public class Clinic : NamedBaseEntity
    {
        [MaxLength(100)]
        public string TradeName { get; set; } = string.Empty;
        [MaxLength(15)]
        public string Phone { get; set; } = string.Empty;
        [MaxLength(15)]
        public string? Phone2 { get; set; } = string.Empty;
        [MaxLength(10)]
        public string PostalCode { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Address { get; set; } = string.Empty;
        [MaxLength(100)]
        public string AdditionalAddress { get; set; } = string.Empty;
        [MaxLength(100)]
        public string CityName { get; set; } = string.Empty;
        public Guid CompanyId { get; set; }

        #region FK
            public ICollection<ClinicDentalInsurance> ClinicDentalInsurances { get; set; } = new List<ClinicDentalInsurance>();
        #endregion

        [StringLength(2, MinimumLength = 2)]
        public string StateCode
        {
            get => ((StateCodeEnum)Enum.Parse(typeof(StateCodeEnum), this.stateCode)).ToString();
            set => this.stateCode = value;
        }
        private string stateCode = string.Empty;

        public required Company Company { get; set; }
        public override void Validate()
        {
            base.Validate();
            DomainException.When(String.IsNullOrWhiteSpace(TradeName), "TradeName cannot be empty!");
            DomainException.When(String.IsNullOrWhiteSpace(Phone), "Phone cannot be empty!");
            DomainException.When(!PhoneValidator.Validate(Phone), "Invalid Phone!");
            DomainException.When(!String.IsNullOrWhiteSpace(Phone2) && !PhoneValidator.Validate(Phone2), "Invalid Phone2!");
            DomainException.When(String.IsNullOrWhiteSpace(Address), "Address cannot be empty!");
            DomainException.When(String.IsNullOrWhiteSpace(AdditionalAddress), "Additional Address cannot be empty!");
            DomainException.When(String.IsNullOrWhiteSpace(CityName), "City cannot be empty!");
            DomainException.When(!EnumValidator.Validate<StateCodeEnum>(stateCode), $"Invalid State code! [{stateCode}]");
        }
    }
}

