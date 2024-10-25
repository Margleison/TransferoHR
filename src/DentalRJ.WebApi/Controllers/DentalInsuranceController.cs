using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Implementation;
using DentalRJ.Services.Model;
using DentalRJ.Services.Params;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentalRJ.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentalInsuranceController : GenericController<DentalInsurance, DentalInsuranceCreateModel, DentalInsuranceUpdateModel, DentalInsuranceGetModel, DentalInsuranceParams>
    {
        public DentalInsuranceController(DentalInsuranceService service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}
