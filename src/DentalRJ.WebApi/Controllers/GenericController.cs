using AutoMapper;
using DentalRJ.Domain.Entities.Base;
using DentalRJ.Services.Implementation;
using DentalRJ.Services.Model.Base;
using DentalRJ.Services.Params.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentalRJ.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<TEntity, TCreateModel, TUpdateModel, TGetModel, TParams> : ControllerBase, IGenericController<TEntity, TCreateModel, TUpdateModel, TGetModel, TParams>
      where TEntity : NamedBaseEntity
      where TCreateModel : class
      where TUpdateModel : class
      where TGetModel : NamedGetModel
      where TParams : NamedParams
    {
        protected readonly GenericService<TEntity, TParams, TGetModel> _service;
        private readonly IMapper _mapper;

        public GenericController(NamedBaseService<TEntity, TParams, TGetModel> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/{controller}
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TParams NamedParams)
        {
            var entities = await _service.GetAllAsync(NamedParams);
            return Ok(entities);
        }

        // GET: api/{controller}/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entity = await _service.GetById(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        // POST: api/{controller}
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TCreateModel createModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = await _service.Insert(createModel, "system");

            var dto = _mapper.Map<TGetModel>(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, dto);

        }

        // PUT: api/{controller}/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TUpdateModel updateModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.Update(id, updateModel, "system");
            return NoContent();
        }

        // DELETE: api/{controller}/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.Delete(id, "system");
            return NoContent();
        }
        [HttpPut("{id}/activate")]
        public async Task<IActionResult> Activate(Guid id)
        {
            await _service.Activate(id, "system");
            return NoContent();
        }
        [HttpPut("{id}/deactivate")]
        public async Task<IActionResult> Deactivate(Guid id)
        {
            await _service.Deactivate(id, "system");
            return NoContent();
        }
    }
}
