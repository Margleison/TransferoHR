
using DentalRJ.Domain.Entities;
using DentalRJ.Infra.Database;
using DentalRJ.Infra.Repositories.Base;
using DentalRJ.Services.Params;

namespace DentalRJ.Infra.Repositories;

public class DentistaRepository : NamedBaseEntityRepository<Dentist, DentistParams>
{
    public DentistaRepository(ApplicationDbContext db) : base(db)
    {
    }
    
    /*
    public async Task<Dentista> GetByCpfCnpj(string cpfCnpj, Guid? excId)
    {
        Expression<Func<Dentista, bool>> condition;
        
        if (excId == null)
            condition = x => x.CnpjCpf == cpfCnpj && x.Status != EntityStatusEnum.Deleted;
        else 
            condition = x => x.CnpjCpf == cpfCnpj && x.Status != EntityStatusEnum.Deleted && x.Id != excId;
        
        return await FirstAsync(condition);
    }

    public async Task<Dentista> GetByEmail(string email, Guid? excId)
    {
        Expression<Func<Dentista, bool>> condition;
        
        if (excId == null)
            condition = x => x.Email == email && x.Status != EntityStatusEnum.Deleted;
        else 
            condition = x => x.Email == email && x.Status != EntityStatusEnum.Deleted && x.Id != excId;
        
        return await FirstAsync(condition);
    }

    public async Task<Dentista> GetByCellPhone(string cellPhone, Guid? excId)
    {
        Expression<Func<Dentista, bool>> condition;
        
        if (excId == null)
            condition = x => x.CellPhone == cellPhone && x.Status != EntityStatusEnum.Deleted;
        else 
            condition = x => x.CellPhone == cellPhone && x.Status != EntityStatusEnum.Deleted && x.Id != excId;
        
        return await FirstAsync(condition);
    }
    */
}