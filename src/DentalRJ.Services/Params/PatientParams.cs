using DentalRJ.Services.Params.Generic;

namespace DentalRJ.Services.Params
{
    public class PatientParams : NamedParams
    {
        public string CPF { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string CityName { get; set; } = string.Empty;
    }
}
