namespace DesignPatterns.src.GOF.Structural.Adapter.Checkout
{
	public class Order
	{
		private List<Item> _items { get; set; }
		public Order()
		{
			_items = new List<Item>();
		}

		public void addProduct(ProductDTO productDTO, int quantity)
		{
			_items.Add(new Item(productDTO.ProductId, productDTO.Price, quantity));
		}

		public decimal GetTotal()
		{
			decimal total = 0;

			foreach (var item in _items) { 
				total += item.GetTotal();
			}
			
			return total;
		}
	}
}