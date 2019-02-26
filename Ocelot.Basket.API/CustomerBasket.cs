using System.Collections.Generic;

namespace Ocelot.Basket.API
{
    public class CustomerBasket
    {
        public int BuyerId { get; set; }
        public List<BasketItem> Items { get; set; }
        public CustomerBasket(int buyerId)
        {
            BuyerId=buyerId;
            this.Items=new List<BasketItem>();
        }
    }
}