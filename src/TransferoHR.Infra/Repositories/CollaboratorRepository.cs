using System.Linq.Expressions;
using TransferoHR.Domain.Entities;
using TransferoHR.Domain.Enums;
using TransferoHR.Infra.Database;
using TransferoHR.Infra.Repositories.Generic;
using TransferoHR.Services.Interfaces;
using TransferoHR.Services.Params;

namespace TransferoHR.Infra.Repositories
{
    public class CollaboratorRepository : GenericNamedEntityRepository<Collaborator, CollaboratorParams>, ICollaboratorRepository
    {
        public CollaboratorRepository(HRContext db) : base(db)
        {
        }

        public async Task<Collaborator> GetByCPFandRG(string cpf, string rg, Guid? excId = null)
        {
            Expression<Func<Collaborator, bool>> filter;
            if (excId == null)
            {
                filter = x => (x.CPF == cpf || x.RG == rg) && x.Status != EntityStatusEnum.Deleted;
            }
            else
                filter = x => (x.CPF == cpf || x.RG == rg) && x.Status != EntityStatusEnum.Deleted && x.Id != excId;

            return await FirstAsync(filter);
        }  
    }
}
