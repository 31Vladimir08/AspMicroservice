using System.Runtime.InteropServices;

using Basket.API.Entities;
using Basket.API.Interfaces.Repoditories;

using Microsoft.Extensions.Caching.Distributed;

using Newtonsoft.Json;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _distributedCache;

        public BasketRepository(IDistributedCache distributedCache) 
        {
            _distributedCache = distributedCache;
        }
        public async Task DeleteBasketAsync(string userName)
        {
            await _distributedCache.RemoveAsync(userName);
        }

        public async Task<ShoppingCart?> GetBasketAsync(string userName)
        {
            var basket = await _distributedCache.GetStringAsync(userName);
            return string.IsNullOrEmpty(basket) 
                ? null 
                : JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart?> UpdateBasketAsync(ShoppingCart basket)
        {
            await _distributedCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));
            return await GetBasketAsync(basket.UserName);
        }
    }
}
