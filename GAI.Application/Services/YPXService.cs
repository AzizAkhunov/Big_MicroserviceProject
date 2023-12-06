using GAI.Application.Interfaces;
using GAI.Domain.Entities;
using GAI.Domain.ViewModels;
using GAI.Infastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GAI.Application.Services
{
    public class YPXService : IYPXService
    {
        private readonly GAIDbContext _dbContext;

        public YPXService(GAIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async ValueTask<bool> CreateYPXAsync(YPXDTO ypxDTO)
        {
            try
            {
                var ypx = new YPX()
                {
                    UserName = ypxDTO.UserName,
                    Password = ypxDTO.Password,
                    FirstName = ypxDTO.FirstName,
                    LastName = ypxDTO.LastName,
                    Passport = ypxDTO.Passport,
                    Description = ypxDTO.Description,
                    YPXDocument = ypxDTO.YPXDocument
                };
                await _dbContext.GAies.AddAsync(ypx);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<bool> DeleteYPXAsync(int id)
        {
            try
            {
                var result = await _dbContext.GAies.FirstOrDefaultAsync(x => x.Id == id);

                _dbContext.GAies.Remove(result);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<ICollection<YPX>> GetAllAsync()
        {
            var result = await _dbContext.GAies.ToListAsync();
            return result;
        }

        public async ValueTask<YPX> GetYPXById(int id)
        {
            var result = await _dbContext.GAies.FirstOrDefaultAsync(x => x.Id == id);
            if (result is not null)
            {
                return result;
            }
            return new YPX();
        }

        public async ValueTask<bool> UpdateYPXAsync(int id, YPXDTO ypxDTO)
        {
            try
            {
                var gai = await _dbContext.GAies.FirstOrDefaultAsync(x => x.Id == id);
                if (gai is not null)
                {
                    gai.UserName = ypxDTO.UserName;
                    gai.Password = ypxDTO.Password;
                    gai.FirstName = ypxDTO.FirstName;
                    gai.LastName = ypxDTO.LastName;
                    gai.Passport = ypxDTO.Passport;
                    gai.Description = ypxDTO.Description;
                    gai.YPXDocument = ypxDTO.YPXDocument;

                    _dbContext.GAies.Update(gai);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public YPX GetYPXPunishments(int gaiId)
        {
            YPX gai = _dbContext.GAies.FirstOrDefault(x => x.Id == gaiId);
            gai = _dbContext.GAies
                .Include(x => x.Punishments)
                .FirstOrDefault();

            return gai;
        }
    }
}
