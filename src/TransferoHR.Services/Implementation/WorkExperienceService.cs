using AutoMapper;
using TransferoHR.Domain.Entities;
using TransferoHR.Services.Interfaces;
using TransferoHR.Services.Model;
using TransferoHR.Services.Params;

namespace TransferoHR.Services.Implementation
{
    public class WorkExperienceService : GenericNamedService<WorkExperience, WorkExperienceParams, WorkExperienceGetModel>
    {
        public WorkExperienceService(IMapper mapper, IWorkExperienceRepository repo) : base(mapper, repo, "Work Experience")
        {
        }
    } 
    
}
