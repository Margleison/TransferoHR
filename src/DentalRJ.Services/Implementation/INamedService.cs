using TransferoHR.Domain.Entities.Generic;
using TransferoHR.Services.Implementation;
using TransferoHR.Services.Model.Generic;
using TransferoHR.Services.Params.Generic;

public interface INamedService<T, TParams, TGetModel> : IGenericService<T, TParams, TGetModel>
      where T : GenericNamedEntity
      where TParams : NamedParams
      where TGetModel : NamedGetModel
{
    Task<T> GetByName(string name);
}