using System;
using Models;

namespace FlooringOrdering.UI
{
	public class UserOutput
	{
		internal static void SplashPage()
		{
			Console.WriteLine("1. Display Orders");
			Console.WriteLine("2. Add an Order");
			Console.WriteLine("3. Edit an Order");
			Console.WriteLine("4. Remove an Order");
			Console.WriteLine("5. Quit"); 
		}

		internal static void WouldYouLikeToEdit()
		{
			Console.WriteLine("Would you like to edit an order?");
		}

		internal static void AskForDate()
		{
			Console.WriteLine("Please enter the date of for all of the orders you would like to look up");
		}

		internal static void AskForOrderNumberToDelete()
		{
			Console.WriteLine("Please enter the order number you would like to delete");
		}

		internal static void DeletedMessage()
		{
			Console.WriteLine("The order has been removed");
		}

		internal static void DeleteAskForDate()
		{
			Console.WriteLine("Please enter the date for the order you would like to delete");
		}

		internal static void ResponseMessage(string message)
		{
			Console.WriteLine(message);
		}

		internal static void DisplayOrders(Order order)
		{	
			Console.WriteLine($"{order.OrderNumber} | {order.Date}");
			Console.WriteLine($"{order.CustomerName}");
			Console.WriteLine($"{order.State}");
			Console.WriteLine($"Product: {order.ProductType}");
			Console.WriteLine($"Materials: {order.MaterialCost}");
			Console.WriteLine($"Labor: {order.LaborCost}");
			Console.WriteLine($"Tax: {order.Tax}");
			Console.WriteLine($"Total: {order.Total}");

		}

		internal static void ConfirmRemoval()
		{
			Console.WriteLine("Would you like this order to be removed");
		}

		internal static void ChangeCustomerName()
		{
			Console.WriteLine("Please enter the edited name for the order");
		}

		internal static void OrderDoesNotExist()
		{
			Console.WriteLine("The order does not exist");
		}

		internal static void EditAskForOrderNumber()
		{
			Console.WriteLine("Please enter the order number of the order you would like to edit");
		}

		internal static void EditAskForDate()
		{
			Console.WriteLine("Please enter the date of the order you would like to edit");
		}

		internal static void GetArea()
		{
			Console.WriteLine("Please enter the area for the product");
		}

		internal static void AskForProduct()
		{
			Console.WriteLine("Please enter the product type for the new order");
		}

		internal static void AskForStateToAddOrder()
		{
			Console.WriteLine("Please enter the name of the state for the new order");
		}

		public static void AskForCustomerName()
		{
			Console.WriteLine("Please enter the customer name");
		}

		public static void AskForDateToAddOrder()
		{
			Console.WriteLine("Please enter the date of the order you would like to add");
		}

		internal static void InputErrorMessage()
		{
			Console.WriteLine("Please re-enter a valid input");
		}
	}
}