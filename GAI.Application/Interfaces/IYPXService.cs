using GAI.Domain.Entities;
using GAI.Domain.ViewModels;

namespace GAI.Application.Interfaces
{
    public interface IYPXService
    {
        ValueTask<ICollection<YPX>> GetAllAsync();
        ValueTask<bool> CreateYPXAsync(YPXDTO ypxDTO);
        ValueTask<bool> DeleteYPXAsync(int id);
        ValueTask<bool> UpdateYPXAsync(int id, YPXDTO ypxDTO);
        ValueTask<YPX> GetYPXById(int id);
        YPX GetYPXPunishments(int gaiId);
    }
}
