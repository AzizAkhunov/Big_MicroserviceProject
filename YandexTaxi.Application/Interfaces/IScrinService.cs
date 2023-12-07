using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;

namespace YandexTaxi.Application.Interfaces
{
    public interface IScrinService
    {
        ValueTask<bool> CreateScrinAsync(ScrinDTO scrinDTO);
        ValueTask<string> DeleteScrinAsync(int id);
        ValueTask<Scrin> GetScrinById(int id);
        ValueTask<ICollection<Scrin>> GetAllAsync();
        ValueTask<decimal> GiveToll(int scrinId); // Bu kira haqqii!!
    }
}
