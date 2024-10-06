namespace DentalRJ.Services.Exceptions;
public class ServiceException : Exception
{
    public ServiceException(string message) : base(message) {     }

    public static void When(bool condition, string message)
    {
        if (condition) throw new ServiceException(message);
    }
}