using AutoMapper;
using TransferoHR.Domain.Entities;
using TransferoHR.Services.Interfaces;
using TransferoHR.Services.Interfaces.Generic;
using TransferoHR.Services.Model;
using TransferoHR.Services.Model.Generic;
using TransferoHR.Services.Params;
using TransferoHR.Services.Params.Generic;

namespace TransferoHR.Services.Implementation
{
    public class JobLevelService : GenericNamedService<JobLevel, JobLevelParams, JobLevelGetModel>
    {
        public JobLevelService(IMapper mapper, IJobLevelRepository repo) : base(mapper, repo, "Job Level")
        {
        }
    }
}
