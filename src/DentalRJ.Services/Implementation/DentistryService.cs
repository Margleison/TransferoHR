using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Model.Base;
using DentalRJ.Services.Params;

namespace DentalRJ.Services.Implementation
{

    public class DentistryService : NamedBaseService<Dentistry, NamedParams, NamedGetModel>
    {
        public DentistryService(IMapper mapper, INamedBaseEntityRepository<Dentistry, NamedParams> repo)
        : base(mapper, repo, "Dentistry")
        {
        }
    }
}