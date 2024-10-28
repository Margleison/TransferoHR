using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferoHR.Domain.Entities;
using TransferoHR.Domain.Entities.Generic;
using TransferoHR.Infra.Database;
using TransferoHR.Infra.Repositories.Generic;
using TransferoHR.Services.Interfaces;
using TransferoHR.Services.Interfaces.Generic;
using TransferoHR.Services.Params;
using TransferoHR.Services.Params.Generic;

namespace TransferoHR.Infra.Repositories
{
    public class JobLevelRepository : GenericNamedEntityRepository<JobLevel, JobLevelParams>, IJobLevelRepository
    {
        public JobLevelRepository(HRContext db) : base(db) 
        {
        }
    }
}
