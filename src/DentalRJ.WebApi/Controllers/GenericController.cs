using AutoMapper;
using DentalRJ.Domain.Entities.Base;
using DentalRJ.Services.Implementation; // Para o serviço
using Microsoft.AspNetCore.Mvc;

namespace DentalRJ.WebApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class GenericController<T, TCreateModel, TUpdateModel, TGenericParams> : ControllerBase
      where T : NamedBaseEntity
      where TCreateModel : class
      where TUpdateModel : class
  {
    private readonly NamedBaseService<T> _service;
    private readonly IMapper _mapper;

    public GenericController(NamedBaseService<T> service, IMapper mapper)
    {
      _service = service;
      _mapper = mapper;
    }

    // GET: api/{controller}
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] TGenericParams param)
    {
      var entities = await _service.GetAllAsync(); // Use o método da service
      return Ok(entities);
    }

    // GET: api/{controller}/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
      var entity = await _service.GetById(id); // Use o método da service
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

      var entity = await _service.Insert(createModel, "system"); // Use a service para criar
      return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    // PUT: api/{controller}/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] TUpdateModel updateModel)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      await _service.Update(id, updateModel, "system"); // Use a service para atualizar
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
