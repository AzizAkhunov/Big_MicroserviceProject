using OLX.Domain.DTOs;
using OLX.Domain.Entities;

namespace OLX.Application.Interfaces
{
    public interface ICardService
    {
        ValueTask<ICollection<Card>> GetAllCardAsync();
        ValueTask<bool> CreateCardAsync(CardsDTO cardDTO);
        ValueTask<bool> DeleteCardAsync(int id);
        ValueTask<bool> UpdateCardAsync(int id, CardsDTO cardDTO);
        ValueTask<Card> GetCardById(int id);
    }
}
