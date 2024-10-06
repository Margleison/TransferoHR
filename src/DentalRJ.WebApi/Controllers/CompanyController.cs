using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Interfaces.Base;
using DentalRJ.Services.Model;
using Microsoft.AspNetCore.Mvc;

namespace DentalRJ.WebApi.Controllers
{
  [Route("api/[controller]")]
  public class CompanyController : GenericController<Company, CompanyCreateModel, CompanyUpdateModel>
  {
    public CompanyController(INamedBaseEntityRepository<Company> repository, IMapper mapper)
        : base(repository, mapper)
    {
    }
  }
}
