using DentalRJ.Domain.Entities.Base;
using DentalRJ.Services.Params;

namespace DentalRJ.Services.Interfaces;

public interface INamedBaseEntityRepository<TEntity, TNamedParams> : IBaseEntityRepository<TEntity, TNamedParams> 
    where TEntity : NamedBaseEntity 
    where TNamedParams : NamedParams
{
    Task<TEntity>? GetByName(string name, Guid? excId);
    Task<TEntity>? GetByNameAndOwner(Guid ownerId, string name, Guid? excId);
}