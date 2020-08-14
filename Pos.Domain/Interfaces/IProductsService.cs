using System.Collections.Generic;
using System.Threading.Tasks;
using Pos.Domain.Entities;
using Pos.Domain.Infrastructure;

namespace Pos.Domain.Interfaces
{
    public interface IProductsService : IInitializer
    {
        Task<bool> AddProduct(Product product);
        Task<bool?> UpdateProduct(Product product);
        Task<bool?> DeleteProduct(int productId, bool removeRelatedEntities = false);
        Task<Product> FindProduct(int productId);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProduct(string barcode);
        Task<bool> AddProducts(List<Product> products);
    }
}