using TransferoHR.Domain.Validators;
using TransferoHR.Services.Model.Generic;

namespace TransferoHR.Services.Model;

public class CompanyCreateModel : NamedCreateModel
{
    public required string CNPJ {get; set;}
}