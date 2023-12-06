using OLX.Application.Interfaces;
using OLX.Domain.DTOs;
using OLX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLX.Application.Services
{
    public class BuyService : IBuyService
    {
        public ValueTask<bool> CreateBuyAsync(BuysDTO driverDTO)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> DeleteBuyAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<Buy>> GetAllBuyAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Buy> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> UpdateUserAsync(int id, BuysDTO driverDTO)
        {
            throw new NotImplementedException();
        }
    }
}
