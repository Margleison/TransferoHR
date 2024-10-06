using DentalRJ.Domain.Entities.Base;

namespace DentalRJ.Services.Interfaces.Base;

public interface INamedBaseEntityRepository<TEntity>: IBaseEntityRepository<TEntity> where TEntity : NamedBaseEntity
{
    Task<TEntity>? GetByName(string name,  Guid? excId);
    Task<TEntity>? GetByNameAndOwner(Guid ownerId, string name,  Guid? excId);
}