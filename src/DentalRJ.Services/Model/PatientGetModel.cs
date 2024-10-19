using DentalRJ.Services.Model.Base;
namespace DentalRJ.Services.Model
{
    public class PatientGetModel : NamedGetModel
    {

        public string CPF { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? PostalCode { get; set; } = string.Empty;
        public string? CityName { get; set; } = string.Empty;
        public string StateCode { get; set; }
    }
}
