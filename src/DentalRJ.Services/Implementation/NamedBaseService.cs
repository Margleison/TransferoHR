using AutoMapper;
using DentalRJ.Domain.Entities.Base;
using DentalRJ.Domain.Enums;
using DentalRJ.Services.Exceptions;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Model.Base;
using DentalRJ.Services.Params;

namespace DentalRJ.Services.Implementation
{
    public class NamedBaseService<T, TNamedParams, TNamedGetModel>
        where T : NamedBaseEntity
        where TNamedParams : NamedParams
        where TNamedGetModel : NamedGetModel
    {
        protected readonly string _entityName;
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

        public virtual async Task Validate(T entity, Guid? exId)
        {
            ServiceException.When(await _repo.GetByName(entity.Name, exId) != null, $"{_entityName} name already exists. [Name={entity.Name}]");
        }

        public virtual async Task<T> Insert<TCreateModel>(TCreateModel createModel, string createdBy) where TCreateModel : class
        {
            var newEntity = _mapper.Map<TCreateModel, T>(createModel);
            newEntity.CreatedBy = createdBy;
            await Validate(newEntity, null);

            newEntity.Status = EntityStatusEnum.Active;
            newEntity.CreatedAt = DateTime.Now;
            newEntity.Id = Guid.NewGuid();
            await _repo.AddAsync(newEntity);
            return newEntity;
        }
        public async Task Update<TUpdateModel>(Guid id, TUpdateModel updateModel, string updateBy) where TUpdateModel : class
        {
            var obj = await Get(id);
            _mapper.Map(updateModel, obj);
            await Validate(obj, id);

            obj.UpdatedAt = DateTime.Now;
            obj.UpdatedBy = updateBy;
            await _repo.UpdateAsync(obj);
        }
        public async Task Activate(Guid id, string updateBy)
        {
            var obj = await Get(id);

            ServiceException.When(obj.Status == EntityStatusEnum.Active, $"{_entityName} already active. [Id={id}]");
            obj.Status = EntityStatusEnum.Active;
            obj.UpdatedAt = DateTime.Now;
            obj.UpdatedBy = updateBy;
            await _repo.ChangeStatusAsync(obj);
        }
        public async Task Deactivate(Guid id, string updateBy)
        {
            var obj = await Get(id);

            ServiceException.When(obj.Status == EntityStatusEnum.Inactive, $"{_entityName} already inactive. [Id={id}]");
            obj.Status = EntityStatusEnum.Inactive;
            obj.UpdatedAt = DateTime.Now;
            obj.UpdatedBy = updateBy;
            await _repo.ChangeStatusAsync(obj);
        }
        public async Task Delete(Guid id, string updateBy)
        {
            var obj = await Get(id);

            ServiceException.When(obj.Status == EntityStatusEnum.Deleted, $"{_entityName} already deleted. [Id={id}]");
            obj.Status = EntityStatusEnum.Deleted;
            obj.UpdatedAt = DateTime.Now;
            obj.UpdatedBy = updateBy;
            await _repo.ChangeStatusAsync(obj);
        }
        public async Task<IEnumerable<NamedGetModel>> GetAllAsync(TNamedParams param)
        {
            var entities = await _repo.GetAllAsync(param); // Obtenha as entidades do repositório
            return _mapper.Map<IEnumerable<TNamedGetModel>>(entities); // Mapeia a lista de entidades para NamedGetModel
        }
    }
}