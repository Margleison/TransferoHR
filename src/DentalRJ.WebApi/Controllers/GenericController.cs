using AutoMapper;
using DentalRJ.Domain.Entities.Base; // Supondo que você tenha uma classe base
using DentalRJ.Services.Interfaces.Base; // Para o repositório
using Microsoft.AspNetCore.Mvc;

namespace DentalRJ.WebApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class GenericController<T, TCreateModel, TUpdateModel> : ControllerBase
      where T : NamedBaseEntity // Altere conforme necessário
      where TCreateModel : class // Para o modelo de criação
      where TUpdateModel : class // Para o modelo de atualização
  {
    private readonly INamedBaseEntityRepository<T> _repository;
    private readonly IMapper _mapper;

    public GenericController(INamedBaseEntityRepository<T> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    // GET: api/{controller}
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var entities = await _repository.GetAllAsync();
      return Ok(entities);
    }

    // GET: api/{controller}/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
      var entity = await _repository.GetAsync(id);
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

      var entity = _mapper.Map<T>(createModel);
      await _repository.AddAsync(entity);
      return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    // PUT: api/{controller}/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] TUpdateModel updateModel)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var entity = await _repository.GetAsync(id);
      if (entity == null)
        return NotFound();

      _mapper.Map(updateModel, entity);
      await _repository.UpdateAsync(entity);
      return NoContent();
    }


/*
    // DELETE: api/{controller}/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
      var entity = await _repository.GetAsync(id);
      if (entity == null)
        return NotFound();

      await _repository.DeleteAsync(entity);
      return NoContent();
    }
  }
  */
  }
}
