using Microsoft.EntityFrameworkCore;
using TransferoHR.Domain.Entities;
using TransferoHR.Infra.Database;
using TransferoHR.Infra.Repositories.Generic;
using TransferoHR.Services.Interfaces;
using TransferoHR.Services.Params;
using System.Linq.Expressions;
using System.Data.Entity;

namespace TransferoHR.Infra.Repositories
{

    public class WorkExperienceRepository : GenericEntityRepository<WorkExperience, WorkExperienceParams>, IWorkExperienceRepository
    {
        public WorkExperienceRepository(HRContext db) : base(db)
        {
 
        }


        public async Task<bool> Exists(Guid companyId, Guid collaboratorId, Guid jobLevelId, Guid jobTitleId)
        {
            return await Context.WorkExperience.AnyAsync(w => w.CompanyId == companyId
                && w.CollaboratorId == collaboratorId
                && w.JobLevelId == jobLevelId
                && w.JobTitleId == jobTitleId
                );
        }
    }
}
