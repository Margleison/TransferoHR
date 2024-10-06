using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Domain.Entities.Base;
using DentalRJ.Domain.Enums;
using DentalRJ.Services.Interfaces.Base;
using DentalRJ.Services.Exceptions;

namespace DentalRJ.Services.Implementation
{
    public class NamedBaseService<T> where T : NamedBaseEntity
    {
        private readonly string _entityName;
        protected readonly INamedBaseEntityRepository<T> _repo; 
        protected readonly IMapper _mapper;

        public NamedBaseService(IMapper mapper, INamedBaseEntityRepository<T> repo, string entityName)
        {
            _repo = repo;
            _mapper = mapper;
            _entityName = entityName;
        }

        private async Task<T> Get(Guid id)
        {
            var obj = await _repo.GetAsync(id);
            if (obj == null) 
                ServiceException.When(true, $"{_entityName} does not exist. [Id={id}]");

            return obj;
        }

        public async Task<T> GetByName(string name) 
            => await _repo.GetByName(name, null);

        public virtual async Task<T> Insert<TCreateModel>(TCreateModel createModel, string CreatedBy) where TCreateModel : class
        {
            var nameProperty = typeof(TCreateModel).GetProperty("Name")?.GetValue(createModel, null)?.ToString();
            ServiceException.When(await _repo.GetByName(nameProperty, null) != null, $"{_entityName} name already exists. [Name={nameProperty}]");
            
            var newEntity = _mapper.Map<TCreateModel, T>(createModel);
            newEntity.Status = EntityStatusEnum.Active;
            newEntity.CreatedAt = DateTime.Now;
            newEntity.CreatedBy = CreatedBy;
            newEntity.Id = Guid.NewGuid();
            await _repo.AddAsync(newEntity);

            return newEntity;
        }

        public async Task Update<TUpdateModel>(TUpdateModel updateModel, string AtualizadoPor) where TUpdateModel : class
        {
            var idProperty = typeof(TUpdateModel).GetProperty("Id")?.GetValue(updateModel);
            var obj = await Get((Guid)idProperty);
            
            var nameProperty = typeof(TUpdateModel).GetProperty("Name")?.GetValue(updateModel, null)?.ToString();
            ServiceException.When(await _repo.GetByName(nameProperty, (Guid)idProperty) != null, $"{_entityName} name already exists. [Name={nameProperty}]");
            
            _mapper.Map(updateModel, obj);
            obj.UpdatedAt = DateTime.Now;
            obj.UpdatedBy = AtualizadoPor;
            await _repo.UpdateAsync(obj);
        }

        public async Task Activate(Guid id, string AtualizadoPor)
        {
            var obj = await Get(id);
            
            ServiceException.When(obj.Status == EntityStatusEnum.Active, $"{_entityName} already active. [Id={id}]");
            obj.Status = EntityStatusEnum.Active;
            obj.UpdatedAt = DateTime.Now;
            obj.UpdatedBy = AtualizadoPor;
            await _repo.UpdateAsync(obj);
        }

        public async Task Deactivate(Guid id, string AtualizadoPor)
        {
            var obj = await Get(id);
            
            ServiceException.When(obj.Status == EntityStatusEnum.Inactive, $"{_entityName} already inactive. [Id={id}]");
            obj.Status = EntityStatusEnum.Inactive;
            obj.UpdatedAt = DateTime.Now;
            obj.UpdatedBy = AtualizadoPor;
            await _repo.UpdateAsync(obj);
        }

        public async Task Delete(Guid id, string AtualizadoPor)
        {
            var obj = await Get(id);
            
            ServiceException.When(obj.Status == EntityStatusEnum.Deleted, $"{_entityName} already deleted. [Id={id}]");
            obj.Status = EntityStatusEnum.Deleted;
            obj.UpdatedAt = DateTime.Now;
            obj.UpdatedBy = AtualizadoPor;
            await _repo.UpdateAsync(obj);
        }
    }
}