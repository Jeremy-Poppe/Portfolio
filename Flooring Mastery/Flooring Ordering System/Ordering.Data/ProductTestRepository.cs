using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Ordering.Data.Interfaces;

namespace Ordering.Data
{
	public class ProductTestRepository : IProductRepo
	{
		List<Product> products = new List<Product>()
		{ new Product
			{
				ProductType = "Metal",
				MatericalCostPerSquareFoot = 5.00M,
				LaborCostPerSquareFoot = 5.00M,
			}, new Product
			{
				ProductType = "DryWall",
				MatericalCostPerSquareFoot = 10.00M,
				LaborCostPerSquareFoot = 5.00M,
			}, new Product
			{
			ProductType = "Wood",
			MatericalCostPerSquareFoot = 5.75M,
			LaborCostPerSquareFoot = 4.75M,
			},
		};
		public Product LoadProduct(string productType)
		{
			return products.SingleOrDefault(x => x.ProductType == productType);
		}
	}
}
