using DentalRJ.Domain.Entities.Base;
namespace DentalRJ.Domain.Entities
{
	public class Company : NamedBaseEntity
	{
		public IEnumerable<Clinic>? Clinics {get; set;}
	}
}

