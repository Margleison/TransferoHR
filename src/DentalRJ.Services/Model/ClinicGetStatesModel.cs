using DentalRJ.Services.Model.Base;
namespace DentalRJ.Services.Model
{
    public class ClinicGetStatesModel : BaseModel
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
    }
}
