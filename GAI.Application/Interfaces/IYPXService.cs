using GAI.Domain.DTOs;
using GAI.Domain.Entities;

namespace GAI.Application.Interfaces
{
    public interface IYPXService
    {
        ValueTask<ICollection<YPX>> GetAllAsync();
        ValueTask<bool> CreateYPXAsync(YPXDTO ypxDTO);
        ValueTask<bool> DeleteYPXAsync(int id);
        ValueTask<bool> UpdateYPXAsync(int id, YPXDTO ypxDTO);
        ValueTask<YPX> GetYPXById(int id);
    }
}
