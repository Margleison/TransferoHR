using TransferoHR.Domain.Exceptions;

namespace TransferoHR.Domain.Validators;

public class StringValidador
{
    public static void Validate(string toValidate, string fieldName, int exactSize = 0, int minSize = 0, int maxSize = 0)
    {
        toValidate = toValidate.Trim();
        if (exactSize > 0)
        {
            if (toValidate.Length != exactSize)
                throw new DomainException($"{fieldName} must be exact size of - {exactSize}");
        }
        else
        {
            if (maxSize > 0 && toValidate.Length < minSize)
                throw new DomainException($"{fieldName} minimum size is - {minSize}");

            if (maxSize > 0 && toValidate.Length > maxSize)
                throw new DomainException($"{fieldName} maximum size is - {maxSize}");
        }
    }
}