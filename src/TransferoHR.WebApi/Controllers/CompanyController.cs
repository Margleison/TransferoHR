using AutoMapper;
using TransferoHR.Domain.Entities;
using TransferoHR.Services.Implementation;
using TransferoHR.Services.Model;
using TransferoHR.Services.Model.Generic;
using TransferoHR.Services.Params;
using TransferoHR.Services.Params.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TransferoHR.WebApi.Controllers
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
