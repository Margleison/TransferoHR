using DentalRJ.Domain.Entities;
using DentalRJ.Services.Interfaces.Generic;
using DentalRJ.Services.Params;

namespace DentalRJ.Services.Interfaces
{
    public interface IPatientRepository : INamedEntityRepository<Patient, PatientParams>
    {
        Task<Patient>? GetByCPFAndBirthDate(string CPF, DateOnly BirthDate, Guid? excId);
    }
}
