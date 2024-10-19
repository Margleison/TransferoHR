using DentalRJ.Domain.Entities;
using DentalRJ.Domain.Enums;
using DentalRJ.Infra.Database;
using DentalRJ.Infra.Repositories.Base;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Params;
using LinqKit;

namespace DentalRJ.Infra.Repositories
{
    public class DentistRepository : NamedBaseEntityRepository<Dentist, DentistParams>, INamedBaseEntityRepository<Dentist, DentistParams>
    {
        public DentistRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Dentist>> GetAllAsync(DentistParams param)
        {
            var predicate = PredicateBuilder.New<Dentist>(true);

            if (!string.IsNullOrEmpty(param.Name))
                predicate = predicate.And(x => x.Name.Contains(param.Name));

            if (!string.IsNullOrEmpty(param.CPF))
                predicate = predicate.And(x => x.CPF.Contains(param.CPF));

            if (!string.IsNullOrEmpty(param.CRO))
                predicate = predicate.And(x => x.CRO.Contains(param.CRO));

            if (!string.IsNullOrEmpty(param.Email))
                predicate = predicate.And(x => x.Email.Contains(param.Email));

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
