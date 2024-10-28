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
    public class DepartmentController : GenericController<Department, DepartmentCreateModel, DepartmentUpdateModel, DepartmentGetModel, DepartmentParams>
    {
        public DepartmentController(DepartmentService departmentservice, IMapper mapper) 
            : base(departmentservice, mapper)
        {
        }
    }
}
