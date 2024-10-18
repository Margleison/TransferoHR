using DentalRJ.Domain.Entities;
using DentalRJ.Infra.Database;
using DentalRJ.Infra.Repositories.Base;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Params;


namespace DentalRJ.Infra.Repositories
{
    public class DentistryRepository : NamedBaseEntityRepository<Dentistry, NamedParams>, INamedBaseEntityRepository<Dentistry, NamedParams>
    {
        public DentistryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
