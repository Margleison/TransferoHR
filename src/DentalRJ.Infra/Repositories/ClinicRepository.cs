using DentalRJ.Domain.Entities;
using DentalRJ.Domain.Enums;
using DentalRJ.Infra.Database;
using DentalRJ.Infra.Repositories.Base;
using DentalRJ.Services.Interfaces;
using DentalRJ.Services.Params;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace DentalRJ.Infra.Repositories;

public class ClinicRepository : NamedBaseEntityRepository<Clinic, ClinicParams>, INamedBaseEntityRepository<Clinic, ClinicParams>
{
    public ClinicRepository(ApplicationDbContext db) : base(db)
    {
        _include = clinics => clinics.Include(c => c.Company);
    }

    public async Task<IEnumerable<Clinic>> GetAllAsync(ClinicParams param)
    {
        var predicate = PredicateBuilder.New<Clinic>(true);

        if (!string.IsNullOrEmpty(param.Name))
            predicate = predicate.And(x => x.Name.Contains(param.Name));

        if (!string.IsNullOrEmpty(param.TradeName))
            predicate = predicate.And(x => x.TradeName.Contains(param.TradeName));

        if (!string.IsNullOrEmpty(param.CityName))
            predicate = predicate.And(x => x.CityName.Contains(param.CityName));

        if (!string.IsNullOrEmpty(param.PostalCode))
            predicate = predicate.And(x => x.PostalCode.Contains(param.PostalCode));

        if (!string.IsNullOrEmpty(param.Status))
        {
            Enum.TryParse(param.Status, out EntityStatusEnum status);
            predicate = predicate.And(x => x.Status == status);
        }
        else
            predicate = predicate.And(x => x.Status != EntityStatusEnum.Inactive);

        return await ListAsync(predicate, param.PageNumber, param.PageSize  );
    }
}