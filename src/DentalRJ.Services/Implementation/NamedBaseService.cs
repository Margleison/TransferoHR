using AutoMapper;
using DentalRJ.Domain.Entities.Base;
using DentalRJ.Domain.Enums;
using DentalRJ.Services.Exceptions;
using DentalRJ.Services.Interfaces.Generic;
using DentalRJ.Services.Model.Base;
using DentalRJ.Services.Params.Generic;

namespace DentalRJ.Services.Implementation
{
    public class NamedBaseService<T, TParams, TGetModel>: GenericService<T, TParams, TGetModel>, INamedService<T, TParams, TGetModel>
        where T : NamedBaseEntity
        where TParams: NamedParams
        where TGetModel: NamedGetModel
    {
        protected readonly INamedEntityRepository<T, TParams> _repo;

        public NamedBaseService(IMapper mapper, INamedEntityRepository<T, TParams> repo, string entityName)
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