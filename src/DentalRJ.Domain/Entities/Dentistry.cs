using DentalRJ.Domain.Entities.Base;

namespace DentalRJ.Domain.Entities
{
    public class Dentistry : NamedBaseEntity
    {
        public IEnumerable<Dentist>? Dentists { get; set; }
    }
}
