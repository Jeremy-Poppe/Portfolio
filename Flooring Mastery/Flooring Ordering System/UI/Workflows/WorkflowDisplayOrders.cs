using System;
using System.Linq;
using System.Collections.Generic;
using Models;
using System.IO;
using FlooringOrdering.BLL;

namespace FlooringOrdering.UI
{
	public class WorkflowDisplayOrders
	{
		OrderManager manager;

		public WorkflowDisplayOrders()
		{
			manager = OrderManagerFactory.Create();
		}

		internal void Start()
		{
			{
				DateTime dateLookUp = UserInput.GetDateForDisplay();

				List<Order> listOfOrders = manager.GetAllOrders(dateLookUp);
				if (listOfOrders.Count > 0)
				{

					foreach (var row in listOfOrders)
					{
						UserOutput.DisplayOrders(row);
					}
				}
				else
				{
					UserOutput.OrderDoesNotExist();
				}
			}
			WorkflowDisplay backToBeginning = new WorkflowDisplay();
			backToBeginning.StartDisplayWorkflow();
		}
	}
}