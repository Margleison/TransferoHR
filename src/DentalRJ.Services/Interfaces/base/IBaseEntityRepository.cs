namespace DentalRJ.Services.Interfaces.Base;

public interface IBaseEntityRepository<TEntity>
{
    Task<TEntity>? GetAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity newEntity);
    Task UpdateAsync(TEntity toUpdate);
    Task DeleteAsync(Guid id);
    Task SaveChangesAsync();
}