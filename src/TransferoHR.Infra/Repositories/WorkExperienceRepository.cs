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
    public class WorkExperienceRepository : GenericNamedEntityRepository<WorkExperience, WorkExperienceParams>, IWorkExperienceRepository
    {
        public WorkExperienceRepository(HRContext db) : base(db)
        {
        }
    }
}