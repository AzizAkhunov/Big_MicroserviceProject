using Microsoft.EntityFrameworkCore;
using YandexTaxi.Application.Interfaces;
using YandexTaxi.Domain.DTOs;
using YandexTaxi.Domain.Entities;
using YandexTaxi.Infastructure.DbContexts;

namespace YandexTaxi.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly YandexTaxiDbContext _context;

        public ClientService(YandexTaxiDbContext context)
        {
            _context = context;
        }
        public async ValueTask<bool> CreateClientAsync(ClientDTO clientDTO)
        {
            try
            {
                var client = new Client()
                {
                    FirstName = clientDTO.FirstName,
                    LastName = clientDTO.LastName,
                    PhoneNumber = clientDTO.PhoneNumber,
                };
                await _context.Clients.AddAsync(client);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<bool> DeleteClientAsync(int id)
        {
            try
            {
                var result = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);

                _context.Clients.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<ICollection<Client>> GetAllAsync()
        {
            var result = await _context.Clients.ToListAsync();
            return result;
        }

        public async ValueTask<Client> GetClientById(int id)
        {
            var result = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
            if (result is not null)
            {
                return result;
            }
            return new Client();
        }

        public async ValueTask<bool> UpdateClientAsync(int id, ClientDTO clientDTO)
        {
            try
            {
                var result = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
                if (result is not null)
                {
                    result.FirstName = clientDTO.FirstName;
                    result.LastName = clientDTO.LastName;
                    result.PhoneNumber = clientDTO.PhoneNumber;
                    result.UpdatedAt = DateTime.Now;

                    _context.Clients.Update(result);
                    await _context.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            catch { return false; }
        }
        public async ValueTask<bool> Leave_FeedBack(int orderId,string description)
        {
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == orderId);
                if (order is not null)
                {
                    order.Description = description;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
