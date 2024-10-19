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

        public required ScheduleSetup ScheduleSetup { get; set; }
        public required ConsultingRoom ConsultingRoom { get; set; }
        public required Dentistry Dentistry { get; set; }
        public required Dentist Dentist { get; set; }

        public ICollection<ScheduleSlot> ScheduleSlots { get; set; } = new List<ScheduleSlot>();
    }
}

