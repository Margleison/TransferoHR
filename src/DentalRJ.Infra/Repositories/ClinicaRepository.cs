using DentalRJ.Domain.Entities;
using DentalRJ.Infra.Database;
using DentalRJ.Infra.Repositories.Base;

namespace DentalRJ.Infra.Repositories;

public class ClinicRepository : NamedBaseEntityRepository<Clinic>
{
    public ClinicRepository(ApplicationDbContext db) : base(db)
    {
    }
}