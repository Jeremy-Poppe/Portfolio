using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FlooringOrdering.BLL;
using Ordering.Data;

namespace FlooringOrdering.BLL
{
	public static class OrderManagerFactory
	{

		public static OrderManager Create()
		{
			string mode = ConfigurationManager.AppSettings["Mode"].ToString();

			string _orderPath = @"C:\Users\Jerem\Desktop\TheSoftwareGuild\jeremy-poppe-individual-work\Week-5\Flooring Mastery\Orders";
			string _taxPath = @"C:\Users\Jerem\Desktop\TheSoftwareGuild\jeremy-poppe-individual-work\Week-5\Flooring Mastery\Taxes.txt";
			string _productPath = @"C:\Users\Jerem\Desktop\TheSoftwareGuild\jeremy-poppe-individual-work\Week-5\Flooring Mastery\Products.txt";


			switch (mode)
			{
				case "OrderRepository":
					return new OrderManager(new OrderRepository(_orderPath), new TaxFileRepository(_taxPath), new ProductFilesRepository(_productPath));
				case "OrderTestRepository":
					return new OrderManager(new OrderTestRepository(), new TaxTestRepository(), new ProductTestRepository());
				default:
					throw new Exception("Mode value in app config is not valid");
			}
		}
	}
}
