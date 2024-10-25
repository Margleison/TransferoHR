using System;

namespace DentalRJ.Services.Interfaces.Generic;

public interface IGenericEntityRepository<TEntity, TParams>
{
    Task<TEntity>? GetAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync(TParams param);
    Task AddAsync(TEntity newEntity);
    Task UpdateAsync(TEntity toUpdate);
    Task ChangeStatusAsync(TEntity toUpdate);
}