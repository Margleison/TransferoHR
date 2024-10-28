using AutoMapper;
using TransferoHR.Domain.Entities;
using TransferoHR.Services.Interfaces;
using TransferoHR.Services.Model;
using TransferoHR.Services.Params;

namespace TransferoHR.Services.Implementation
{
    public class DepartmentService : GenericNamedService <Department, DepartmentParams, DepartmentGetModel>
    {
        public DepartmentService(IMapper mapper, IDepartmentReposity repo) 
            : base(mapper, repo, "Department")
        {
        }
    }
}
