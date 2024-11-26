using AutoMapper;
using TransferoHR.Domain.Entities.Generic;
using TransferoHR.Services.Implementation;
using TransferoHR.Services.Model.Generic;
using TransferoHR.Services.Params.Generic;

using Microsoft.AspNetCore.Mvc;


namespace TransferoHR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericNamedController<TEntity, TCreateModel, TUpdateModel, TGetModel, TParams> : GenericController<TEntity, TCreateModel, TUpdateModel, TGetModel, TParams>
      where TEntity : GenericNamedEntity
      where TCreateModel : NamedCreateModel
      where TUpdateModel : NamedUpdateModel
      where TGetModel : NamedGetModel
      where TParams : NamedParams 
    {
        private readonly IMapper _mapper;

        public GenericNamedController(GenericNamedService<TEntity, TParams, TGetModel> service, IMapper mapper) : base(service, mapper)
        {
            _mapper = mapper;
        }
    }
}         