using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Implementation;
using DentalRJ.Services.Model.Base;
using DentalRJ.Services.Model;
using Microsoft.AspNetCore.Mvc;
using DentalRJ.Services.Params.Generic;
using DentalRJ.Services.Params;

namespace DentalRJ.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistryController : GenericController<Dentistry, DentistryCreateModel, DentistryUpdateModel, DentistryGetModel, DentistryParams>
    {
        public DentistryController(DentistryService dentistryService, IMapper mapper)
            : base(dentistryService, mapper)
        {
        }
    }
}
