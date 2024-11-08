using TransferoHR.Domain.Entities;
using TransferoHR.Domain.Entities.Generic;

namespace TransferoHR.Domain.Entities
{
    public class WorkExperience : GenericNamedEntity
    {
        public required Guid CollaboratorId { get; set; }
        public required DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public required Guid JobTitleId { get; set; }
        public required Guid JobLevelId { get; set; }
        public required Guid LeaderId { get; set; }

        public required JobTitle JobTitle {  get; set; }
        public required  JobLevel JobLevel { get; set; }
        public required Collaborator Collaborator { get; set; }
        public required Collaborator Leader { get; set; }
    }
}
