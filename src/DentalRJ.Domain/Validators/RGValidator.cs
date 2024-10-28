using System.Text.RegularExpressions;

namespace TransferoHR.Domain.Validators
{
    public static class RGValidator
    {
        public static bool Validate(string rg)
        {
            // Regex para validar o formato do RG brasileiro: 2 dígitos, ponto, 3 dígitos, ponto, 3 dígitos, hífen, 1 dígito
            var regex = new Regex(@"^\d{2}\.?\d{3}\.?\d{3}-?\d{1}$");
            return regex.IsMatch(rg);
        }
    }
}
