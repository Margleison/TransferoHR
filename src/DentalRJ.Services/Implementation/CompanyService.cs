using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Params;

namespace DentalRJ.Services.Implementation;

public class CompanyService: NamedBaseService<Company, NamedParams>
{
    public CompanyService(IMapper mapper, INamedBaseEntityRepository<Company, NamedParams> repo)
        : base(mapper, repo, "Company")
    {
    }
}
