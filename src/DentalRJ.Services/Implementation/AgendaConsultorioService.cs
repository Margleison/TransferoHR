/*
 * using AutoMapper;
using DentalRJ.Domain.Entities;
using DentalRJ.Domain.Enums;
using DentalRJ.Services.Model;
using DentalRJ.Services.Exceptions;
using DentalRJ.Services.Interfaces;

namespace DentalRJ.Services.Implementation;

public class AgendaConsultorioService
{
    private readonly IAgendaConsultorioRepository _repo;
    private readonly ISemanaConsultorioRepository _semanaConsultorioRepository;
    private readonly INamedBaseEntityRepository<EspecialidadeDentista> _especialidadeDentistaRepository;

    private readonly INamedBaseEntityRepository<Dentista> _dentistaRepository;
    private readonly IMapper _mapper;
    
    public AgendaConsultorioService(IMapper mapper, 
        IAgendaConsultorioRepository repo, 
        INamedBaseEntityRepository<Dentista> dentistaRepository, 
        INamedBaseEntityRepository<EspecialidadeDentista> especialidadeDentistaRepository, 
        ISemanaConsultorioRepository semanaConsultorioRepository)
    {
        _mapper = mapper;
        _repo = repo;
        _semanaConsultorioRepository = semanaConsultorioRepository;
        _especialidadeDentistaRepository = especialidadeDentistaRepository;
        _dentistaRepository = dentistaRepository;
    }

    public async Task<AgendaConsultorio> Insert(AgendaConsultorioCreateModel createModel, string CreatedBy)
    {
        var semanaConsultorio = await _semanaConsultorioRepository.GetAsync(createModel.SemanaConsultorioId);
        ServiceException.When(semanaConsultorio == null,
            $"Semana Consultório não encontrado. [Id='{createModel.SemanaConsultorioId}']");
        
        ServiceException.When(createModel.Inicio.DayOfWeek != semanaConsultorio.DiaSemana,
            $"Dia da semana incompativel.");
        
        var especialidadeDentista = await _especialidadeDentistaRepository.GetAsync(createModel.EspecialidadeDentalId);
        ServiceException.When(especialidadeDentista == null,
            $"Especialidade não encontrada. [Id='{createModel.EspecialidadeDentalId}']");
        
        if (createModel.DentistaId.HasValue)
        {
            Guid dentistaId = createModel.DentistaId.Value;
            var dentista = await _dentistaRepository.GetAsync(dentistaId);
            ServiceException.When(dentista == null,
                $"Dentista não encontrado. [Id='{dentistaId}']");
        }
        
        var newEntity = _mapper.Map<AgendaConsultorioCreateModel, AgendaConsultorio>(createModel);
        newEntity.ConsultorioId = semanaConsultorio.ConsultorioId;
        newEntity.Status = EntityStatusEnum.Active;
        newEntity.CriadoEm = DateTime.Now;
        newEntity.CreatedBy = CreatedBy;
        newEntity.Id = Guid.NewGuid();
        await _repo.AddAsync(newEntity);
        return newEntity;
    }
}
*/