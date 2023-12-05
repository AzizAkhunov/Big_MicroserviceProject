using GAI.Application.Interfaces;
using GAI.Domain.Entities;
using GAI.Domain.ViewModels;
using GAI.Infastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace GAI.Application.Services
{
    public class PunishmentService : IPunishmentService
    {
        private readonly GAIDbContext _dbContext;

        public PunishmentService(GAIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask<bool> CreatePunishmentAsync(PunishmentDTO punishmentDTO)
        {
            try
            {
                var punishment = new Punishment()
                {
                    YPXId = punishmentDTO.YPXId,
                    DriverId = punishmentDTO.DriverId,
                    Price = punishmentDTO.Price,
                    Description = punishmentDTO.Description,
                };

                await _dbContext.AddAsync(punishment);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<bool> DeletePunishmentByIdAsync(int id)
        {
            try
            {
                var punishment = await _dbContext.Punishments.FirstOrDefaultAsync(x => x.Id == id);
                if (punishment != null)
                {
                    _dbContext.Punishments.Remove(punishment);
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

        public async ValueTask<ICollection<Punishment>> GetAllPunishmentsAsync()
        {
            var result = await _dbContext.Punishments.ToListAsync();
            return result;
        }

        public async ValueTask<Punishment> GetPunishmentByIdAsync(int id)
        {
            var punishment = await _dbContext.Punishments.FirstOrDefaultAsync(x => x.Id == id);

            return punishment;
        }

        public async ValueTask<bool> UpdatePunishmentAsync(int id, PunishmentDTO punishmentDTO)
        {
            try
            {
                var punishment = await _dbContext.Punishments.FirstOrDefaultAsync(x => x.Id == id);
                if (punishment is not null)
                {
                    punishment.YPXId = punishmentDTO.YPXId;
                    punishment.DriverId = punishmentDTO.DriverId;
                    punishment.Price = punishmentDTO.Price;
                    punishment.Description = punishmentDTO.Description;

                    _dbContext.Punishments.Update(punishment);
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
    }
}
