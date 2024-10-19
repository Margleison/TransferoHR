using DentalRJ.Domain.Enums;
using DentalRJ.Services.Model.Base;

namespace DentalRJ.Services.Model
{
    public class ClinicUpdateModel : NamedUpdateModel
    {
        public string? TradeName { get; set; }
        public string? Phone { get; set; }
        public string? Phone2 { get; set; }
        public string? PostalCode { get; set; }
        public string? Address { get; set; }
        public string? AdditionalAddress { get; set; }
        public string? CityName { get; set; }
        public string? StateCode { get; set; } = string.Empty;
    }
}
