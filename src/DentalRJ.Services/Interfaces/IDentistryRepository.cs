using DentalRJ.Domain.Entities;
using DentalRJ.Services.Interfaces.Generic;
using DentalRJ.Services.Params;

namespace DentalRJ.Services.Interfaces
{
    public interface IDentistryRepository : INamedEntityRepository<Dentistry, DentistryParams>
    {
    }
}