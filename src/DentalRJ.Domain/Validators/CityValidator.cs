using System.Text.RegularExpressions;

namespace TransferoHR.TransferoDomain.Validators
{
    public static class CityValidator
    {
        public static bool Validate(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                return false;

            // Regex para validar cidade (permitindo letras, espaços e acentos)
            var regex = new Regex(@"^[a-zA-ZÀ-ú\s]+(?:[\s-][a-zA-ZÀ-ú\s]+)*$");
            return regex.IsMatch(city);
        }
    }
}
