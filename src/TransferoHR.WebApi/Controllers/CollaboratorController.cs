using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransferoHR.Domain.Entities;
using TransferoHR.Services.Implementation;
using TransferoHR.Services.Model;
using TransferoHR.Services.Params;

namespace TransferoHR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorController : GenericController<Collaborator, CollaboratorCreateModel, CollaboratorUpdateModel, CollaboratorGetModel, CollaboratorParams>
    {
        public CollaboratorController(CollaboratorService service, IMapper mapper) 
            : base(service, mapper) 
        {}
    }
}
