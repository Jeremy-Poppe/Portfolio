using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class Order
	{
		public int OrderNumber { get; set; }
		public string CustomerName { get; set; }
		public string State { get; set; }
		public decimal TaxRate { get; set; }
		public string ProductType { get; set; }
		public decimal Area { get; set; }
		public decimal MaterialCostPerSquareFoot { get; set; }
		public decimal LaborCostPerSquareFoot { get; set; }
		public decimal MaterialCost { get; set; }
		public decimal LaborCost { get; set; }
		public decimal Tax { get; set; }
		public decimal Total { get; set; }
		public DateTime Date { get; set; }

		public Order()
		{
		}
		public Order(Order that)
		{
			this.OrderNumber = that.OrderNumber;
			this.CustomerName = that.CustomerName;
			this.State = that.State;
			this.TaxRate = that.TaxRate;
			this.ProductType = that.ProductType;
			this.Area = that.Area;
			this.MaterialCostPerSquareFoot = that.MaterialCostPerSquareFoot;
			this.LaborCostPerSquareFoot = that.MaterialCostPerSquareFoot;
			this.LaborCost = that.LaborCostPerSquareFoot;
			this.Tax = that.Tax;
			this.Total = that.Total;
			this.Date = that.Date;
		}
	}
}
