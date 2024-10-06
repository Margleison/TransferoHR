using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Interfaces.Base;

namespace DentalRJ.Services.Implementation;

public class CompanyService: NamedBaseService<Company>
{
    public CompanyService(IMapper mapper, INamedBaseEntityRepository<Company> repo)
        : base(mapper, repo, "Company")
    {
    }
}
