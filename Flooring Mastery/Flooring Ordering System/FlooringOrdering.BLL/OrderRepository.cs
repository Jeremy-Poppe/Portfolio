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
	public class OrderRepository : IOrderRepo
	{
		private string _directoryPath;

		public OrderRepository(string directoryPath)
		{
			_directoryPath = directoryPath;
		}

		public List<Order> GetAllOrders(DateTime dateDesired)
		{
			var newPath = CreateFilePath(dateDesired);
			List<Order> orders = new List<Order>();
			if (File.Exists(newPath))
			{
				using (StreamReader sr = new StreamReader(newPath))
				{
					sr.ReadLine();
					string line;
					while ((line = sr.ReadLine()) != null)
					{
						Order newOrder = new Order();

						string[] columns = line.Split(',');

						newOrder.OrderNumber = Convert.ToInt32(columns[0]);
						newOrder.CustomerName = columns[1];
						newOrder.State = columns[2];
						newOrder.TaxRate = Convert.ToDecimal(columns[3]);
						newOrder.ProductType = columns[4];
						newOrder.Area = Convert.ToDecimal(columns[5]);
						newOrder.MaterialCostPerSquareFoot = Convert.ToDecimal(columns[6]);
						newOrder.LaborCostPerSquareFoot = Convert.ToDecimal(columns[7]);
						newOrder.MaterialCost = Convert.ToDecimal(columns[8]);
						newOrder.LaborCost = Convert.ToDecimal(columns[9]);
						newOrder.Tax = Convert.ToDecimal(columns[10]);
						newOrder.Total = Convert.ToDecimal(columns[11]);
						newOrder.Date = dateDesired;

						orders.Add(newOrder);
					}
				}
				
			}
			return orders;
		}
		public DateTime ExtractDatesFromFileNames(string fileName)
		{
			DateTime dateFromFile = new DateTime();

			string newFileName = fileName.Substring(fileName.IndexOf("_") + 1, 8);
			if (DateTime.TryParse(newFileName, out dateFromFile))
			{
				return dateFromFile;
			}
			else
			{
				Console.WriteLine("Unsuccessfull parse");
				return dateFromFile;
			}
		}
		public string CreateFilePath(DateTime orderDate)
		{
			string filePath = Path.Combine(_directoryPath, "Orders_" + orderDate.ToString("MMddyyyy") + ".txt");
			return filePath;
		}
		public void EditOrder(Order orderToBeAdded)
		{
			string filePath = CreateFilePath(orderToBeAdded.Date);
			List<Order> orders = GetAllOrders(orderToBeAdded.Date);

			using (StreamWriter sw = new StreamWriter(filePath))
			{
				string line = string.Format($"OrderNumber,CustomerName,State,TaxRate,ProductType,Area,MaterialCostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
				sw.WriteLine(line);
				for (int i = 0; i < orders.Count; i++)
				{
					if (orderToBeAdded.OrderNumber == orders[i].OrderNumber)
					{
						continue;
					}
					else
					{
						string line2 = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", orders[i].OrderNumber, orders[i].CustomerName, orders[i].State, orders[i].TaxRate, orders[i].ProductType, orders[i].Area, orders[i].MaterialCostPerSquareFoot, orders[i].LaborCostPerSquareFoot, orders[i].MaterialCost, orders[i].LaborCost, orders[i].Tax, orders[i].Total);
						sw.WriteLine(line2);
					}
				}
			}
		}
		public void AddOrder(Order toSave)
		{
			List<Order> orders = GetAllOrders(toSave.Date);
			orders.Add(toSave);
			string filePath = CreateFilePath(toSave.Date);
			using (StreamWriter writer = new StreamWriter(filePath))
			{
				writer.WriteLine();
				foreach(var row in orders)
				{
					string line = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", row.OrderNumber, row.CustomerName, row.State, row.TaxRate, row.ProductType, row.Area, row.MaterialCostPerSquareFoot, row.LaborCostPerSquareFoot, row.MaterialCost, row.LaborCost, row.Tax, row.Total, row.Date);
					writer.WriteLine(line);
				}
			}
		}
		public void RemoveOrder(Order order)
		{
			string filePath = CreateFilePath(order.Date);
			List<Order> orders = GetAllOrders(order.Date);
			if (orders.Count > 1)
			{
				using (StreamWriter sw = new StreamWriter(filePath))
				{
					string line = string.Format($"OrderNumber,CustomerName,State,TaxRate,ProductType,Area,MaterialCostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
					sw.WriteLine(line);
					for (int i = 0; i < orders.Count; i++)
					{
						if (order.OrderNumber == orders[i].OrderNumber)
						{
							continue;
						}
						else
						{
							string line2 = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", orders[i].OrderNumber, orders[i].CustomerName, orders[i].State, orders[i].TaxRate, orders[i].ProductType, orders[i].Area, orders[i].MaterialCostPerSquareFoot, orders[i].LaborCostPerSquareFoot, orders[i].MaterialCost, orders[i].LaborCost, orders[i].Tax, orders[i].Total);
							sw.WriteLine(line2);
						}
					}
				}
			}
			else
			{
				FileInfo fir = new FileInfo(filePath);
				fir.Delete();
			}


		}
	}
}
