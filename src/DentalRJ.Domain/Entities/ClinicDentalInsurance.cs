using DentalRJ.Domain.Entities.Base;


namespace DentalRJ.Domain.Entities
{
    public class ClinicDentalInsurance : BaseEntity
    {
        public Guid ClinicId { get; set; }
        public Guid DentalInsuranceId { get; set; }

        public required Clinic Clinic { get; set; }
        public required DentalInsurance DentalInsurance { get; set; }
    }
}