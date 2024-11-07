using System.Text.RegularExpressions;

public class DniValidator
{
    public static bool Validate(string dni)
    {
        // Remove qualquer espaço em branco ou caractere especial
        dni = dni.Trim();

        // Verifica se o DNI contém apenas dígitos e tem 7 ou 8 caracteres
        if (Regex.IsMatch(dni, @"^\d{7,8}$"))
        {
            return true;
        }
        return false;
    }
}
