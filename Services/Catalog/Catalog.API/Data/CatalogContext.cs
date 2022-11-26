using Catalog.API.Entities;
using Catalog.API.Interfaces;

using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration, IMongoClient mongoClient) 
        {
            var db = mongoClient.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Products = db.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        }
        public IMongoCollection<Product> Products { get; private set; }
    }
}
