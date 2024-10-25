using DentalRJ.Domain.Entities;
using DentalRJ.Services.Interfaces.Generic;
using DentalRJ.Services.Params;

namespace DentalRJ.Services.Interfaces
{
    public interface IDentalInsuranceRepository : INamedEntityRepository<DentalInsurance, DentalInsuranceParams>
    {
        Task<DentalInsurance>? GetByBrandName(string brandName, Guid? excId = null);
    }
}
