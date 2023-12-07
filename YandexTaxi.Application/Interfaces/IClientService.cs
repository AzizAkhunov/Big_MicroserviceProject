using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;

namespace YandexTaxi.Application.Interfaces
{
    public interface IClientService
    {
        ValueTask<ICollection<Client>> GetAllAsync();
        ValueTask<bool> CreateClientAsync(ClientDTO clientDTO);
        ValueTask<bool> DeleteClientAsync(int id);
        ValueTask<bool> UpdateClientAsync(int id, ClientDTO clientDTO);
        ValueTask<Client> GetClientById(int id);
        ValueTask<bool> Leave_FeedBack(int driverId, string description);
    }
}
