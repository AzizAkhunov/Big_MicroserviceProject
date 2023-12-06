using Microsoft.EntityFrameworkCore;
using OLX.Application.Interfaces;
using OLX.Domain.DTOs;
using OLX.Domain.Entities;
using OLX.Infastructure.DbContexts;

namespace OLX.Application.Services
{
    public class CardService : ICardService
    {
        private readonly OLXDbContext _context;

        public CardService(OLXDbContext context)
        {
            _context = context;
        }
        public async ValueTask<bool> CreateCardAsync(CardsDTO cardDTO)
        {
            try
            {
                var card = new Card()
                {
                    CardNumber = cardDTO.CardNumber,
                    Verify = cardDTO.Verify,
                    Amount = cardDTO.Amount,
                    UserId = cardDTO.UserId,
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

        public async ValueTask<ICollection<Card>> GetAllCardAsync()
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

        public async ValueTask<bool> UpdateCardAsync(int id, CardsDTO cardDTO)
        {
            try
            {
                var result = await _context.Cards.FirstOrDefaultAsync(x => x.Id == id);
                if (result is not null)
                {
                    result.CardNumber = cardDTO.CardNumber;
                    result.Verify = cardDTO.Verify;
                    result.Amount = cardDTO.Amount;
                    result.UserId = cardDTO.UserId;
                    result.UpdatedAt = DateTime.Now;

                    _context.Cards.Update(result);
                    await _context.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
