using AutoMapper;
using TransferoHR.Domain.Entities;
using TransferoHR.Services.Interfaces;
using TransferoHR.Services.Model;
using TransferoHR.Services.Params;

namespace TransferoHR.Services.Implementation
{
    public class JobTitleService : GenericNamedService<JobTitle, JobTitleParams, JobTitleGetModel>
    {
        public JobTitleService(IMapper mapper, IJobTitleRepository repo) : base(mapper, repo, "Job Title")
        {
        }
    }
}