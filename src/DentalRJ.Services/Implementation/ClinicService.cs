using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Model;
using DentalRJ.Services.Exceptions;
using DentalRJ.Services.Params;
using DentalRJ.Services.Interfaces;
using DentalRJ.Domain.Enums;
using DentalRJ.Services.Utils;
using DentalRJ.Services.Params.Generic;
using DentalRJ.Services.Interfaces.Generic;

namespace DentalRJ.Services.Implementation;

public class ClinicService : NamedBaseService<Clinic, ClinicParams, ClinicGetModel>, IClinicService
{

    private readonly IClinicRepository _repo;
    private readonly ICompanyRepository _companyRepository;
    public ClinicService(IMapper mapper, IClinicRepository repo, ICompanyRepository companyRepo)
        : base(mapper, repo, "Clinic")
    {
        _repo = repo;
        _companyRepository = companyRepo;
    }

    public override async Task Validate(Clinic entity, Guid? exId=null)
    {
        var empresa = await _companyRepository.GetAsync(entity.CompanyId);
        ServiceException.When(empresa == null, $"Empresa não encontrada. [Id='{entity.CompanyId}']");

        ServiceException.When(await _repo.GetByName(entity.Name, null) != null, $"There is already a {_entityName} with that name. [Id='{entity.Name}']");
        ServiceException.When(await _repo.GetByTradeName(entity.TradeName, null) != null, $"There is already a {_entityName} with that trade name. [Id='{entity.TradeName}']");
    }

    public async Task<IEnumerable<ClinicGetStatesModel>> GetActiveStatesAsync()
    {
        var param = new ClinicParams() { Status = EntityStatusEnum.Active.ToString() };
        var clinics = await _repo.GetAllAsync(param);
        var distinctStateCodes = clinics
            .Select(c => c.StateCode)
            .Distinct()
            .ToList();

        var result = distinctStateCodes.Select(code =>
        {
            if (Enum.TryParse(typeof(StateCodeEnum), code, out var enumValue))
            {
                return new ClinicGetStatesModel
                {
                    Code = code,
                    Name = ((StateCodeEnum)enumValue).GetDescription() // Utilizando o método de extensão
                };
            }

            return new ClinicGetStatesModel { Code = code, Name = "Unknown" };
        });

        return result;
    }
}