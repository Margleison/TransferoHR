using DentalRJ.Domain.Entities;
using DentalRJ.Infra.Database;
using DentalRJ.Infra.Repositories.Base;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Params;

namespace DentalRJ.Infra.implementation
{
    public class CompanyRepository : NamedBaseEntityRepository<Company, NamedParams>, INamedBaseEntityRepository<Company, NamedParams>
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
