using Discount.Grpc.Protos;

namespace Basket.API.Interfaces.Services
{
    public interface IDiscountGrpcService
    {
        Task<CouponModel> GetDiscountAsync(string productName);
    }
}
