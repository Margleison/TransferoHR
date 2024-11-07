using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferoHR.Domain.Enums;
using TransferoHR.Domain.Exceptions;
using TransferoHR.Services.Model.Generic;

namespace TransferoHR.Services.Model
{
    public class CollaboratorCreateModel : NamedCreateModel
    {

        public NationalityEnum Nationality { get; set; }
        public string? CPF { get; set; } = string.Empty;
        public string? DNI { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string WorkEmail { get; set; } = string.Empty;
        public GenderEnum Gender { get; set; } = GenderEnum.NotInformed;
        public string Country { get; set;} = string.Empty;
        public string RG { get; set; } = string.Empty;
        public DateOnly BirthDate {  get; set; }
        public string Address {  get; set; } = string.Empty;
        public string City { get; set; } = string.Empty ;
        public string state { get; set; } = string.Empty ;
        public string PostalCode { get; set; } = string.Empty;
        public string PhoneNumber {  get; set; } = string.Empty;
        public string BankName {  get; set; } = string.Empty;
        public string AccountName {  get; set; } = string.Empty;
        public string BankBranch {  get; set; } = string.Empty;
        public string PixKey {  get; set; } = string.Empty;

        public void Validate()
        {
            if (Nationality == NationalityEnum.Brasileiro)
            {
                DomainException.When(string.IsNullOrWhiteSpace(CPF), "CPF is required for Brazilian citizens.");
            }
            else if (Nationality == NationalityEnum.Argentino)
            {
                DomainException.When(string.IsNullOrWhiteSpace(DNI), "DNI is required for Argentine citizens.");
            }
        }   
    }
}
