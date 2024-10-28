using System.Text.RegularExpressions;

namespace TransferoHR.Domain.Validators;

public static class EmailValidador
{
    public static bool Validate(string email)
    {
        // Regex para validar o formato do e-mail
        var regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        return regex.IsMatch(email);
    }
}