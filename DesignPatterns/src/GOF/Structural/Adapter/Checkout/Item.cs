namespace DesignPatterns.src.GOF.Structural.Adapter.Checkout
{
	public class Item
	{
		public Item(int productId, decimal price, int quantity)
		{
			ProductId = productId;
			Price = price;
			Quantity = quantity;
		}

		public int ProductId { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }

		public decimal GetTotal()
		{
			return Price * Quantity;
		}
	}
}