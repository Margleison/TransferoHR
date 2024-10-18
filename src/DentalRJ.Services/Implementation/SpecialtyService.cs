using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Model.Base;
using DentalRJ.Services.Params;

namespace DentalRJ.Services.Implementation
{

    public class SpecialtyService : NamedBaseService<Specialty, NamedParams, NamedGetModel>
    {
        public SpecialtyService(IMapper mapper, INamedBaseEntityRepository<Specialty, NamedParams> repo)
        : base(mapper, repo, "Specialty")
        {
        }
    }
}