namespace DesignPatterns.src.GOF.Structural.Adapter.Checkout
{
	public class CalculateCheckout
	{
		public readonly CatalogGateway _catalogGateway;

		public CalculateCheckout(CatalogGateway catalogGateway)
		{
			_catalogGateway = catalogGateway;
		}

		public async Task<OutputDTO> ExecuteAsync(InputDTO input)
		{

			var order = new Order();

			foreach (var item in input.Items)
			{
				var product = await this._catalogGateway.GetProduct(item.ProductId);
				order.addProduct(new ProductDTO(product.ProductId, product.Description, product.Price), item.Quantity);
			}

			return new OutputDTO(order.GetTotal());
		}
	}

	public record ItemDTO(int ProductId, int Quantity);
	public record InputDTO(IEnumerable<ItemDTO> Items);

	public record OutputDTO(decimal Total);
}
