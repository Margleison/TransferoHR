using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Model;
using DentalRJ.Services.Exceptions;
using DentalRJ.Services.Interfaces.Base;

namespace DentalRJ.Services.Implementation;

public class ClinicService: NamedBaseService<Clinic>
{
    
    private readonly INamedBaseEntityRepository<Company> _empresaRepository;
    public ClinicService(IMapper mapper, INamedBaseEntityRepository<Clinic> repo, INamedBaseEntityRepository<Company> empresaRepo)
        : base(mapper, repo, "Clinic")
    {
        _empresaRepository = empresaRepo;
    }
    
    public override async Task<Clinic> Insert<TCreateModel>(TCreateModel createModel, string CreatedBy)
     {
        if (createModel is ClinicCreateModel clinicCreateModel)
        {
            var empresa = await _empresaRepository.GetAsync(clinicCreateModel.CompanyId);
            ServiceException.When(empresa == null, $"Empresa não encontrada. [Id='{clinicCreateModel.CompanyId}']");
        }
        // Chama a lógica de inserção da classe base
        return await base.Insert(createModel, CreatedBy);
    }
}