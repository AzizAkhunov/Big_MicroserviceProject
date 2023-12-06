using OLX.Domain.DTOs;
using OLX.Domain.Entities;

namespace OLX.Application.Interfaces
{
    public interface ISellService
    {
        ValueTask<ICollection<Sell>> GetAllSellAsync();
        ValueTask<bool> CreateUserAsync(SellsDTO sellDTO);
        ValueTask<bool> DeleteUserAsync(int id);
        ValueTask<bool> UpdateUserAsync(int id, SellsDTO sellDTO);
        ValueTask<Sell> GetSellById(int id);
    }
}
