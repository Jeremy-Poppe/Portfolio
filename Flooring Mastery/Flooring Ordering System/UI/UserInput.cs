using System;

namespace FlooringOrdering.UI
{
	public class UserInput
	{
		internal static int Menu()
		{
			bool invalidAnswer = true;
			int y = int.MinValue;
			while (invalidAnswer)
			{
				string input = Console.ReadLine();

				if(int.TryParse(input, out int x))
				{
					y = x;
					break;

				}
				else
				{
					Console.WriteLine("Invalid entry, please enter again");
					invalidAnswer = true;
					break;
				}
			}
			return y;
		}

		internal static int DeleteAskForOrderNumber()
		{
			bool invalidAnswer = true;
			UserOutput.AskForOrderNumberToDelete();
			int y = int.MinValue;
			while (invalidAnswer)
			{
				string input = Console.ReadLine();

				if (int.TryParse(input, out int x))
				{
					y = x;
					break;

				}
				else
				{
					Console.WriteLine("Invalid entry, please enter again");
					invalidAnswer = true;
					break;
				}
			}
			return y;
		}

		internal static bool ConfirmRemoval()
		{
			UserOutput.ConfirmRemoval();
			bool DeleteAnOrder = false;
			bool invalidAnswer = true;
			while (invalidAnswer)
			{
				string answer = Console.ReadLine();

				if (answer.ToLower() == "yes")
				{
					invalidAnswer = false;
					DeleteAnOrder = true;
				}
				else if (answer.ToLower() == "no")
				{
					invalidAnswer = false;
					DeleteAnOrder = false;
				}
				else
				{
					invalidAnswer = true;
					UserOutput.WouldYouLikeToEdit();
				}
			}
			return DeleteAnOrder;

		}

		internal static DateTime DeleteAskForDate()
		{
			UserOutput.DeleteAskForDate();
			string lookUpDate = Console.ReadLine();
			DateTime dateLookUp;
			if (!DateTime.TryParse(lookUpDate, out dateLookUp))
			{
				UserOutput.InputErrorMessage();
			}
			return dateLookUp;
		}

		internal static bool EditAnOrder()
		{
			bool EditAnOrder = false;
			bool invalidAnswer = true;
			while (invalidAnswer)
			{
				string answer = Console.ReadLine();

				if (answer.ToLower() == "yes")
				{
					invalidAnswer = false;
					EditAnOrder = true;
				}
				else if (answer.ToLower() == "no")
				{
					invalidAnswer = false;
					EditAnOrder = false;
				}
				else
				{
					invalidAnswer = true;
					UserOutput.WouldYouLikeToEdit();
				}
			}
			return EditAnOrder;
		}

		internal static int EditAskForOrderNumber()
		{
			bool invalidAnswer = true;
			UserOutput.EditAskForOrderNumber() ;
			int y = int.MinValue;
			while (invalidAnswer)
			{
				string input = Console.ReadLine();

				if (int.TryParse(input, out int x))
				{
					y = x;
					break;

				}
				else
				{
					Console.WriteLine("Invalid entry, please enter again");
					invalidAnswer = true;
					break;
				}
			}
			return y;
		}

		internal static DateTime EditAskForDate()
		{
			UserOutput.EditAskForDate();
			string lookUpDate = Console.ReadLine();
			DateTime dateLookUp;
			if (!DateTime.TryParse(lookUpDate, out dateLookUp))
			{
				UserOutput.InputErrorMessage();
			}
			return dateLookUp;
		}

		internal static string GetCustomerName()
		{
			UserOutput.AskForCustomerName();
			string customerName = Console.ReadLine();
			return customerName;
		}

		internal static decimal GetArea()
		{
			bool invalidInput = true;
			decimal result = decimal.MinValue;
			while (invalidInput)
			{
				UserOutput.GetArea();
				string area = Console.ReadLine();
				if (!decimal.TryParse(area, out result))
				{
					invalidInput = true;
					continue;
				}
				else
				{
					invalidInput = false;
				}
			}
			return result;
		}

		internal static string GetProductType()
		{
			UserOutput.AskForProduct();
			string productType = Console.ReadLine();
			return productType;
		}

		internal static string GetStateName()
		{
			UserOutput.AskForStateToAddOrder();
			string stateName = Console.ReadLine();
			return stateName;
		}

		internal static DateTime GetDateToAddAnOrder()
		{
			DateTime dateLookUp = new DateTime();
			bool invalidInput = true;
			while (invalidInput)
			{
				UserOutput.AskForDateToAddOrder();
				string lookUpDate = Console.ReadLine();
				if (!DateTime.TryParse(lookUpDate, out dateLookUp) || dateLookUp < DateTime.Now)
				{
					UserOutput.InputErrorMessage();
					continue;
				}
				else
				{
					invalidInput = false;
				}
			}
			return dateLookUp;
		}

		internal static DateTime GetDateForDisplay()
		{
			bool invalidAnswer = true;
			DateTime y = new DateTime();
			while (invalidAnswer)
			{
				UserOutput.AskForDateToAddOrder();
				string input = Console.ReadLine();

				if (!DateTime.TryParse(input, out DateTime x))
				{
					Console.WriteLine("Invalid entry, please enter again");
					invalidAnswer = true;
					break;
				}
				else
				{
					invalidAnswer = false;
					y = x;
				}
			}
			return y;
		}

		public static DateTime TakeInDate()
		{
			bool invalidAnswer = true;
			DateTime y = new DateTime();
			while (invalidAnswer)
			{
				UserOutput.AskForDateToAddOrder();
				string input = Console.ReadLine();

				if (!DateTime.TryParse(input, out DateTime x))
				{
					Console.WriteLine("Invalid entry, please enter again");
					invalidAnswer = true;
					break;
				}
				else
				{
					invalidAnswer = false;
					y = x;
				}
			}
			return y;
		}

		public static string TakeInProduct()
		{
			UserOutput.AskForProduct();
			string nameOfProduct = Console.ReadLine();
			return nameOfProduct;
		}

		public static string TakeInState()
		{
			UserOutput.AskForStateToAddOrder();
			string nameOfState = Console.ReadLine();
			return nameOfState;
		}

		public static string TakeInCustomerName()
		{
			UserOutput.AskForCustomerName();
			string name = Console.ReadLine();
			return name;
		}
	}
}