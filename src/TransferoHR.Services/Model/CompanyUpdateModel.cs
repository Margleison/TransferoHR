﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferoHR.Services.Model.Generic;

namespace TransferoHR.Services.Model
{
    public class CompanyUpdateModel: NamedUpdateModel
    {
        public required string CNPJ { get; set; }
    }
}
