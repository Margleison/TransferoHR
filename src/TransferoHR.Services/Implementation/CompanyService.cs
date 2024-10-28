using AutoMapper;
using TransferoHR.Domain.Entities;
using TransferoHR.Services.Interfaces;
using TransferoHR.Services.Interfaces.Generic;
using TransferoHR.Services.Model;
using TransferoHR.Services.Params;

namespace TransferoHR.Services.Implementation;

public class CompanyService: GenericNamedService<Company, CompanyParams, CompanyGetModel>
{
    public CompanyService(IMapper mapper, ICompanyRepository repo)
        : base(mapper, repo, "Company")
    {
    }
}
