using DentalRJ.Domain.Enums;
using DentalRJ.Services.Model.Base;

namespace DentalRJ.Services.Model;

public class ClinicCreateModel: NamedCreateModel 
{
    public Guid CompanyId { get; set; }
    public string TradeName { get; set; } = string.Empty;
    public string? Phone { get; set; } = string.Empty;
    public string? Phone2 { get; set; } = string.Empty;
    public string? PostalCode { get; set; } = string.Empty;
    public string? Address { get; set; } = string.Empty;
    public string? AdditionalAddress { get; set; } = string.Empty;
    public string? CityName { get; set; } = string.Empty;
    public string? StateCode { get; set; } = string.Empty;

}