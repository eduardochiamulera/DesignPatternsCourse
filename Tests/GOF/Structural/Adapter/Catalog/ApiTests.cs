using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.GOF.Structural.Adapter.Catalog
{
	public class ApiTests
	{
		[Fact]
		public async Task Deve_Consultar_Um_Produto_Do_Catalogo()
		{
			using (var http = new HttpClient())
			{
				var response = await http.GetAsync("http://localhost:5000/products/1");
				var content = await response.Content.ReadAsStringAsync();

				var responseModel = JsonConvert.DeserializeObject<ProductDTO>(content);

				Assert.True(response.IsSuccessStatusCode);
				Assert.True(responseModel.ProductId == 1);
				Assert.True(responseModel.Description == "A");
				Assert.True(responseModel.Price == 100);
			}

		}
	}
	public record ProductDTO(int ProductId, string Description, decimal Price);
}
