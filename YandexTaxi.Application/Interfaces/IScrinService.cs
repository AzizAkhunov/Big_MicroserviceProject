using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;

namespace YandexTaxi.Application.Interfaces
{
    public interface IScrinService
    {
        ValueTask<ICollection<Scrin>> GetAllAsync();
        ValueTask<bool> CreateScrinAsync(int id,ScrinDTO scrinDTO);
        ValueTask<bool> DeleteScrinAsync(int id);
        ValueTask<bool> UpdateScrinAsync(int id, ScrinDTO scrinDTO);
        ValueTask<Scrin> GetScrinById(int id);
        ValueTask<decimal> GiveToll(int scrinId); // Bu kira haqqii!!
        ValueTask<bool> PayWithBonus(int scrinId,int clientId);
    }
}
