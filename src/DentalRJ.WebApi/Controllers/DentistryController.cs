using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Implementation;
using DentalRJ.Services.Model.Base;
using DentalRJ.Services.Model;
using DentalRJ.Services.Params;
using Microsoft.AspNetCore.Mvc;

namespace DentalRJ.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistryController : NamedController<Dentistry, CompanyCreateModel, NamedUpdateModel, NamedGetModel, NamedParams>
    {
        public DentistryController(DentistryService dentistryService, IMapper mapper)
            : base(dentistryService, mapper)
        {
        }
    }
}
