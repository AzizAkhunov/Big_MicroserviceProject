using OLX.Domain.DTOs;
using OLX.Domain.Entities;

namespace OLX.Application.Interfaces
{
    public interface IBuyService
    {
        ValueTask<ICollection<Buy>> GetAllBuyAsync();
        ValueTask<bool> CreateBuyAsync(BuysDTO driverDTO);
        ValueTask<bool> DeleteBuyAsync(int id);
        ValueTask<bool> UpdateUserAsync(int id, BuysDTO driverDTO);
        ValueTask<Buy> GetUserById(int id);
    }
}
