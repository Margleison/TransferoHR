using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferoHR.Domain.Entities;
using TransferoHR.Infra.Database;
using TransferoHR.Infra.Repositories.Generic;
using TransferoHR.Services.Interfaces;
using TransferoHR.Services.Params;

namespace TransferoHR.Infra.Repositories
{
    public class JobTitleRepository : GenericNamedEntityRepository<JobTitle, JobTitleParams>, IJobTitleRepository
    {
        public JobTitleRepository(HRContext db) : base(db)
        {
        }
    }
}