using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferoHR.Services.Model.Generic;

namespace TransferoHR.Services.Model
{
    public class WorkExperienceCreateModel : CreateModel
    {   
        public Guid CollaboratorId { get; set; }
        public DateOnly StartDate { get; set; }
        public Guid CompanyId { get; set; }
        public Guid JobTitleId { get; set; }
        public Guid JobLevelId { get; set; }
        public Guid LeaderId { get; set; }
    }
}
