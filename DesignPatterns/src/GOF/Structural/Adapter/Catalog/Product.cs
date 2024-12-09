using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.src.GOF.Structural.Adapter.Catalog
{
	public class Product
	{
		public Product(int productId, string description, decimal price)
		{
			ProductId = productId;
			Description = description;
			Price = price;
		}

		public int ProductId { get; set; }
		public string Description { get; set; } = null!;
		public decimal Price { get; set; }

	}
}
