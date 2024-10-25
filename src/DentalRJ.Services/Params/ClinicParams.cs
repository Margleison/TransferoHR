using DentalRJ.Domain.Enums;
using DentalRJ.Services.Params.Generic;

namespace DentalRJ.Services.Params;

public class ClinicParams : NamedParams
{
    public string? TradeName { get; set; }
    public string? PostalCode { get; set; }
    public string? CityName { get; set; }
    public StateCodeEnum? StateCode { get; set; }
    public Guid? CompanyId { get; set; }

}