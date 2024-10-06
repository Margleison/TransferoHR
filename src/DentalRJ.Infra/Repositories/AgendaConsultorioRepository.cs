using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using DentalRJ.Domain.Entities;
using DentalRJ.Domain.Enums;
using DentalRJ.Infra.Database;
using DentalRJ.Infra.Repositories.Base;

/*
public class AgendaConsultorioRepository: BaseEntityRepository<AgendaConsultorio>, IAgendaConsultorioRepository
{
    public AgendaConsultorioRepository(ApplicationDbContext db) : base(db)
    {
    }
    public async Task<AgendaConsultorio> GetBySemanaConsultorio(Guid semanaConsultorioId)
    {
        Expression<Func<AgendaConsultorio, bool>> filter;
        filter = x => x.SemanaConsultorioId == semanaConsultorioId && x.Status != EntityStatusEnum.Deleted;
        return await FirstAsync(filter);
    }
}
*/