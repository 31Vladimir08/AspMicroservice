using AutoMapper;

using Discount.Grpc.Models;
using Discount.Grpc.Protos;

namespace Discount.Grpc.Mapper
{
    public class DiscountProfile : Profile
    { 
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>();
            CreateMap<CouponModel, Coupon>();
        }
    }
}
