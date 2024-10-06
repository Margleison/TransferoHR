using DentalRJ.Domain.Entities.Base;
namespace DentalRJ.Domain.Entities
{
	public class Dentist : NamedBaseEntity
	{
        public IEnumerable<Dentistry>? Dentistries { get; set; }
    }
}

