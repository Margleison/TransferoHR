using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Implementation;
using DentalRJ.Services.Model;
using DentalRJ.Services.Model.Base;
using DentalRJ.Services.Params;
using Microsoft.AspNetCore.Mvc;

namespace DentalRJ.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : NamedController<Clinic, ClinicCreateModel,  ClinicUpdateModel, ClinicGetModel, ClinicParams>
    {
        public ClinicController(ClinicService clinicService, IMapper mapper)
            : base(clinicService, mapper)
        {
        }
    }
}
