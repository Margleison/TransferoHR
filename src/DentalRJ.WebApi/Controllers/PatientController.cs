using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Implementation;
using DentalRJ.Services.Model;
using DentalRJ.Services.Params;
using Microsoft.AspNetCore.Mvc;

namespace DentalRJ.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : NamedController<Patient, PatientCreateModel, PatientUpdateModel, PatientGetModel, PatientParams>
    {
        public PatientController(PatientService service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}
