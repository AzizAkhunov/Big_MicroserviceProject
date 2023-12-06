using OLX.Domain.DTOs;
using OLX.Domain.Entities;

namespace OLX.Application.Interfaces
{
    public interface IProductService
    {
        ValueTask<ICollection<Product>> GetAllProductsAsync();
        ValueTask<bool> CreateUserAsync(ProductsDTO productDTO);
        ValueTask<bool> DeleteUserAsync(int id);
        ValueTask<bool> UpdateUserAsync(int id, ProductsDTO productDTO);
        ValueTask<Product> GetUserById(int id);
    }
}
