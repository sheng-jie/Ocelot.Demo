namespace Ocelot.Basket.API {
    public class BasketItem {
        public BasketItem (int productId, int qty, decimal price) {
            this.ProductId = productId;
            this.Qty = qty;
            this.Price = price;
            this.LatestPrice = price;
        }
        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public decimal LatestPrice { get; set; }

        public int Qty { get; set; }
    }
}