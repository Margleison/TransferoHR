

using System.Linq.Expressions;
using TransferoHR.Domain.Entities;
using TransferoHR.Domain.Enums;
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
        public CompanyRepository(HRContext db) : base(db)
        {
        }


        public async Task<Company> GetByCNPJ(string cnpj, Guid? excId = null)
        {
            Expression<Func<Company, bool>> filter;
            if (excId == null)
                filter = x => x.CNPJ == cnpj && x.Status != EntityStatusEnum.Deleted;
            else
                filter = x => x.CNPJ == cnpj && x.Status != EntityStatusEnum.Deleted && x.Id != excId;

            return await FirstAsync(filter);
        }
    }
}
