using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.src.GOF.Structural.Adapter.Catalog
{
	public class GetProduct
	{
		private readonly ProductRepository _productRepository;

		public GetProduct(ProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task<ProductDTO> Execute(int productId)
		{
			var product = await _productRepository.GetById(productId);

			return new ProductDTO(product.ProductId, product.Description, product.Price);
		}
	}

	public record ProductDTO(int ProductId, string Description, decimal Price);
}
