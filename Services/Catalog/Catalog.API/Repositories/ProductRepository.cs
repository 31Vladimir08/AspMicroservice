using System.Xml.Linq;

using Catalog.API.Entities;
using Catalog.API.Interfaces;
using Catalog.API.Interfaces.Repositories;

using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext catalogContext)
        {
            _context = catalogContext;
        }

        public async Task CreateProductAsync(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProductAsync(string id)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.ProductId, id);
            var result = await _context.Products.DeleteOneAsync(filter);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<Product> GetProductAsync(string id)
        {
            var result = await _context.Products.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryAsync(string categoryName)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Name, categoryName);
            var result = await _context.Products.Find(filter).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> GetProductByNameAsync(string name)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Name, name);
            var result = await _context.Products.Find(filter).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var result = await _context.Products.Find(x => true).ToListAsync();
            return result;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var updateResult = await _context.Products.ReplaceOneAsync(filter: x => x.ProductId == product.ProductId, replacement: product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
