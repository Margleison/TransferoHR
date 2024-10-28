using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferoHR.Domain.Entities;
using TransferoHR.Services.Interfaces;
using TransferoHR.Services.Model;
using TransferoHR.Services.Params;

namespace TransferoHR.Services.Implementation
{
    public class CollaboratorService : GenericNamedService<Collaborator, CollaboratorParams, CollaboratorGetModel> 
    {
        public CollaboratorService(IMapper mapper, ICollaboratorRepository repo) 
            : base  (mapper, repo, "Collaborator") 
        {
        }
    }
}
