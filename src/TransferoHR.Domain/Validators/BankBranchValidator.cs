using System.Text.RegularExpressions;

namespace TransferoHR.Domain.Validators
{
    public static class BankBranchValidator
    {
        public static bool Validate(string bankBranch)
        {
            if (string.IsNullOrWhiteSpace(bankBranch))
                return false;

            if (!Regex.IsMatch(bankBranch, @"^\d+$"))
                return false;

            if (bankBranch.Length < 3 || bankBranch.Length > 6)
                return false;

            return true;
        }
    }
}
