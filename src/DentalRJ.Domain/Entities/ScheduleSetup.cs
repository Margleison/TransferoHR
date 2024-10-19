using DentalRJ.Domain.Entities.Base;
namespace DentalRJ.Domain.Entities
{
	public class ScheduleSetup : BaseEntity
	{
		public Guid ConsultingRoomId { get; set; }
        public Guid DentistryId { get; set; }
        public Guid? DentistId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

		public TimeOnly WorkStart  {get; set; }
		public TimeOnly WorkEnd { get; set; }

        public TimeOnly BreakStart { get; set; }
        public TimeOnly BreakEnd { get; set; }

        public required ConsultingRoom ConsultingRoom { get; set; }
        public required Dentistry Dentistry { get; set; }
        public required Dentist Dentist { get; set; }
        public ICollection<ScheduleDay> ScheduleDays { get; set; } = new List<ScheduleDay>();

    }
}

