using DentalRJ.Domain.Entities;
using DentalRJ.Services.Interfaces.Generic;
using DentalRJ.Services.Params;


namespace DentalRJ.Services.Interfaces
{
    public interface ICompanyRepository : INamedEntityRepository<Company, CompanyParams>
    {
    }
}