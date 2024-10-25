using DentalRJ.Domain.Entities.Base;
using DentalRJ.Services.Implementation;
using DentalRJ.Services.Model.Base;
using DentalRJ.Services.Params.Generic;

public interface INamedService<T, TParams, TGetModel> : IGenericService<T, TParams, TGetModel>
      where T : NamedBaseEntity
      where TParams : NamedParams
      where TGetModel : NamedGetModel
{
    Task<T> GetByName(string name);
}