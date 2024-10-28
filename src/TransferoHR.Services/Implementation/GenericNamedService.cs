using AutoMapper;
using TransferoHR.Domain.Entities.Generic;
using TransferoHR.Domain.Enums;
using TransferoHR.Services.Exceptions;
using TransferoHR.Services.Interfaces.Generic;
using TransferoHR.Services.Model.Generic;
using TransferoHR.Services.Params.Generic;

namespace TransferoHR.Services.Implementation
{
    public class GenericNamedService<T, TParams, TGetModel>: GenericService<T, TParams, TGetModel>, INamedService<T, TParams, TGetModel>
        where T : GenericNamedEntity
        where TParams: NamedParams
        where TGetModel: NamedGetModel
    {
        protected readonly IGenericNamedEntityRepository<T, TParams> _repo;

        public GenericNamedService(IMapper mapper, IGenericNamedEntityRepository<T, TParams> repo, string entityName)
            : base(mapper, repo, entityName)
        {
            _repo = repo;
        }
        public async Task<T> GetByName(string name)
            => await _repo.GetByName(name, null);

        public override async Task Validate(T entity, Guid? exId)
        {
            ServiceException.When(await _repo.GetByName(entity.Name, exId) != null, $"{_entityName} name already exists. [Name={entity.Name}]");
        }
    }
}