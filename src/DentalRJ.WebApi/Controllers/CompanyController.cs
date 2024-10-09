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
  public class CompanyController : GenericController<Company, CompanyCreateModel, CompanyUpdateModel, NamedParams>
  {
    public CompanyController(CompanyService companyService, IMapper mapper)
        : base(companyService, mapper) // Passando o serviço em vez do repositório
    {
    }
  }
}
