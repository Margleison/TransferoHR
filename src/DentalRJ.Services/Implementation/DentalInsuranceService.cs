using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Exceptions;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Model;
using DentalRJ.Services.Params;

namespace DentalRJ.Services.Implementation
{
    public class DentalInsuranceService : NamedBaseService<DentalInsurance, DentalInsuranceParams, DentalInsuranceGetModel>
    {
        private readonly IDentalInsuranceRepository _repo; 
        public DentalInsuranceService(IMapper mapper, IDentalInsuranceRepository repo)
            : base(mapper, repo, "Dental Insurance")
        {
            _repo = repo;
        }
        public override async Task Validate(DentalInsurance entity, Guid? exId=null)
        {
            ServiceException.When(await _repo.GetByName(entity.Name, exId) != null, $"There is already a {_entityName} with that name. [Id='{entity.Name}']");
            ServiceException.When(await _repo.GetByBrandName(entity.BrandName, exId) != null, $"There is already a {_entityName} with that brand name. [Id='{entity.BrandName}']");
        }
    }
}
