using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransferoHR.Domain.Entities;
using TransferoHR.Services.Implementation;
using TransferoHR.Services.Model;
using TransferoHR.Services.Model.Generic;
using TransferoHR.Services.Params;
using TransferoHR.Services.Params.Generic;

namespace TransferoHR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobLevelController : GenericController<JobLevel, JobLevelCreateModel, JobLevelUpdateModel, JobLevelGetModel, JobLevelParams>
    {
        public JobLevelController(JobLevelService service, IMapper mapper) 
            : base(service, mapper)
        {
        }
    }
}

