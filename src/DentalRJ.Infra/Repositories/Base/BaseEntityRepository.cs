using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using DentalRJ.Domain.Entities.Base;
using DentalRJ.Domain.Enums;
using DentalRJ.Infra.Database;
using DentalRJ.Services.Interfaces.Base;

namespace DentalRJ.Infra.Repositories.Base;

public class BaseEntityRepository<TEntity> : IBaseEntityRepository<TEntity> where TEntity : BaseEntity
{
    protected ApplicationDbContext Context;

    public BaseEntityRepository(ApplicationDbContext db)
    {
        Context = db;
    }

    protected async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> filter) =>
        await Context.Set<TEntity>().FirstOrDefaultAsync(filter);

    protected async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter) =>
        await Context.Set<TEntity>().Where(filter).ToListAsync();
    
    public async Task<TEntity> GetAsync(Guid id) => 
        await FirstAsync(x => x.Id == id && x.Status != EntityStatusEnum.Deleted);

    public async Task<IEnumerable<TEntity>> GetAllAsync() =>
        await ListAsync(x => x.Status != EntityStatusEnum.Deleted);

    public async Task AddAsync(TEntity newEntity)
    {
        Context.Set<TEntity>().Add(newEntity);
        await Context.SaveChangesAsync();
    }

    public async Task Update(TEntity toUpdate)
    {
        Context.Entry(toUpdate).State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }

    public Task UpdateAsync(TEntity toUpdate)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}