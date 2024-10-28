using System.Threading.Tasks;
using TransferoHR.Domain.Entities;
using TransferoHR.Infra.Database;
using TransferoHR.Infra.Repositories.Generic;
using TransferoHR.Services.Interfaces;
using TransferoHR.Services.Params;

namespace TransferoHR.Infra.Repositories
{
    public class DepartmentReposity : GenericNamedEntityRepository <Department, DepartmentParams>, IDepartmentReposity
    {
        public DepartmentReposity(HRContext db) : base(db)
        {
        }
    }
}
