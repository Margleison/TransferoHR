using DentalRJ.Domain.Entities.Base;
namespace DentalRJ.Domain.Entities
{
	public class ScheduleSlot : BaseEntity
	{

        public Guid ScheduleDayId { get; set; }
        public Guid ConsultingRoomId { get; set; }
        public Guid DentistryId { get; set; }
        public Guid? DentistId { get; set; }
        public Guid? PatientId { get; set; }
        public TimeOnly Time { get; set; }

        public required ScheduleDay ScheduleDay { get; set; }
        public required ConsultingRoom ConsultingRoom { get; set; }
        public required Dentistry Dentistry { get; set; }
        public Dentist? Dentist { get; set; }
        public Dentist? Patient { get; set; }

    }
}

