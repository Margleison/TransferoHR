using TransferoHR.Domain.Entities.Generic;
using TransferoHR.Domain.Entities.Generic;
using TransferoHR.Services.Params.Generic;


namespace TransferoHR.Services.Interfaces.Generic;

public interface IGenericNamedEntityRepository<T, TParams> : IGenericEntityRepository<T, TParams>
    where T : GenericNamedEntity
    where TParams : NamedParams
{
    Task<T>? GetByName(string name, Guid? excId);
    Task<T>? GetByNameAndOwner(Guid ownerId, string name, Guid? excId);
}