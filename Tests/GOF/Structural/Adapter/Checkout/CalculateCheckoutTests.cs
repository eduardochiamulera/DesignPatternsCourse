using DesignPatterns.src.GOF.Structural.Adapter.Checkout;

namespace Tests.GOF.Structural.Adapter.Checkout
{
	public class CalculateCheckoutTests
	{
		[Fact]
		public async Task Deve_Calcular_Checkout()
		{
			var input = new InputDTO(new List<ItemDTO>
				{
					new ItemDTO(1,1),
					new ItemDTO(2, 2),
					new ItemDTO(3, 3)
				});
			var httpClient = new HttpClientAdapter();
			var catalogGateway = new CatalogGatewayHttp(httpClient);
			var calculateCheckout = new CalculateCheckout(catalogGateway);
			var output = await calculateCheckout.ExecuteAsync(input);
			
			Assert.True(output.Total == 1400);
		}
	}
}
