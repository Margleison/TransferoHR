using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferoHR.Domain.Enums;
using TransferoHR.Services.Model.Generic;

namespace TransferoHR.Services.Model
{
    public class CollaboratorGetModel : NamedGetModel
    {
        public string CPF { get; set; } = String.Empty;
        public string ForeignIdentificationDocument { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string WorkEmail { get; set; } = String.Empty;
        public GenderEnum Gender { get; set; } = GenderEnum.NotInformed;
        public string Country { get; set; } = String.Empty;
        public string RG { get; set; } = String.Empty;
        public DateOnly BirthDate { get; set; }
        public string Nationality { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public string State { get; set; } = String.Empty;
        public string PostalCode { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public string BankName { get; set; } = String.Empty;
        public string AccountName { get; set; } = String.Empty;
        public string BankBranch { get; set; } = String.Empty;
        public string PixKey { get; set; } = String.Empty;
    }
}
