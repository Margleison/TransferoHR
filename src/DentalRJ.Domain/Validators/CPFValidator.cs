namespace DentalRJ.Domain.Validators
{
    public class CPFValidator
    {
        public static bool Validate(string cpf)
        {
            // Remove caracteres não numéricos
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            // Verifica se o CPF tem 11 dígitos
            if (cpf.Length != 11 || !cpf.All(char.IsDigit))
            {
                return false;
            }

            // Verifica se todos os dígitos são iguais
            if (cpf.All(c => c == cpf[0]))
            {
                return false;
            }

            // Cálculo do primeiro dígito verificador
            int[] cpfArray = cpf.Select(c => (int)char.GetNumericValue(c)).ToArray();
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += cpfArray[i] * (10 - i);
            }

            int firstDigit = 11 - (sum % 11);
            firstDigit = firstDigit >= 10 ? 0 : firstDigit;

            if (firstDigit != cpfArray[9])
            {
                return false;
            }

            // Cálculo do segundo dígito verificador
            sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += cpfArray[i] * (11 - i);
            }

            int secondDigit = 11 - (sum % 11);
            secondDigit = secondDigit >= 10 ? 0 : secondDigit;

            return secondDigit == cpfArray[10];
        }
    }
}
