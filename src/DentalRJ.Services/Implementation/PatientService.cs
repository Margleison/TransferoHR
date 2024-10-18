using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Model;
using DentalRJ.Services.Params;

namespace DentalRJ.Services.Implementation
{
    public class PatientService : NamedBaseService<Patient, PatientParams, PatientGetModel>
    {
        public PatientService(IMapper mapper, INamedBaseEntityRepository<Patient, PatientParams> repo)
            : base(mapper, repo, "Patient")
        {
        }
    }
}
