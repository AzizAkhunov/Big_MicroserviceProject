using OLX.Application.Interfaces;
using OLX.Domain.DTOs;
using OLX.Domain.Entities;

namespace OLX.Application.Services
{
    public class CardService : ICardService
    {
        public ValueTask<bool> CreateCardAsync(CardsDTO cardDTO)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> DeleteCardAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<Card>> GetAllCardAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> GetCardById(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> UpdateCardAsync(int id, CardsDTO cardDTO)
        {
            throw new NotImplementedException();
        }
    }
}
