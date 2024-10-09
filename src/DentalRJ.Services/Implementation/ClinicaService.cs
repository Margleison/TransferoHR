using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Model;
using DentalRJ.Services.Exceptions;
using DentalRJ.Services.Interfaces.Base;
using DentalRJ.Services.Params;

namespace DentalRJ.Services.Implementation;

public class ClinicService: NamedBaseService<Clinic, ClinicParams>
{
    
    private readonly INamedBaseEntityRepository<Company, NamedParams> _companyRepository;
    public ClinicService(IMapper mapper, INamedBaseEntityRepository<Clinic, ClinicParams> repo, INamedBaseEntityRepository<Company, NamedParams> companyRepo)
        : base(mapper, repo, "Clinic")
    {
        _companyRepository = companyRepo;
    }
    
    public override async Task<Clinic> Insert<TCreateModel>(TCreateModel createModel, string CreatedBy)
     {
        if (createModel is ClinicCreateModel clinicCreateModel)
        {
            var empresa = await _companyRepository.GetAsync(clinicCreateModel.CompanyId);
            ServiceException.When(empresa == null, $"Empresa não encontrada. [Id='{clinicCreateModel.CompanyId}']");
        }
        // Chama a lógica de inserção da classe base
        return await base.Insert(createModel, CreatedBy);
    }
}