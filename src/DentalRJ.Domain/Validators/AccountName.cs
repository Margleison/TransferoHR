using System.Text.RegularExpressions;

namespace TransferoHR.Domain.Validators
{
    public static class AccountNameValidator
    {
        public static bool Validate(string accountName)
        {
            // Verifica se o nome da conta está preenchido
            if (string.IsNullOrWhiteSpace(accountName))
                return false;

            // Verifica se o nome contém apenas letras, números e espaços
            if (!Regex.IsMatch(accountName, @"^[a-zA-Z0-9\s]+$"))
                return false;

            // Verifica se o nome tem um tamanho aceitável (entre 3 e 50 caracteres)
            if (accountName.Length < 3 || accountName.Length > 50)
                return false;

            // Se todas as validações forem bem-sucedidas, o nome da conta é considerado válido
            return true;
        }
    }
}
