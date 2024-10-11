using DentalRJ.Services.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalRJ.Services.Model
{
    public  class ClinicGetModel : NamedGetModel
    {
        public string CompanyName { get; set; } = string.Empty;
        public Guid CompanyId { get; set; }
    }
}
