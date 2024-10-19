using DentalRJ.Domain.Entities.Base;
namespace DentalRJ.Domain.Entities
{
	public class Company : NamedBaseEntity
	{
		public ICollection<Clinic>? Clinics { get; set; } = new List<Clinic>();
    }
}

