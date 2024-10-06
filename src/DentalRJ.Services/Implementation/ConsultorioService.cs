using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Domain.Enums;
using DentalRJ.Services.Model;
using DentalRJ.Services.Exceptions;
using DentalRJ.Services.Interfaces.Base;

namespace DentalRJ.Services.Implementation;

public class ConsultorioService: NamedBaseService<ConsultingRoom>
{
    
    private readonly INamedBaseEntityRepository<Clinic> _clinicRepository;
    
    public ConsultorioService(IMapper mapper, INamedBaseEntityRepository<ConsultingRoom> repo, INamedBaseEntityRepository<Clinic> clinicRepo)
        : base(mapper, repo, "Consulting Room")
    {
        _clinicRepository = clinicRepo;
    }

    public override async Task<ConsultingRoom> Insert<TCreateModel>(TCreateModel createModel, string createdBy)
    {
        if (createModel is ConsultingRoomCreateModel consultorioCreateModel)
        {
            var clinic = await _clinicRepository.GetAsync(consultorioCreateModel.ClinicId);
            ServiceException.When(clinic == null,
                $"Clinic does not exists. [Id='{consultorioCreateModel.ClinicId}']");
            ServiceException.When(
                await _repo.GetByNameAndOwner(consultorioCreateModel.ClinicId, consultorioCreateModel.Name, null) != null,
                $"COnsulting Room exists. [Name={consultorioCreateModel.Name}]");
            
            
            var newEntity = _mapper.Map<ConsultingRoomCreateModel, ConsultingRoom>(consultorioCreateModel);
            newEntity.Status = EntityStatusEnum.Active;
            newEntity.CreatedAt = DateTime.Now;
            newEntity.CreatedBy = createdBy;
            newEntity.Id = Guid.NewGuid();
            await _repo.AddAsync(newEntity);

            return newEntity;
        }

        return null;
    }
}
