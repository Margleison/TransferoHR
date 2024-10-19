using DentalRJ.Domain.Entities.Base;

namespace DentalRJ.Domain.Entities
{
    public class DentalInsuranceDentistry : BaseEntity
    {
        public Guid DentistryId { get; set; }
        public Guid DentalInsuranceId { get; set; }

        public required Dentistry Dentistry { get; set; }
        public required DentalInsurance DentalInsurance { get; set; }
    }
}
