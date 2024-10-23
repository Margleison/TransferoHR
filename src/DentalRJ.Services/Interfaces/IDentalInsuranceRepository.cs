using DentalRJ.Domain.Entities;
using DentalRJ.Services.Params;

namespace DentalRJ.Services.Interfaces
{
    public interface IDentalInsuranceRepository : INamedBaseEntityRepository<DentalInsurance, DentalInsuranceParams>
    {
        Task<DentalInsurance>? GetByBrandName(string brandName, Guid? excId = null);
    }
}
