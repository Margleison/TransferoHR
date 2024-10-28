using System.Text.RegularExpressions;

namespace TransferoHR.Domain.Validators
{
    public static class PixKeyValidator
    {
        public static bool Validate(string pixKey)
        {
            if (string.IsNullOrWhiteSpace(pixKey))
                return false;

            // Verifica se é um número de celular
            if (IsPhoneNumber(pixKey))
                return true;

            // Verifica se é um CPF válido
            if (IsCpf(pixKey))
                return true;

            // Verifica se é um e-mail válido
            if (IsEmail(pixKey))
                return true;

            // Se não for nenhum dos tipos acima, é inválido
            return false;
        }

        // Método para validar número de celular
        private static bool IsPhoneNumber(string pixKey)
        {
            // Formato básico de celular: +55 DDD e número com 9 dígitos (aceitando variações com ou sem espaços e hífens)
            var phoneRegex = new Regex(@"^\+55\s?(\d{2})\s?\d{4,5}-?\d{4}$");
            return phoneRegex.IsMatch(pixKey);
        }

        // Método para validar CPF
        private static bool IsCpf(string pixKey)
        {
            // Remove caracteres especiais do CPF antes de validar
            pixKey = pixKey.Replace(".", "").Replace("-", "");

            // CPF deve ter 11 dígitos
            if (pixKey.Length != 11 || !long.TryParse(pixKey, out _))
                return false;

            // Verificar os dígitos verificadores
            return CpfValidator(pixKey);
        }

        // Método para validar e-mail
        private static bool IsEmail(string pixKey)
        {
            var emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return emailRegex.IsMatch(pixKey);
        }

        // Validador de CPF com cálculo dos dígitos verificadores
        private static bool CpfValidator(string cpf)
        {
            if (cpf.Length != 11) return false;

            var tempCpf = cpf.Substring(0, 9);
            var soma = 0;

            // Calcula o primeiro dígito verificador
            for (var i = 0; i < 9; i++)
                soma += (tempCpf[i] - '0') * (10 - i);

            var resto = soma % 11;
            var digito = resto < 2 ? 0 : 11 - resto;

            if (cpf[9] != digito + '0')
                return false;

            // Calcula o segundo dígito verificador
            tempCpf += digito;
            soma = 0;

            for (var i = 0; i < 10; i++)
                soma += (tempCpf[i] - '0') * (11 - i);

            resto = soma % 11;
            digito = resto < 2 ? 0 : 11 - resto;

            return cpf[10] == digito + '0';
        }
    }
}
