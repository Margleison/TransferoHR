using System.Text.RegularExpressions;

namespace TransferoHR.Domain.Validators
{
    public static class BankNameValidator
    {
        public static bool Validate(string bankName)
        {

            if (string.IsNullOrWhiteSpace(bankName))
                return false;

            if (!Regex.IsMatch(bankName, @"^[a-zA-Z\s]+$"))
                return false;

            if (bankName.Length < 3 || bankName.Length > 50)
                return false;

            return true;
        }
    }
}
