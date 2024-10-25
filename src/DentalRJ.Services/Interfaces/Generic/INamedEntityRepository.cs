using DentalRJ.Domain.Entities.Base;
using DentalRJ.Services.Params.Generic;


namespace DentalRJ.Services.Interfaces.Generic;

public interface INamedEntityRepository<T, TParams> : IGenericEntityRepository<T, TParams>
    where T : NamedBaseEntity
    where TParams : NamedParams
{
    Task<T>? GetByName(string name, Guid? excId);
    Task<T>? GetByNameAndOwner(Guid ownerId, string name, Guid? excId);
}