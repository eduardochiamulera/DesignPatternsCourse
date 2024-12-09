using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace DesignPatterns.src.GOF.Structural.Adapter.Checkout
{
	public interface CatalogGateway
	{
		Task<ProductDTO> GetProduct(int productId);
	}

	public class CatalogGatewayHttp : CatalogGateway
	{
		HttpClientApadter _httpClient;

		public CatalogGatewayHttp(HttpClientApadter httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<ProductDTO> GetProduct(int productId)
		{
			var response = await _httpClient.GetAsync($"http://localhost:5000/products/{productId}");

			var responseModel = JsonConvert.DeserializeObject<ProductDTO>(response);

			return responseModel;
		}
	}

	public record ProductDTO(int ProductId, string Description, decimal Price);

}
