using DentalRJ.Domain.Entities;
using DentalRJ.Infra.Database;
using DentalRJ.Infra.Repositories.Base;

namespace DentalRJ.Infra.Repositories;

public class ClinicaRepository : NamedBaseEntityRepository<Clinic>
{
    public ClinicaRepository(ApplicationDbContext db) : base(db)
    {
    }
}