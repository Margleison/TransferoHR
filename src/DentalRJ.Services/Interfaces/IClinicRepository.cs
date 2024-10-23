using DentalRJ.Domain.Entities;
using DentalRJ.Services.Params;


namespace DentalRJ.Services.Interfaces
{
    public interface IClinicRepository : INamedBaseEntityRepository<Clinic, ClinicParams>
    {
        Task<Clinic>? GetByTradeName(string tradeName, Guid? excId);
    }
}
