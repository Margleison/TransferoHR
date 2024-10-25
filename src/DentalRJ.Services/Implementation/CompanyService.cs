using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Interfaces.Generic;
using DentalRJ.Services.Model;
using DentalRJ.Services.Params;

namespace DentalRJ.Services.Implementation;

public class CompanyService: NamedBaseService<Company, CompanyParams, CompanyGetModel>
{
    public CompanyService(IMapper mapper, ICompanyRepository repo)
        : base(mapper, repo, "Company")
    {
    }
}
