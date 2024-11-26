using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferoHR.Services.Params.Generic;

namespace TransferoHR.Services.Params
{
    public class WorkExperienceParams : GenericParams
    {
        public Guid CollaboratorId { get; set; }
        public Guid CompanyId { get; set; }
    }
}
