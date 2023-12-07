using Microsoft.EntityFrameworkCore;
using YandexTaxi.Application.Interfaces;
using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;
using YandexTaxi.Infastructure.DbContexts;

namespace YandexTaxi.Application.Services
{
    public class CardService : ICardService
    {
        private readonly YandexTaxiDbContext _context;

        public CardService(YandexTaxiDbContext context)
        {
            _context = context;
        }

        public async ValueTask<bool> CreateCardAsync(CardDTO cardDTO)
        {
            try
            {
                var card = new Card()
                {
                    CardNumber = cardDTO.CardNumber,
                    Verify = cardDTO.Verify,
                    Amount = cardDTO.Amount,
                    ClientId = cardDTO.ClientId,
                };
                await _context.Cards.AddAsync(card);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<bool> DeleteCardAsync(int id)
        {
            try
            {
                var result = await _context.Cards.FirstOrDefaultAsync(x => x.Id == id);

                _context.Cards.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<ICollection<Card>> GetAllAsync()
        {
            var result = await _context.Cards.ToListAsync();
            return result;
        }

        public async ValueTask<Card> GetCardById(int id)
        {
            var result = await _context.Cards.FirstOrDefaultAsync(x => x.Id == id);
            if (result is not null)
            {
                return result;
            }
            return new Card();
        }

        public async ValueTask<bool> UpdateCardAsync(int id, CardDTO cardDTO)
        {
            try
            {
                var result = await _context.Cards.FirstOrDefaultAsync(x => x.Id == id);
                if (result is not null)
                {
                    result.CardNumber = cardDTO.CardNumber;
                    result.Verify = cardDTO.Verify;
                    result.Amount = cardDTO.Amount;
                    result.ClientId = cardDTO.ClientId;
                    result.UpdatedAt = DateTime.Now;

                    _context.Cards.Update(result);
                    await _context.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            catch { return false; }
        }
        public async ValueTask<bool> Replenishment(int cardNumber,decimal amount)
        {
            try
            {
                var card = await _context.Cards.FirstOrDefaultAsync(x => x.CardNumber == cardNumber);
                if (card is not null)
                {
                    card.Amount += amount;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch { return false; }

        }
    }
}
