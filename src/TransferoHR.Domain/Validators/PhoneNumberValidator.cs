using System.Text.RegularExpressions;

namespace TransferoHR.Domain.Validators
{
    public static class PhoneNumberValidator
    {
        public static bool Validate(string phoneNumber)
        {
            // Regex para validar números de telefone no formato brasileiro
            // Aceita números no formato (XX)XXXXX-XXXX ou (XX)XXXX-XXXX
            var regex = new Regex(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$");
            return regex.IsMatch(phoneNumber);
        }
    }
}
