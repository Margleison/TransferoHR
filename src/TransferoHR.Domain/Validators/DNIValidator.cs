using System.Text.RegularExpressions;

public class ForeignIdentificationDocumentValidator
{
    public static bool Validate(string ForeignIdentificationDocument)
    {
        // Remove qualquer espaço em branco ou caractere especial
        ForeignIdentificationDocument = ForeignIdentificationDocument.Trim();

        // Verifica se o ForeignIdentificationDocument contém apenas dígitos e tem 7 ou 8 caracteres
        if (Regex.IsMatch(ForeignIdentificationDocument, @"^\d{7,8}$"))
        {
            return true;
        }
        return false;
    }
}
