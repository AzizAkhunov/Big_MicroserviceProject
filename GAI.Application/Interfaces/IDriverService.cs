using GAI.Domain.Entities;
using GAI.Domain.ViewModels;

namespace GAI.Application.Interfaces
{
    public interface IDriverService
    {
        ValueTask<ICollection<Driver>> GetAllAsync();
        ValueTask<bool> CreateDriverAsync(DriverDTO driverDTO);
        ValueTask<bool> DeleteDriverAsync(int id);
        ValueTask<bool> UpdateDriverAsync(int id, DriverDTO driverDTO);
        ValueTask<Driver> GetDriverById(int id);
    }
}
