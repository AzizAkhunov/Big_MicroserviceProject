using OLX.Application.Interfaces;
using OLX.Domain.DTOs;
using OLX.Domain.Entities;

namespace OLX.Application.Services
{
    public class ProductService : IProductService
    {
        public ValueTask<bool> CreateUserAsync(ProductsDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<Product>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Product> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> UpdateUserAsync(int id, ProductsDTO productDTO)
        {
            throw new NotImplementedException();
        }
    }
}
