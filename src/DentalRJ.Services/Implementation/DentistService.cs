using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Params;

namespace DentalRJ.Services.Implementation;

public class DentistService : NamedBaseService<Dentist, DentistParams>
{
    public DentistService(IMapper mapper, INamedBaseEntityRepository<Dentist, DentistParams> repo)
        : base(mapper, repo, "Dentist")
    {
    }   
}