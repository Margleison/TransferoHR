using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferoHR.Domain.Enums;
using TransferoHR.Services.Model.Generic;

namespace TransferoHR.Services.Model
{
    public class CollaboratorUpdateModel : NamedUpdateModel
    {
        public NationalityEnum Nationality { get; set; }
        public string? CPF { get; set; } = string.Empty;
        public string? ForeignIdentificationDocument { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string WorkEmail { get; set; } = string.Empty;
        public GenderEnum Gender { get; set; } = GenderEnum.NotInformed;
        public string Country { get; set; } = string.Empty;
        public string RG { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string BankAccount { get; set; } = string.Empty;
        public string BankBranch { get; set; } = string.Empty;
        public string PixKey { get; set; } = string.Empty;

    }
}
