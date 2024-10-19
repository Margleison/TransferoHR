using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Model;
using DentalRJ.Services.Params;

namespace DentalRJ.Services.Implementation
{
    public class DentalInsuranceService : NamedBaseService<DentalInsurance, DentalInsuranceParams, DentalInsuranceGetModel>
    {
        public DentalInsuranceService(IMapper mapper, INamedBaseEntityRepository<DentalInsurance, DentalInsuranceParams> repo)
            : base(mapper, repo, "Dental Insurance")
        {
        }
    }
}
