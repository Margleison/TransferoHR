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

        public ConsultingRoom ConsultingRoom { get; set; }
        public Dentistry Dentistry { get; set; }
        public Dentist? Dentist { get; set; }
        public IEnumerable<ScheduleDay> ScheduleDays { get; set; }

    }
}

