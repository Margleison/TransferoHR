using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Exceptions;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Model;
using DentalRJ.Services.Params;

namespace DentalRJ.Services.Implementation
{
    public class DentistService: NamedBaseService<Dentist, DentistParams, DentistGetModel>
    {
        private readonly IDentistRepository _repo;
        public DentistService(IMapper mapper, IDentistRepository repo)
            : base(mapper, repo, "Dentist")
        {
            _repo = repo;
        }
        public override async Task Validate(Dentist entity, Guid? exId)
        {
            ServiceException.When(await _repo.GetByName(entity.Name, exId) != null, $"There is already a {_entityName} with that name. [Id='{entity.Name}']");
            ServiceException.When(await _repo.GetByCPF(entity.CPF, exId) != null, $"There is already a {_entityName} with that CPF. [Id='{entity.CPF}']");
            ServiceException.When(await _repo.GetByCRO(entity.CRO, exId) != null, $"There is already a {_entityName} with that CRO. [Id='{entity.CRO}']");
            ServiceException.When(await _repo.GetByEmail(entity.Email, exId) != null, $"There is already a {_entityName} with that Email. [Id='{entity.Email}']");
        }

    }
}
