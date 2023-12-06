using OLX.Domain.DTOs;
using OLX.Domain.Entities;

namespace OLX.Application.Interfaces
{
    public interface ISellService
    {
        ValueTask<ICollection<Sell>> GetAllSellAsync();
        ValueTask<bool> CreateSellAsync(SellsDTO sellDTO);
        ValueTask<bool> DeleteSellAsync(int id);
        ValueTask<bool> UpdateSellAsync(int id, SellsDTO sellDTO);
        ValueTask<Sell> GetSellById(int id);
    }
}
