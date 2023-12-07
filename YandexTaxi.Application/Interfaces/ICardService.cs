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
        ValueTask<bool> CreateCardAsync(CardDTO cardDTO);
        ValueTask<bool> DeleteCardAsync(int id);
        ValueTask<bool> UpdateCardAsync(int id, CardDTO cardDTO);
        ValueTask<Card> GetCardById(int id);
        ValueTask<bool> Replenishment(int cardNumber, decimal amount);//Karta balancini tuldirish
    }
}
