using DentalRJ.Domain.Enums;
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
        public required string TradeName { get; set; }
        public required string Phone { get; set; }
        public string? Phone2 { get; set; }
        public required string PostalCode { get; set; }
        public required string Address { get; set; }
        public required string AdditionalAddress { get; set; }
        public required string CityName { get; set; }
        public required string StateCode { get; set; }

    }
}
