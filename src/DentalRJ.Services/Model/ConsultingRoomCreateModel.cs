using DentalRJ.Services.Model.Base;

namespace DentalRJ.Services.Model;

public class ConsultingRoomCreateModel: NamedCreateModel 
{
    public Guid ClinicId { get; set; }
}