using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Interfaces.Base;

namespace DentalRJ.Services.Implementation;

public class DentistService : NamedBaseService<Dentist>
{
    public DentistService(IMapper mapper, INamedBaseEntityRepository<Dentist> repo)
        : base(mapper, repo, "Dentist")
    {
    }
    
    
}