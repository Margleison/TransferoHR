using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Interfaces.Generic;
using DentalRJ.Services.Model;
using DentalRJ.Services.Model.Base;
using DentalRJ.Services.Params;
using DentalRJ.Services.Params.Generic;

namespace DentalRJ.Services.Implementation
{

    public class DentistryService : NamedBaseService<Dentistry, DentistryParams, DentistryGetModel>
    {
        public DentistryService(IMapper mapper, IDentistryRepository repo)
        : base(mapper, repo, "Dentistry")
        {
        }
    }
}