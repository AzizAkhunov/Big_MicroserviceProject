using GAI.Api.ViewModels;
using GAI.Domain.Entities;

namespace GAI.Application.Interfaces
{
    public interface IDriverService
    {
        ValueTask<ICollection<Driver>> GetAllAsync();
        ValueTask<bool> CreateDriverAsync(DriverDTO driverDTO);
        ValueTask<bool> DeleteDriverAsync(int id);
        ValueTask<bool> UpdateDriverAsync(int id,DriverDTO driverDTO);
        ValueTask<Driver> GetDriverById(int id);
    }
}
