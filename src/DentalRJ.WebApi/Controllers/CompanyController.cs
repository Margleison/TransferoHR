using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Implementation;
using DentalRJ.Services.Model;
using DentalRJ.Services.Model.Base;
using DentalRJ.Services.Params;
using DentalRJ.Services.Params.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DentalRJ.WebApi.Controllers
{
    [Route("api/[controller]")]
  [ApiController]
  public class CompanyController : GenericController<Company, CompanyCreateModel, CompanyUpdateModel, CompanyGetModel, CompanyParams>
  {
    public CompanyController(CompanyService companyService, IMapper mapper)
        : base(companyService, mapper)
    {
    }
  }
}
