using DentalRJ.Domain.Entities;
using DentalRJ.Domain.Enums;
using DentalRJ.Infra.Database;
using DentalRJ.Infra.Repositories.Base;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Params;
using LinqKit;
using System.Linq.Expressions;

namespace DentalRJ.Infra.Repositories
{
    public class DentistRepository : NamedBaseEntityRepository<Dentist, DentistParams>, IDentistRepository
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
        public async Task<Dentist> GetByCPF(string CPF, Guid? excId = null)
        {
            Expression<Func<Dentist, bool>> filter;
            if (excId == null)
                filter = x => x.CPF == CPF && x.Status != EntityStatusEnum.Deleted;
            else
                filter = x => x.CPF == CPF && x.Status != EntityStatusEnum.Deleted && x.Id != excId;

            return await FirstAsync(filter);
        }
        public async Task<Dentist> GetByEmail(string email, Guid? excId = null)
        {
            Expression<Func<Dentist, bool>> filter;
            if (excId == null)
                filter = x => x.Email == email && x.Status != EntityStatusEnum.Deleted;
            else
                filter = x => x.Email == email && x.Status != EntityStatusEnum.Deleted && x.Id != excId;

            return await FirstAsync(filter);
        }
        public async Task<Dentist> GetByCRO(string CRO, Guid? excId = null)
        {
            Expression<Func<Dentist, bool>> filter;
            if (excId == null)
                filter = x => x.CRO == CRO && x.Status != EntityStatusEnum.Deleted;
            else
                filter = x => x.CRO == CRO && x.Status != EntityStatusEnum.Deleted && x.Id != excId;

            return await FirstAsync(filter);
        }
    }
}
