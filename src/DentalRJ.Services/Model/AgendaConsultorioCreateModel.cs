using DentalRJ.Services.Model.Base;

namespace DentalRJ.Services.Model;

public class AgendaConsultorioCreateModel : BaseModel
{
    public Guid SemanaConsultorioId { get; set; }
    public Guid EspecialidadeDentalId { get; set; }
    public Guid? DentistaId { get; set; }
    public DateOnly Inicio { get; set; }
}