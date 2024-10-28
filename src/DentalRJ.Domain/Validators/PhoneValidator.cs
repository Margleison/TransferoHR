using System.Text.RegularExpressions;

namespace TransferoHR.Domain.Validators
{
    public static class PhoneValidator
    {
        public static bool Validate(string phone)
        {
            // Regex para validar o formato do telefone (exemplo: (99) 99999-9999 ou 99999-9999)
            var regex = new Regex(@"^(\(\d{2}\)\s?)?\d{5}-\d{4}$");
            return regex.IsMatch(phone);
        }
    }
}