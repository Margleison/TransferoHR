using DentalRJ.Domain.Entities.Base;
namespace DentalRJ.Domain.Entities
{
	public class ScheduleDay : NamedBaseEntity
	{

        public Guid ScheduleSetupId { get; set; }
        public Guid ConsultingRoomId { get; set; }
        public Guid DentistryId { get; set; }
        public Guid? DentistId { get; set; }
        public DateOnly Date { get; set; }

        public ScheduleSetup ScheduleSetup { get; set; }
        public ConsultingRoom ConsultingRoom { get; set; }
        public Dentistry Dentistry { get; set; }
        public Dentist? Dentist { get; set; }

        public IEnumerable<ScheduleSlot> ScheduleSlots { get; set; }
    }
}

