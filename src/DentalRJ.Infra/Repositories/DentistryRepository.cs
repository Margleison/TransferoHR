using DentalRJ.Domain.Entities;
using DentalRJ.Infra.Database;
using DentalRJ.Infra.Repositories.Base;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Interfaces.Generic;
using DentalRJ.Services.Params;
using DentalRJ.Services.Params.Generic;


namespace DentalRJ.Infra.Repositories
{
    public class DentistryRepository : NamedEntityRepository<Dentistry, DentistryParams>, IDentistryRepository
    {
        public DentistryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
