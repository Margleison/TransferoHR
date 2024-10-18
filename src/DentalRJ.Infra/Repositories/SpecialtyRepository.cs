using DentalRJ.Domain.Entities;
using DentalRJ.Infra.Database;
using DentalRJ.Infra.Repositories.Base;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Params;


namespace DentalRJ.Infra.Repositories
{
    public class SpecialtyRepository: NamedBaseEntityRepository<Specialty, NamedParams>, INamedBaseEntityRepository<Specialty, NamedParams>
    {
        public SpecialtyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
