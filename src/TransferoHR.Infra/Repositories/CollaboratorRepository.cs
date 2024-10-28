using TransferoHR.Domain.Entities;
using TransferoHR.Infra.Database;
using TransferoHR.Infra.Repositories.Generic;
using TransferoHR.Services.Interfaces;
using TransferoHR.Services.Params;

namespace TransferoHR.Infra.Repositories
{
    public class CollaboratorRepository : GenericNamedEntityRepository<Collaborator, CollaboratorParams>, ICollaboratorRepository
    {
        public CollaboratorRepository(HRContext db) : base(db)
        {
        }
    }
}
