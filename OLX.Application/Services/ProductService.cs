using Microsoft.EntityFrameworkCore;
using OLX.Application.Interfaces;
using OLX.Domain.DTOs;
using OLX.Domain.Entities;
using OLX.Infastructure.DbContexts;
using System.Diagnostics;
using System.Drawing;
using System.Net.NetworkInformation;

namespace OLX.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly OLXDbContext _context;

        public ProductService(OLXDbContext context)
        {
            _context = context;
        }
        public async ValueTask<bool> CreateUserAsync(ProductsDTO productDTO)
        {
            try
            {
                var product = new Product()
                {
                    Name = productDTO.Name,
                    UserId = productDTO.UserId,
                    Category = productDTO.Category,
                    Size = productDTO.Size,
                    Price = productDTO.Price,
                    Status = productDTO.Status,
                };
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<bool> DeleteUserAsync(int id)
        {
            try
            {
                var result = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

                _context.Products.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<ICollection<Product>> GetAllProductsAsync()
        {
            var result = await _context.Products.ToListAsync();
            return result;
        }

        public async ValueTask<Product> GetUserById(int id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (result is not null)
            {
                return result;
            }
            return new Product();
        }

        public async ValueTask<bool> UpdateUserAsync(int id, ProductsDTO productDTO)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product is not null)
            {
                try
                {
                    product.Name = productDTO.Name;
                    product.UserId = productDTO.UserId;
                    product.Category = productDTO.Category;
                    product.Size = productDTO.Size;
                    product.Price = productDTO.Price;
                    product.Status = productDTO.Status;
                    product.UpdatedAt = DateTime.Now;
                    _context.Products.Update(product);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}
