using Dapper;

using Discount.Grpc.Interfaces;
using Discount.Grpc.Models;

using Microsoft.Extensions.Options;

using Npgsql;

namespace Discount.Grpc.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly DataBaseSettings _dataBaseSettings;
        public DiscountRepository(IOptions<DataBaseSettings> dataBaseSettings) 
        {
            _dataBaseSettings = dataBaseSettings.Value;
        }
        public async Task<bool> CreateDiscountAsync(Coupon coupon)
        {
            using (var connection = new NpgsqlConnection(_dataBaseSettings.ConnectionString))
            {
                var query = $@"INSERT INTO Coupon (ProductName, Description, Amount) VALUES ('{coupon.ProductName}', '{coupon.Description}', {coupon.Amount})";
                var affected =
                await connection.ExecuteAsync(query);

                return affected != 0;
            };            
        }

        public async Task<bool> DeleteDiscountAsync(string productName)
        {
            using (var connection = new NpgsqlConnection(_dataBaseSettings.ConnectionString))
            {
                var query = $@"DELETE FROM Coupon WHERE ProductName = '{productName}'";
                var affected = await connection.ExecuteAsync(query);
                return affected != 0;
            }
        }

        public async Task<Coupon> GetDiscountAsync(string productName)
        {
            using (var connection = new NpgsqlConnection(_dataBaseSettings.ConnectionString))
            {
                var query = $@"SELECT * FROM 
                    Coupon WHERE ProductName = '{productName}'";
                var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>(query);
                return coupon == null 
                    ? new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" } 
                    : coupon;
            }
        }

        public async Task<bool> UpdateDiscountAsync(Coupon coupon)
        {
            using (var connection = new NpgsqlConnection(_dataBaseSettings.ConnectionString))
            {
                var query = $@"UPDATE Coupon SET ProductName = '{coupon.ProductName}', Description = '{coupon.Description}', Amount = {coupon.Amount} WHERE Id = {coupon.Id}";
                var affected = await connection.ExecuteAsync(query);

                return affected != 0;
            };
        }
    }
}
