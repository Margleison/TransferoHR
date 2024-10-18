using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Implementation;
using DentalRJ.Services.Model.Base;
using DentalRJ.Services.Model;
using DentalRJ.Services.Params;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentalRJ.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistController : NamedController<Dentist, DentistCreateModel, DentistUpdateModel, DentistGetModel, DentistParams>
    {
        public DentistController(DentistService service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}
