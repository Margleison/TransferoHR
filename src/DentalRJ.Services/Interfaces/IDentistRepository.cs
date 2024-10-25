using DentalRJ.Domain.Entities;
using DentalRJ.Services.Interfaces.Generic;
using DentalRJ.Services.Params;

namespace DentalRJ.Services.Interfaces
{
    public interface IDentistRepository : INamedEntityRepository<Dentist, DentistParams>
    {
        Task<Dentist>? GetByCRO(string CRO, Guid? excId);
        Task<Dentist>? GetByCPF(string CPF, Guid? excId);
        Task<Dentist>? GetByEmail(string email, Guid? excId);
    }
}
