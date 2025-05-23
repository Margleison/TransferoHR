﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransferoHR.Domain.Entities;
using TransferoHR.Services.Implementation;
using TransferoHR.Services.Model;
using TransferoHR.Services.Params;

namespace TransferoHR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkExperienceController : GenericController<WorkExperience, WorkExperienceCreateModel, WorkExperienceUpdateModel, WorkExperienceGetModel, WorkExperienceParams>
    {
        public WorkExperienceController(WorkExperienceService service, IMapper mapper) : base (service, mapper)
        {
        } 
      
    }
}
