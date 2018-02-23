using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrdering.UI;
using static System.Net.Mime.MediaTypeNames;

namespace FlooringOrdering.UI
{
	public class WorkflowDisplay
	{
		public void StartDisplayWorkflow()
		{
			UserOutput.SplashPage();
			int UserSelection = UserInput.Menu();
			switch (UserSelection)
			{
				case 1:
					WorkflowDisplayOrders startMethod = new WorkflowDisplayOrders();
					startMethod.Start();
					break;
				case 2:
					WorkflowAddAnOrder.Start();
					break;
				case 3:
					WorkflowEditAnOrder startEditMethod = new WorkflowEditAnOrder();
					startEditMethod.Start();
					break;
				case 4:
					WorkflowRemoveAnOrder startRemoveMethod = new WorkflowRemoveAnOrder();
					startRemoveMethod.Start();
					break;
				case 5:
					Environment.Exit(0);
					break;
			}

		}
	}
}
