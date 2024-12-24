using AutoMapper;
using TransferoHR.Domain.Entities;
using TransferoHR.Services.Exceptions;
using TransferoHR.Services.Interfaces;
using TransferoHR.Services.Model;
using TransferoHR.Services.Params;

namespace TransferoHR.Services.Implementation;

public class CollaboratorService : GenericNamedService<Collaborator, CollaboratorParams, CollaboratorGetModel> 
{
    protected ICollaboratorRepository
        _repo;

    public CollaboratorService(IMapper mapper, ICollaboratorRepository repo) 
        : base  (mapper, repo, "Collaborator") 
    {
        _repo = repo;
    }
    public override async Task Validate(Collaborator entity, Guid? exId)
    {
        await base.Validate(entity, exId);
        ServiceException.When(await _repo.GetByCPF(entity.CPF, exId) != null, $"{_entityName} CPF already exists. [Value={entity.CPF}]");
        ServiceException.When(await _repo.GetByRG(entity.RG, exId) != null, $"{_entityName} RG already exists. [Value={entity.RG}]");
        //Teste
        ServiceException.When(await _repo.GetByEmail(entity.Email, exId) != null, $"{_entityName} Email already exists. [Value={entity.Email}]");
    }
}
