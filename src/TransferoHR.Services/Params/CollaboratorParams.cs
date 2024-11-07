using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferoHR.Services.Params.Generic;

namespace TransferoHR.Services.Params
{
    public class CollaboratorParams : NamedParams
    {
        public string CPF { get; set; } = string.Empty;
        public string RG { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
