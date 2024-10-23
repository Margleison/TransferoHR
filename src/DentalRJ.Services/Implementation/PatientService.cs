using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Domain.Enums;
using DentalRJ.Services.Exceptions;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Model;
using DentalRJ.Services.Params;

namespace DentalRJ.Services.Implementation
{
    public class PatientService : NamedBaseService<Patient, PatientParams, PatientGetModel>
    {
        private readonly IPatientRepository _repo;

        public PatientService(IMapper mapper, IPatientRepository repo)
            : base(mapper, repo, "Patient")
        {
            _repo = repo;
        }

        public override async Task Validate(Patient entity, Guid? exId=null)
        {
            ServiceException.When(await _repo.GetByCPFAndBirthDate(entity.CPF, entity.BirthDate, exId) != null, $"There is already a {_entityName} with that CPF and BirthDate. [Id='{entity.CPF}', {entity.BirthDate}]");
        }

    }
}
