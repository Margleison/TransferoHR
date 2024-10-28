using AutoMapper;
using TransferoHR.Domain.Entities.Generic;
using TransferoHR.Domain.Enums;
using TransferoHR.Services.Exceptions;
using TransferoHR.Services.Interfaces.Generic;
using TransferoHR.Services.Model.Generic;
using TransferoHR.Services.Params.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferoHR.Services.Implementation
{
    public class GenericService<T, TParams, TGetModel>: IGenericService<T, TParams, TGetModel>
        where T : GenericEntity
        where TParams : GenericParams
        where TGetModel : GetModel
    {
        protected readonly string _entityName;
        protected readonly IGenericEntityRepository<T, TParams> _repo;
        protected readonly IMapper _mapper;
        private IMapper mapper;
        private IGenericEntityRepository<GenericNamedEntity, TParams> repo;
        private string entityName;

        public GenericService(IMapper mapper, IGenericEntityRepository<T, TParams> repo, string entityName)
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
        public async Task<TGetModel> GetById(Guid id)
        {
            var entity = await Get(id);
            return _mapper.Map<TGetModel>(entity);
        }

        public virtual async Task Validate(T entity, Guid? exId)
        {
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
        public async Task<IEnumerable<TGetModel>> GetAllAsync(TParams param)
        {
            var entities = await _repo.GetAllAsync(param); // Obtenha as entidades do repositório
            return _mapper.Map<IEnumerable<TGetModel>>(entities); // Mapeia a lista de entidades para NamedGetModel
        }
    }
}