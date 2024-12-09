using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.src.GOF.Structural.Adapter.Catalog
{
	public interface ProductRepository
	{
		Task<Product> GetById(int id);
	}

	public class ProductRepositoryMemory : ProductRepository
	{
		private readonly IEnumerable<Product> _products;

		public ProductRepositoryMemory()
		{
			_products = new List<Product>
			{
				new Product(1, "A", 100),
				new Product(2, "B", 200),
				new Product(3, "C", 300),
			};
		}

		public async Task<Product> GetById(int id)
		{
			var product = _products.FirstOrDefault(x => x.ProductId == id);
			
			if (product == null)
			{
				throw new KeyNotFoundException();
			}

			return await Task.FromResult(product);
		}
	}
}
