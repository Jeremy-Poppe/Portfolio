using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Ordering.Data.Interfaces;

namespace FlooringOrdering.BLL
{
	public class ProductFilesRepository : IProductRepo
	{
		private string _filePath;

		public ProductFilesRepository(string filePath)
		{
			_filePath = filePath;
		}
		public List<Product> LoadProducts()
		{
			List<Product> ProductInformation = new List<Product>();
			if (File.Exists(_filePath))
			{
				using (StreamReader sr = new StreamReader(_filePath))
				{
					sr.ReadLine();
					string line;
					while ((line = sr.ReadLine()) != null)
					{
						Product product = new Product();

						string[] columns = line.Split(',');

						product.ProductType = columns[0];
						product.MatericalCostPerSquareFoot = Convert.ToDecimal(columns[1]);
						product.LaborCostPerSquareFoot = Convert.ToDecimal(columns[2]);

						ProductInformation.Add(product);
					}
				}
			}
				return ProductInformation;
		}

		public Product LoadProduct(string productType)
		{
			Product selectedProduct = LoadProducts().SingleOrDefault(x => x.ProductType == productType);
			return selectedProduct;
		}
	}
}
