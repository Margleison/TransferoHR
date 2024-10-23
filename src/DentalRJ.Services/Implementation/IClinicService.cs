using DentalRJ.Services.Model;

namespace DentalRJ.Services.Implementation
{
    public interface IClinicService
    {
        Task<IEnumerable<ClinicGetStatesModel>> GetActiveStatesAsync();
    }
}
