using TransferoHR.Services.Model.Generic;


namespace TransferoHR.Services.Model
{
    public class CompanyGetModel: NamedGetModel
    {
        public string CNPJ { get; set; } = string.Empty;
    }
}
