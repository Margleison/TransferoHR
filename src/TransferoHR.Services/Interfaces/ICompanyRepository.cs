using TransferoHR.Domain.Entities;
using TransferoHR.Services.Interfaces.Generic;
using TransferoHR.Services.Params;


namespace TransferoHR.Services.Interfaces
{
    public interface ICompanyRepository : IGenericNamedEntityRepository<Company, CompanyParams>
    {
        Task<Company>? GetByCNPJ(string cnpj, Guid? excId);
    }
}