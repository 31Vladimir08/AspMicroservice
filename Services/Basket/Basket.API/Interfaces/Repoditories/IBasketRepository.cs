using Basket.API.Entities;

namespace Basket.API.Interfaces.Repoditories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart?> GetBasketAsync(string userName);
        Task<ShoppingCart?> UpdateBasketAsync(ShoppingCart basket);
        Task DeleteBasketAsync(string userName);
    }
}
