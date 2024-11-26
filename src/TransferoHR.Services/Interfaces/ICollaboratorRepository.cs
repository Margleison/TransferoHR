using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferoHR.Domain.Entities;
using TransferoHR.Services.Interfaces.Generic;
using TransferoHR.Services.Model;
using TransferoHR.Services.Params;

namespace TransferoHR.Services.Interfaces
{
    public interface ICollaboratorRepository : IGenericNamedEntityRepository<Collaborator, CollaboratorParams>
    {
        Task<Collaborator>? GetByCPF(string cpf, Guid? excId);
        Task<Collaborator>? GetByRG(string rg, Guid? excId);
        Task<Collaborator>? GetByEmail(string email, Guid? excId);
    }
}
