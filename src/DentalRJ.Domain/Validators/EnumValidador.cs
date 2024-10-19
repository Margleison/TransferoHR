using System;

namespace DentalRJ.Domain.Validators
{
    public static class EnumValidator
    {
        public static bool Validate<T>(string value) where T : Enum
        {
            return Enum.IsDefined(typeof(T), value);
        }
    }
}
