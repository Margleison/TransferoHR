using DentalRJ.Domain.Entities;
using DentalRJ.Services.Params;

namespace DentalRJ.Services.Interfaces
{
    public interface IPatientRepository : INamedBaseEntityRepository<Patient, PatientParams>
    {
        Task<Patient>? GetByCPFAndBirthDate(string CPF, DateOnly BirthDate, Guid? excId);
    }
}
