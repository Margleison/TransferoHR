using DentalRJ.Domain.Entities.Base;
namespace DentalRJ.Domain.Entities
{
	public class ConsultingRoom : NamedBaseEntity
	{
		public Guid ClinicId { get; set; }

		public Clinic? Clinic { get; set; }
    }
}

