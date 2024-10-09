using System.Linq.Expressions;
using DentalRJ.Domain.Entities;
using DentalRJ.Domain.Enums;
using DentalRJ.Infra.Database;
using DentalRJ.Infra.Repositories.Base;
using DentalRJ.Services.Params;

namespace DentalRJ.Infra.Repositories;

public class ConsultingRoomRepository : NamedBaseEntityRepository<ConsultingRoom, ConsultingRoomParams>
{
    public ConsultingRoomRepository(ApplicationDbContext db) : base(db)
    {
    }
    public override async Task<ConsultingRoom> GetByNameAndOwner(Guid ownerId, string name, Guid? excId = null)
    {
        Expression<Func<ConsultingRoom, bool>> filter;
        if (excId == null)
            filter = x => x.ClinicId == ownerId && x.Name == name && x.Status != EntityStatusEnum.Deleted;
        else 
            filter = x => x.ClinicId == ownerId && x.Name == name && x.Status != EntityStatusEnum.Deleted && x.Id != excId;
        
        return await FirstAsync(filter);
    }
}