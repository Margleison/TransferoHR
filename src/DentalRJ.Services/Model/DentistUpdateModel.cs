using DentalRJ.Services.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalRJ.Services.Model
{
    public class DentistUpdateModel: NamedUpdateModel
    {
        public string CPF { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public string Email { get; set; } = string.Empty;
        public string CRO { get; set; } = string.Empty;
    }
}
