using OLX.Domain.DTOs;
using OLX.Domain.Entities;

namespace OLX.Application.Interfaces
{
    public interface IBuyService
    {
        ValueTask<ICollection<Buy>> GetAllBuyAsync();
        ValueTask<bool> CreateBuyAsync(BuysDTO buyDTO);
        ValueTask<bool> DeleteBuyAsync(int id);
        ValueTask<bool> UpdateBuyAsync(int id, BuysDTO buyDTO);
        ValueTask<Buy> GetBuyById(int id);
    }
}
