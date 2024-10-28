

using TransferoHR.Domain.Entities;
using TransferoHR.Infra.Database;
using TransferoHR.Infra.Repositories.Generic;
using TransferoHR.Services.Interfaces;
using TransferoHR.Services.Interfaces.Generic;
using TransferoHR.Services.Params;
using TransferoHR.Services.Params.Generic;

namespace TransferoHR.Infra.Repositories
{
    public class CompanyRepository : GenericNamedEntityRepository<Company, CompanyParams>, ICompanyRepository
    {
        public CompanyRepository(HRContext context) : base(context)
        {
        }
    }
}
