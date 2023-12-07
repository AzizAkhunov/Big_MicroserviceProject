using YandexTaxi.Application.Interfaces;
using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;

namespace YandexTaxi.Application.Services
{
    public class ScrinService : IScrinService
    {
        public ValueTask<bool> CreateScrinAsync(ScrinDTO scrinDTO)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> DeleteScrinAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<Scrin>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Card> GetScrinById(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<decimal> GiveToll(int scrinId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> PayWithBonus(ScrinDTO scrinDTO)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> UpdateScrinAsync(int id, ScrinDTO scrinDTO)
        {
            throw new NotImplementedException();
        }
    }
}
