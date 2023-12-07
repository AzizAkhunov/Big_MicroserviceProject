using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;

namespace YandexTaxi.Application.Interfaces
{
    public interface IScrinService
    {
        ValueTask<ICollection<Scrin>> GetAllAsync();
        ValueTask<bool> CreateScrinAsync(ScrinDTO scrinDTO);
        ValueTask<bool> DeleteScrinAsync(int id);
        ValueTask<bool> UpdateScrinAsync(int id, ScrinDTO scrinDTO);
        ValueTask<Card> GetScrinById(int id);
        ValueTask<decimal> GiveToll(int scrinId); // Bu kira haqqii!!
        ValueTask<string> PayWithBonus(ScrinDTO scrinDTO);
    }
}
