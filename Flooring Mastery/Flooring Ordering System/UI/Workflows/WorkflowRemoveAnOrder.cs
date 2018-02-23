using System;
using System.Linq;
using FlooringOrdering.BLL;
using Models;

namespace FlooringOrdering.UI
{
	internal class WorkflowRemoveAnOrder
	{
		OrderManager manager;

		public WorkflowRemoveAnOrder()
		{
			manager = OrderManagerFactory.Create();
		}

		internal void Start()
		{
			DateTime dateToBeEdited = UserInput.DeleteAskForDate();
			int orderNumber = UserInput.DeleteAskForOrderNumber();
			Order orderToBeRemoved = manager.GetAllOrders(dateToBeEdited).SingleOrDefault(x => x.OrderNumber == orderNumber);
			UserOutput.DisplayOrders(orderToBeRemoved);
			bool confirmation = UserInput.ConfirmRemoval();
			if (confirmation)
			{
				manager.RemoveOrder(orderToBeRemoved);
			}
			UserOutput.DeletedMessage();
			Console.ReadLine();
			WorkflowDisplay reRunStart = new WorkflowDisplay();
			reRunStart.StartDisplayWorkflow();
		}
	}
}