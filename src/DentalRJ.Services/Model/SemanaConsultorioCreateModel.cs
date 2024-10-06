using DentalRJ.Services.Model.Base;

namespace DentalRJ.Services.Model;

public class SemanaConsultorioCreateModel : BaseModel
{
    public Guid ConsultorioId { get; set; }
    public DayOfWeek DiaSemana { get; set; }
    public TimeOnly InicioExpediente { get; init; }
    public TimeOnly FimExpediente { get; init; }
    public TimeOnly InicioDescanso { get; init; }
    public TimeOnly FimDescanso { get; init; }
}