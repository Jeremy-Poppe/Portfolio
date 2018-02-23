using System;
using System.Collections.Generic;
using System.IO;
using BLL.Responses;
using FlooringOrdering.BLL;
using Models;

namespace FlooringOrdering.UI
{
	internal static void Start()
	{
		Order addOrder = new Order();

		addOrder.Date = UserInput.GetDateToAddAnOrder();
		addOrder.CustomerName = UserInput.GetCustomerName();
		addOrder.State = UserInput.GetStateName();
		addOrder.ProductType = UserInput.GetProductType();
		addOrder.Area = UserInput.GetArea();

		OrderManager om = OrderManagerFactory.Create();
		AddNewOrderResponse response = om.AddOrderResponse(addOrder);
		Console.WriteLine(response.Message);
		if (response.Success)
		{
			om.AddOrder(addOrder);
		}
		Console.ReadLine();
		WorkflowDisplay reRunStart = new WorkflowDisplay();
		reRunStart.StartDisplayWorkflow();
	}
	}
}