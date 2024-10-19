using DentalRJ.Domain.Entities.Base;

namespace DentalRJ.Domain.Entities
{
    public class Dentistry : NamedBaseEntity
    {
        #region Relationship
            public ICollection<DentistDentistry> DentistDentistries { get; set; } = new List<DentistDentistry>();
            public ICollection<DentalInsuranceDentistry> DentalInsuranceDentistries { get; set; } = new List<DentalInsuranceDentistry>();
        #endregion region
    }
}
