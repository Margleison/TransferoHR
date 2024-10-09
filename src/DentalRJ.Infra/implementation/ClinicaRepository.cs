using DentalRJ.Domain.Entities;
using DentalRJ.Infra.Database;
using DentalRJ.Infra.Repositories.Base;
using DentalRJ.Services.Params;

namespace DentalRJ.Infra.Repositories;

public class ClinicaRepository : NamedBaseEntityRepository<Clinic, ClinicParams>
{
    public ClinicaRepository(ApplicationDbContext db) : base(db)
    {
    }
}