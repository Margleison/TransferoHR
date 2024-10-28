using System.Text.RegularExpressions;
using TransferoHR.Domain.Exceptions;

namespace TransferoHR.Domain.Validators
{
    public static class CNPJValidator
    {
        public static bool Validate(string cnpj)
        {
            // Remove caracteres especiais (pontos, traços, barras) se houver
            cnpj = Regex.Replace(cnpj, @"[^\d]", "");

            // Verifica se o CNPJ tem 14 dígitos
            if (cnpj.Length != 14)
                return false;

            // Verifica se todos os dígitos são iguais (ex: 11111111111111 é inválido)
            if (new string(cnpj[0], cnpj.Length) == cnpj)
                return false;

            // Cálculo do primeiro dígito verificador
            int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();

            tempCnpj += digito;

            // Cálculo do segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            // Verifica se os dois dígitos calculados correspondem aos dígitos do CNPJ
            return cnpj.EndsWith(digito);
        }
    }
}
