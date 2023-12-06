using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;

namespace YandexTaxi.Application.Interfaces
{
    public interface ICardService
    {
        ValueTask<ICollection<Card>> GetAllAsync();
        ValueTask<bool> CreateCardAsync(CardDTO carDTO);
        ValueTask<bool> DeleteCardAsync(int id);
        ValueTask<bool> UpdateCardAsync(int id, CardDTO cardDTO);
        ValueTask<Card> GetCardById(int id);
    }
}
