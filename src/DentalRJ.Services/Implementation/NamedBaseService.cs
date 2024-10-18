using AutoMapper;
using DentalRJ.Domain.Entities.Base;
using DentalRJ.Domain.Enums;
using DentalRJ.Services.Exceptions;
using DentalRJ.Services.Model.Base;
using DentalRJ.Services.Params;
using DentalRJ.Services.Interfaces;

namespace DentalRJ.Services.Implementation
{
    public class NamedBaseService<T, TNamedParams, TNamedGetModel> 
        where T : NamedBaseEntity 
        where TNamedParams : NamedParams
        where TNamedGetModel : NamedGetModel
    {
        private readonly string _entityName;
        protected readonly INamedBaseEntityRepository<T, TNamedParams> _repo; 
        protected readonly IMapper _mapper;

        public NamedBaseService(IMapper mapper, INamedBaseEntityRepository<T, TNamedParams> repo, string entityName)
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
        public async Task<TNamedGetModel> GetById(Guid id)
        {
            var entity = await Get(id); 
            return _mapper.Map<TNamedGetModel>(entity);
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
        public async Task Update<TUpdateModel>(Guid id, TUpdateModel updateModel, string AtualizadoPor) where TUpdateModel : class
        {
            var obj = await Get(id);
            
            var nameProperty = typeof(TUpdateModel).GetProperty("Name")?.GetValue(updateModel, null)?.ToString();
            ServiceException.When(await _repo.GetByName(nameProperty, id) != null, $"{_entityName} name already exists. [Name={nameProperty}]");
            
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
            await _repo.ChangeStatusAsync(obj);
        }
        public async Task Deactivate(Guid id, string AtualizadoPor)
        {
            var obj = await Get(id);
            
            ServiceException.When(obj.Status == EntityStatusEnum.Inactive, $"{_entityName} already inactive. [Id={id}]");
            obj.Status = EntityStatusEnum.Inactive;
            obj.UpdatedAt = DateTime.Now;
            obj.UpdatedBy = AtualizadoPor;
            await _repo.ChangeStatusAsync(obj);
        }
        public async Task Delete(Guid id, string AtualizadoPor)
        {
            var obj = await Get(id);
            
            ServiceException.When(obj.Status == EntityStatusEnum.Deleted, $"{_entityName} already deleted. [Id={id}]");
            obj.Status = EntityStatusEnum.Deleted;
            obj.UpdatedAt = DateTime.Now;
            obj.UpdatedBy = AtualizadoPor;
            await _repo.ChangeStatusAsync(obj);
        }
        public async Task<IEnumerable<NamedGetModel>> GetAllAsync(TNamedParams param)
        {
            var entities = await _repo.GetAllAsync(param); // Obtenha as entidades do repositório
            return _mapper.Map<IEnumerable<TNamedGetModel>>(entities); // Mapeia a lista de entidades para NamedGetModel
        }
    }
}