using DentalRJ.Domain.Entities.Base;
using DentalRJ.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace DentalRJ.Domain.Entities
{
    public class DentalInsurance : NamedBaseEntity
    {
        [MaxLength(100)]
        public string BrandName { get; set; } = string.Empty;
        public bool NeedAuthorization { get; set; }
        public bool HasReimbursement { get; set; }
        public decimal CoPaymentPercentage { get; set; } = decimal.Zero;

        #region Relationship
            public ICollection<DentalInsuranceDentistry> DentalInsuranceDentistries { get; set; } = new List<DentalInsuranceDentistry>();
            public ICollection<ClinicDentalInsurance> ClinicDentalInsurances { get; set; } = new List<ClinicDentalInsurance>();
        #endregion

        public override void Validate()
        {
            base.Validate();
            DomainException.When(CoPaymentPercentage < 0 || CoPaymentPercentage > 100, $"Invalid CoPayment Percentage! [{CoPaymentPercentage}]");
        }
    }
}
