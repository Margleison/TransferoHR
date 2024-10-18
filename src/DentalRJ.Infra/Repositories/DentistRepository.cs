using DentalRJ.Domain.Entities;
using DentalRJ.Infra.Database;
using DentalRJ.Infra.Repositories.Base;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Params;

namespace DentalRJ.Infra.Repositories
{
    public class DentistRepository : NamedBaseEntityRepository<Dentist, DentistParams>, INamedBaseEntityRepository<Dentist, DentistParams>
    {
        public DentistRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
