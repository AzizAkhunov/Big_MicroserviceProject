using OLX.Application.Interfaces;
using OLX.Domain.DTOs;
using OLX.Domain.Entities;

namespace OLX.Application.Services
{
    public class SellService : ISellService
    {
        public ValueTask<bool> CreateUserAsync(SellsDTO sellDTO)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<Sell>> GetAllSellAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Sell> GetSellById(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> UpdateUserAsync(int id, SellsDTO sellDTO)
        {
            throw new NotImplementedException();
        }
    }
}
