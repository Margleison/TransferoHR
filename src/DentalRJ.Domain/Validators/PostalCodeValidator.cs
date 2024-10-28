using System.Text.RegularExpressions;

namespace TransferoHR.Domain.Validators
{
    public static class PostalCodeValidator
    {
        public static bool Validate(string cep)
        {
            // Regex para validar o formato do CEP brasileiro: 5 dígitos, um hífen, e 3 dígitos (ex: 12345-678)
            var regex = new Regex(@"^\d{5}-?\d{3}$");
            return regex.IsMatch(cep);
        }
    }
}
