
using TransferoHR.Services.Exceptions;
using TransferoHR.Services.Model.Generic;

namespace TransferoHR.Services.Model
{
    public class WorkExperienceUpdateModel : UpdateModel
    {
        public Guid CollaboratorId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public Guid CompanyId { get; set; }
        public Guid JobTitleId { get; set; }
        public Guid JobLevelId { get; set; }
        public Guid LeaderId { get; set; }

    }
    
}
