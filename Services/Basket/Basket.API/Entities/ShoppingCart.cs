namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart() 
        {
            Items = new List<ShoppingCartItem>();
        }

        public ShoppingCart(string userName)
        {
            UserName = userName;
            Items = new List<ShoppingCartItem>();
        }

        public string UserName { get; set; }
        public List<ShoppingCartItem> Items { get; set; }
        public decimal TotalPrice => Items.Sum(x => x.Price);
    }
}
