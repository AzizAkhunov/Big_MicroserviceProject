using YandexTaxi.Application.Interfaces;
using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;

namespace YandexTaxi.Application.Services
{
    public class ClientService : IClientService
    {
        public ValueTask<bool> CreateClientAsync(ClientDTO clientDTO)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> DeleteClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<Client>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Client> GetDriverById(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> UpdateDriverAsync(int id, ClientDTO clientDTO)
        {
            throw new NotImplementedException();
        }
    }
}
