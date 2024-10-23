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
    public class PatientRepository : NamedBaseEntityRepository<Patient, PatientParams>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Patient> GetByCPFAndBirthDate(string CPF, DateOnly birthDate,  Guid? excId = null)
        {
            Expression<Func<Patient, bool>> filter;
            if (excId == null)
                filter = x => x.CPF == CPF && x.BirthDate == birthDate && x.Status != EntityStatusEnum.Deleted;
            else
                filter = x => x.CPF == CPF && x.BirthDate == birthDate &&x.Status != EntityStatusEnum.Deleted && x.Id != excId;

            return await FirstAsync(filter);
        }
        public async Task<IEnumerable<Patient>> GetAllAsync(PatientParams param)
        {
            var predicate = PredicateBuilder.New<Patient>(true);

            if (!string.IsNullOrEmpty(param.Name))
                predicate = predicate.And(x => x.Name.Contains(param.Name));

            if (!string.IsNullOrEmpty(param.CPF))
                predicate = predicate.And(x => x.CPF.Contains(param.CPF));

            if (!string.IsNullOrEmpty(param.CityName))
                predicate = predicate.And(x => x.CityName.Contains(param.CityName));

            if (!string.IsNullOrEmpty(param.Email))
                predicate = predicate.And(x => x.Email.Contains(param.Email));

            if (!string.IsNullOrEmpty(param.PostalCode))
                predicate = predicate.And(x => x.PostalCode.Contains(param.PostalCode));

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
