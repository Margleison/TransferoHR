using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TransferoHR.Domain.Entities.Generic;
using TransferoHR.Domain.Enums;
using TransferoHR.Infra.Database;
using TransferoHR.Services.Params.Generic;
using TransferoHR.Services.Interfaces.Generic;

namespace TransferoHR.Infra.Repositories.Generic;

public class GenericEntityRepository<TEntity, TParams> : IGenericEntityRepository<TEntity, TParams> 
    where TEntity : GenericEntity 
    where TParams: GenericParams
{
    protected HRContext Context;
    public  Func<IQueryable<TEntity>, IQueryable<TEntity>>? _include = null;

    public GenericEntityRepository(HRContext db)
    {
        Context = db;
        _include = null;
    }

    public async Task<TEntity> GetAsync(Guid id)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();

        if (_include != null)
            query = _include(query);

        return await query.FirstOrDefaultAsync(x => x.Id == id && x.Status != EntityStatusEnum.Deleted);
    }

    public async virtual Task<IEnumerable<TEntity>> GetAllAsync(TParams param) {
        Expression<Func<TEntity, bool>> filter ;

        if (!string.IsNullOrEmpty(param.Status))
        {
            filter = x => x.Status.ToString() == param.Status;
        } else {
            filter = x => x.Status != EntityStatusEnum.Deleted;
        }

        return await ListAsync(filter, param.PageNumber, param.PageSize);
    }

    protected async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter, int pageNumber, int pageSize)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();
        query = query.Where(filter);

        if (_include != null)
            query = _include(query);

        return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    protected async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> filter) {

        IQueryable<TEntity> query = Context.Set<TEntity>();
        query = query.Where(filter);

        if (_include != null)
            query = _include(query);

        return await query.FirstOrDefaultAsync();
    }

    
    public async Task AddAsync(TEntity newEntity)
    {
        newEntity.Validate();
        Context.Set<TEntity>().Add(newEntity);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity toUpdate)
    {
        toUpdate.Validate();
        Context.Entry(toUpdate).State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }
    public async Task ChangeStatusAsync(TEntity toUpdate)
    {
        Context.Entry(toUpdate).State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }


}