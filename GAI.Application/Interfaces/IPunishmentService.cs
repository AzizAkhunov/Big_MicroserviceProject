using GAI.Domain.DTOs;
using GAI.Domain.Entities;

namespace GAI.Application.Interfaces
{
    public interface IPunishmentService
    {
        ValueTask<bool> CreatePunishmentAsync(PunishmentDTO punishmentDTO);
        ValueTask<ICollection<Punishment>> GetAllPunishmentsAsync();
        ValueTask<Punishment> GetPunishmentByIdAsync(int id);
        ValueTask<bool> DeletePunishmentByIdAsync(int id);
        ValueTask<bool> UpdatePunishmentAsync(int id,PunishmentDTO punishmentDTO); 
    }
}
