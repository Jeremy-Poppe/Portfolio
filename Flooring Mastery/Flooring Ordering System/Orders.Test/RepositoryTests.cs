using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrdering.BLL;
using Models;
using NUnit.Framework;
using Ordering.Data;

namespace Orders.Test
{
	[TestFixture]
	public class RepositoryTests
	{
		[Test]
		public void CanReadDataFomFile()
		{
			OrderTestRepository repo = new OrderTestRepository();

			List<Order> orders = repo.GetAllOrders();

			Assert.AreEqual(3, orders.Count());

			Order check = orders[1];

			Assert.AreEqual(1, check.OrderNumber);
			Assert.AreEqual("NYCCompany", check.CustomerName);
			Assert.AreEqual("NY", check.State);
			Assert.AreEqual(0.0525, check.TaxRate);
			Assert.AreEqual("Wood", check.ProductType);
			Assert.AreEqual(500, check.Area);
			Assert.AreEqual(5.75, check.MaterialCostPerSquareFoot);
			Assert.AreEqual(4.75, check.LaborCostPerSquareFoot);
			Assert.AreEqual(287.5, check.MaterialCost);
			Assert.AreEqual(237.5, check.LaborCost);
			Assert.AreEqual(61.88, check.Tax);
			Assert.AreEqual(1051.88, check.Total);
		}

		[Test]
		public void CanReadDataFromTaxFile()
		{
			TaxFileRepository repo = new TaxFileRepository(@"C:\Users\Jerem\Desktop\TheSoftwareGuild\jeremy-poppe-individual-work\Week-5\Flooring Mastery\Taxes.txt");

			List<TaxInformation> taxInformations = repo.LoadTax();

			Assert.AreEqual(4, taxInformations.Count());

			TaxInformation check = taxInformations[1];

			Assert.AreEqual("Pennsylvania", check.StateName);
			Assert.AreEqual(6.75, check.TaxRate);
			Assert.AreEqual("PA", check.StateAbbreviation);
		}

		[Test]
		public void CanReadDataFromProductFile()
		{
			ProductFilesRepository repo = new ProductFilesRepository(@"C:\Users\Jerem\Desktop\TheSoftwareGuild\jeremy-poppe-individual-work\Week-5\Flooring Mastery\Products.txt");

			List<Product> product = repo.LoadProducts();

			Assert.AreEqual(4, product.Count());

			Product check = product[3];

			Assert.AreEqual("Wood", check.ProductType);
			Assert.AreEqual(4.75M, check.LaborCostPerSquareFoot);
			Assert.AreEqual(5.15M, check.MatericalCostPerSquareFoot);
		}

	}
}
