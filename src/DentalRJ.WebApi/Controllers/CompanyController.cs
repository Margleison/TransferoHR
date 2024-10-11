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
  public class CompanyController : NamedController<Company, CompanyCreateModel, NamedUpdateModel, NamedGetModel, NamedParams>
  {
    public CompanyController(CompanyService companyService, IMapper mapper)
        : base(companyService, mapper)
    {
    }
  }
}
