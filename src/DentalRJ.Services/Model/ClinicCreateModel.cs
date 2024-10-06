using DentalRJ.Services.Model.Base;

namespace DentalRJ.Services.Model;

public class ClinicCreateModel: NamedCreateModel 
{
    public Guid CompanyId { get; set; }
}