using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using DentalRJ.Domain.Entities.Base;
using DentalRJ.Domain.Enums;
using DentalRJ.Infra.Database;
using DentalRJ.Services.Params;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices.Marshalling;
using DentalRJ.Services.Interfaces;

namespace DentalRJ.Infra.Repositories.Base;

public class BaseEntityRepository<TEntity, TParams> : IBaseEntityRepository<TEntity, TParams> where TEntity : BaseEntity where TParams: GenericParams
{
    protected ApplicationDbContext Context;
    public  Func<IQueryable<TEntity>, IQueryable<TEntity>>? _include = null;

    public BaseEntityRepository(ApplicationDbContext db)
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

        return await ListAsync(filter);
    }

    protected async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();
        query = query.Where(filter);

        if (_include != null)
            query = _include(query);

        return await query.ToListAsync();
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
        Context.Set<TEntity>().Add(newEntity);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity toUpdate)
    {
        Context.Entry(toUpdate).State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }
}