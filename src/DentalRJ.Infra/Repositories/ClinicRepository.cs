using DentalRJ.Domain.Entities;
using DentalRJ.Infra.Database;
using DentalRJ.Infra.Repositories.Base;
using DentalRJ.Services.Params;
using Microsoft.EntityFrameworkCore;

namespace DentalRJ.Infra.Repositories;

public class ClinicRepository : NamedBaseEntityRepository<Clinic, ClinicParams>
{
    public ClinicRepository(ApplicationDbContext db) : base(db)
    {
        _include = clinics => clinics.Include(c => c.Company);
    }

}