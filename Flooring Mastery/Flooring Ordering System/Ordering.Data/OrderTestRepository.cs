using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Ordering.Data.Interfaces;
using System.Linq;
using System.Xml.Linq;

namespace Ordering.Data
{
	public class OrderTestRepository : IOrderRepo
	{
		public static List<Order> _orders = new List<Order>
		{ new Order {
			OrderNumber = 1,
			CustomerName = "ABCCompany",
			State = "MN",
			TaxRate = .0625M,
			ProductType = "Wood",
			Area = 100.00M,
			MaterialCostPerSquareFoot = 5.15M,
			LaborCostPerSquareFoot = 4.75M,
			MaterialCost = 515,
			LaborCost = 475,
			Tax = 61.88M,
			Total = 1051.88M,
			Date = DateTime.Parse("January 1, 2013"),
		}, new Order {
			OrderNumber = 1,
			CustomerName = "NYCCompany",
			State = "NY",
			TaxRate = .0525M,
			ProductType = "Wood",
			Area = 500.00M,
			MaterialCostPerSquareFoot = 5.75M,
			LaborCostPerSquareFoot = 4.75M,
			MaterialCost = 287.5M,
			LaborCost = 237.5M,
			Tax = 61.88M,
			Total = 1051.88M,
			Date = DateTime.Parse("June 1, 2013"),
		}, new Order {
			OrderNumber = 1,
			CustomerName = "LAComany",
			State = "CA",
			TaxRate = .10M,
			ProductType = "Wood",
			Area = 100.00M,
			MaterialCostPerSquareFoot = 5.00M,
			LaborCostPerSquareFoot = 5.00M,
			MaterialCost = 500,
			LaborCost = 500,
			Tax = 61.88M,
			Total = 1000.00M,
			Date = DateTime.Parse("December 1, 2013"),
		  }
		};

		public void AddOrder(Order order)
		{
			Order addOrder = new Order()
			{
				OrderNumber = order.OrderNumber,
				CustomerName = order.CustomerName,
				State = order.CustomerName,
				TaxRate = order.TaxRate,
				ProductType = order.ProductType,
				Area = order.Area,
				MaterialCostPerSquareFoot = order.MaterialCostPerSquareFoot,
				LaborCostPerSquareFoot = order.LaborCostPerSquareFoot,
				MaterialCost = order.MaterialCost,
				LaborCost = order.LaborCost,
				Tax = order.Tax,
				Total = order.Total,
				Date = order.Date,
			};
			_orders.Add(addOrder);
		}

		public List<Order> GetAllOrders(DateTime dateDesired)
		{
			List<Order> orders = _orders.ToList();
			return orders;
		}

		public List<Order> GetAllOrders()
		{
			List<Order> orders = _orders.ToList();
			return orders;
		}

		public void RemoveOrder(Order order)
		{
			Order removedOrder = _orders.Where(x => x.Date == order.Date).SingleOrDefault(x => x.OrderNumber == order.OrderNumber);
			_orders.Remove(removedOrder);
		}
	}
}
