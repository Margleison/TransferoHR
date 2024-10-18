using DentalRJ.Services.Model.Base;

namespace DentalRJ.Services.Model
{
    public class DentistCreateModel : NamedCreateModel
    {
        public string CPF { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public string Email { get; set; } = string.Empty;
        public string CRO { get; set; } = string.Empty;
    }
}
