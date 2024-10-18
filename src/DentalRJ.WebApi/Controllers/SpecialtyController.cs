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
    public class SpecialtyController : NamedController<Specialty, CompanyCreateModel, NamedUpdateModel, NamedGetModel, NamedParams>
    {
        public SpecialtyController(SpecialtyService specialtyService, IMapper mapper)
            : base(specialtyService, mapper)
        {
        }
    }
}
