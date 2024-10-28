using TransferoHR.Domain.Entities.Generic;
using TransferoHR.Services.Model.Generic;
using TransferoHR.Services.Params.Generic;
using Microsoft.AspNetCore.Mvc;


namespace TransferoHR.WebApi.Controllers
{

    public interface IGenericController<TEntity, TCreateModel, TUpdateModel, TGetModel, TParams>
        where TEntity : GenericNamedEntity
        where TCreateModel : class
        where TUpdateModel : class
        where TGetModel : NamedGetModel
        where TParams : NamedParams
    {
        Task<IActionResult> GetAll([FromQuery] TParams namedParams);
        Task<IActionResult> GetById(Guid id);
        Task<IActionResult> Create([FromBody] TCreateModel createModel);
        Task<IActionResult> Update(Guid id, [FromBody] TUpdateModel updateModel);
        Task<IActionResult> Delete(Guid id);
        Task<IActionResult> Activate(Guid id);
        Task<IActionResult> Deactivate(Guid id);
    }
}