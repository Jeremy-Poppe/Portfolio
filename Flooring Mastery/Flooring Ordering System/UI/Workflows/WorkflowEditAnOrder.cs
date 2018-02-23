using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Responses;
using FlooringOrdering.BLL;
using Models;
using System.IO;

namespace FlooringOrdering.UI
{
	internal class WorkflowEditAnOrder
	{
		OrderManager manager;

		public WorkflowEditAnOrder()
		{
			manager = OrderManagerFactory.Create();
		}
		public void Start()
		{
		
			DateTime dateToBeEdited = UserInput.EditAskForDate();
			int orderNumber = UserInput.EditAskForOrderNumber();
			Order orderToBeEdited = manager.LoadOrder(dateToBeEdited, orderNumber);
			Order copiedOrder = new Order(orderToBeEdited);
			UserOutput.ChangeCustomerName();
			string nameInput = Console.ReadLine();
			if (nameInput != "")
			{
				copiedOrder.CustomerName = nameInput;
			}

			UserOutput.AskForStateToAddOrder();
			string stateInput = Console.ReadLine();
			if (stateInput != "")
			{
				copiedOrder.State = stateInput;
			}

			UserOutput.AskForProduct();
			string productType = Console.ReadLine();
			if (productType != "")
			{
				copiedOrder.ProductType = productType;
			}

			UserOutput.GetArea();
			string area = (Console.ReadLine());
			int x = int.MinValue;
			bool invalidAnswer = true;
			while (invalidAnswer)
			{
				if (!int.TryParse(area, out int areaNumber) || areaNumber < 100)
				{
					Console.WriteLine("Invalid input");
				}
				else
				{
					x = areaNumber;
					invalidAnswer = false;
				}
			}
			copiedOrder.Area = x;

			OrderManager om = OrderManagerFactory.Create();
			om.CalculateOrder(copiedOrder);

			UserOutput.DisplayOrders(copiedOrder);

			UserOutput.WouldYouLikeToEdit();
			bool EditAnOrder = UserInput.EditAnOrder();
			if (EditAnOrder)
			{
				EditOrderResponse response = om.EditOrder(orderToBeEdited);
				if (response.Success)
				{
					om.RemoveOrder(orderToBeEdited);
					om.AddOrder(copiedOrder);
				}
			}
			Console.ReadLine();
			WorkflowDisplay reRunStart = new WorkflowDisplay();
			reRunStart.StartDisplayWorkflow();
		}
	}
}