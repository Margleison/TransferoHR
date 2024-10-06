using System.Linq.Expressions;
using DentalRJ.Domain.Entities;
using DentalRJ.Domain.Entities.Base;
using DentalRJ.Domain.Enums;
using DentalRJ.Infra.Database;
using DentalRJ.Services.Interfaces.Base;

namespace DentalRJ.Infra.Repositories.Base;

public class NamedBaseEntityRepository<TEntity> : BaseEntityRepository<TEntity>, INamedBaseEntityRepository<TEntity> where TEntity : NamedBaseEntity 
{
    public NamedBaseEntityRepository(ApplicationDbContext db) : base(db)
    {
    }

    public virtual Task<TEntity> GetByNameAndOwner(Guid ownerId, string name, Guid? excId = null)
    {
        return null;
    }

    public async Task<TEntity> GetByName(string name, Guid? excId = null)
    {
        Expression<Func<TEntity, bool>> filter;
        if (excId == null)
            filter = x => x.Name == name && x.Status != EntityStatusEnum.Deleted;
        else 
            filter = x => x.Name == name && x.Status != EntityStatusEnum.Deleted && x.Id != excId;
        
        return await FirstAsync(filter);
    }
}

