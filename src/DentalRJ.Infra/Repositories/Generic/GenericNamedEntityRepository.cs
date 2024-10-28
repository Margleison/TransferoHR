using System.Linq.Expressions;
using TransferoHR.Domain.Entities.Generic;
using TransferoHR.Domain.Enums;
using TransferoHR.Infra.Database;
using TransferoHR.Services.Interfaces.Generic;
using TransferoHR.Services.Params.Generic;
using LinqKit;

namespace TransferoHR.Infra.Repositories.Generic;

public class GenericNamedEntityRepository<TEntity, TNamedParams> : GenericEntityRepository<TEntity, GenericParams>, IGenericNamedEntityRepository<TEntity, TNamedParams> 
    where TEntity : GenericNamedEntity
    where TNamedParams : NamedParams
{
    public GenericNamedEntityRepository(HRContext db) : base(db)
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

    public async virtual Task<IEnumerable<TEntity>> GetAllAsync(TNamedParams param)
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

        return await ListAsync(predicate, param.PageNumber, param.PageSize);
    }

}