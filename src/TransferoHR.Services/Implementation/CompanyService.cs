using AutoMapper;
using TransferoHR.Domain.Entities;
using TransferoHR.Services.Exceptions;
using TransferoHR.Services.Interfaces;
using TransferoHR.Services.Model;
using TransferoHR.Services.Params;

namespace TransferoHR.Services.Implementation;

public class CompanyService: GenericNamedService<Company, CompanyParams, CompanyGetModel>
{

    protected ICompanyRepository 
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
        _repo;

    public CompanyService(IMapper mapper, ICompanyRepository repo)
        : base(mapper, repo, "Company")
    {
        _repo = repo;
    }
    public override async Task Validate(Company entity, Guid? exId)
    {
        await base.Validate(entity, exId);
        ServiceException.When(await _repo.GetByCNPJ(entity.CNPJ, exId) != null, $"{_entityName} CNPJ already exists. [Value={entity.CNPJ}]");
    }
}
