using DentalRJ.Domain.Entities;
using DentalRJ.Domain.Enums;
using DentalRJ.Infra.Database;
using DentalRJ.Infra.Repositories.Base;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Params;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalRJ.Infra.Repositories
{
    public class DentalInsuranceRepository : NamedBaseEntityRepository<DentalInsurance, DentalInsuranceParams>, INamedBaseEntityRepository<DentalInsurance, DentalInsuranceParams>
    {
        public DentalInsuranceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<DentalInsurance>> GetAllAsync(DentalInsuranceParams param)
        {
            var predicate = PredicateBuilder.New<DentalInsurance>(true);

            if (!string.IsNullOrEmpty(param.Name))
                predicate = predicate.And(x => x.Name.Contains(param.Name));

            if (!string.IsNullOrEmpty(param.BrandName))
                predicate = predicate.And(x => x.BrandName.Contains(param.BrandName));

            if (param.HasReimbursement.HasValue)
                predicate = predicate.And(x => x.HasReimbursement == param.HasReimbursement);

            if (param.NeedAuthorization.HasValue)
                predicate = predicate.And(x => x.NeedAuthorization == param.NeedAuthorization);

            if (param.HasCoPaymentPercentage.HasValue)
            {
                if ((bool) param.HasCoPaymentPercentage) {
                    predicate = predicate.And(x => x.CoPaymentPercentage != 0);
                } else
                    predicate = predicate.And(x => x.CoPaymentPercentage == 0);
            }
                

            if (!string.IsNullOrEmpty(param.Status))
            {
                Enum.TryParse(param.Status, out EntityStatusEnum status);
                predicate = predicate.And(x => x.Status == status);
            }
            else
                predicate = predicate.And(x => x.Status != EntityStatusEnum.Inactive);

            return await ListAsync(predicate, param.PageNumber, param.PageSize);
        }
    }
}
