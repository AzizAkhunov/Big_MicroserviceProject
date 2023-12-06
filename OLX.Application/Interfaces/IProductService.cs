using OLX.Domain.DTOs;
using OLX.Domain.Entities;

namespace OLX.Application.Interfaces
{
    public interface IProductService
    {
        ValueTask<ICollection<Product>> GetAllProductsAsync();
        ValueTask<bool> CreateUserAsync(ProductsDTO productDTO);
        ValueTask<bool> DeleteProductAsync(int id);
        ValueTask<bool> UpdateProductAsync(int id, ProductsDTO productDTO);
        ValueTask<Product> GetProductById(int id);
    }
}
