using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferoHR.Domain.Entities;
using TransferoHR.Services.Interfaces.Generic;
using TransferoHR.Services.Params;

namespace TransferoHR.Services.Interfaces
{
    public  interface IJobLevelRepository : IGenericNamedEntityRepository<JobLevel, JobLevelParams>
    {
    }
}