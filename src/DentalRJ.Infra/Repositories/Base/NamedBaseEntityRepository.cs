using System.Linq.Expressions;
using DentalRJ.Domain.Entities.Base;
using DentalRJ.Domain.Enums;
using DentalRJ.Infra.Database;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Params;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace DentalRJ.Infra.Repositories.Base;

public class NamedBaseEntityRepository<TEntity, TNamedParams> : BaseEntityRepository<TEntity, GenericParams>, INamedBaseEntityRepository<TEntity, TNamedParams> 
    where TEntity : NamedBaseEntity
    where TNamedParams : NamedParams
{
    public NamedBaseEntityRepository(ApplicationDbContext db) : base(db)
    {
        _include = null;
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

    public async  Task<IEnumerable<TEntity>> GetAllAsync(TNamedParams param)
    {
        var predicate = PredicateBuilder.New<TEntity>(true);

        if (!string.IsNullOrEmpty(param.Name))
            predicate = predicate.And(x => x.Name.Contains(param.Name));

        if (!string.IsNullOrEmpty(param.Status))
        {
            Enum.TryParse(param.Status, out EntityStatusEnum status);
            predicate = predicate.And(x => x.Status == status);
        }
            
        else
            predicate = predicate.And(x => x.Status != EntityStatusEnum.Inactive);

        return await ListAsync(predicate);
    }

}