using TransferoHR.Domain.Entities.Generic;
using TransferoHR.Services.Model.Generic;
using TransferoHR.Services.Params.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferoHR.Services.Implementation
{
    public interface IGenericService<T, TParams, TGetModel>
       where T : GenericEntity
       where TParams : GenericParams
       where TGetModel : GetModel
    {
        Task<TGetModel> GetById(Guid id);
        Task<T> Insert<TCreateModel>(TCreateModel createModel, string createdBy) where TCreateModel : class;
        Task Update<TUpdateModel>(Guid id, TUpdateModel updateModel, string updatedBy) where TUpdateModel : class;
        Task Activate(Guid id, string updatedBy);
        Task Deactivate(Guid id, string updatedBy);
        Task Delete(Guid id, string updatedBy);
        Task<IEnumerable<TGetModel>> GetAllAsync(TParams param);
        Task Validate(T entity, Guid? exId);
    }
}
