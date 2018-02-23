using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using System.IO;
using BLL.Responses;
using Ordering.Data.Interfaces;

namespace FlooringOrdering.BLL
{
	public class OrderManager
	{
		private IOrderRepo _orderRepository;
		private ITaxRepo _taxRepo;
		private IProductRepo _prodRepo;

		public OrderManager(IOrderRepo orderTestRepository, ITaxRepo taxRepo, IProductRepo prodRepo)
		{
			_orderRepository = orderTestRepository;
			_taxRepo = taxRepo;
			_prodRepo = prodRepo;
		}

		public List<Order> GetAllOrders(DateTime dateLookUp)
		{
			return _orderRepository.GetAllOrders(dateLookUp);
		}


		public EditOrderResponse EditOrder(Order editOrder)
		{
			EditOrderResponse response = new EditOrderResponse();

			if (_orderRepository.GetAllOrders(editOrder.Date).Any(x => x.OrderNumber == editOrder.OrderNumber))
			{
				response.Success = true;
				response.Message = "An order is being edited";
			}
			else
			{
				response.Success = false;
				response.Message = "This order cannot be edited, because it does not exist";
			}
			return response;
		}

		public AddNewOrderResponse AddOrderResponse(Order addOrder)
		{
			AddNewOrderResponse response = new AddNewOrderResponse();

			if (_orderRepository.GetAllOrders(addOrder.Date).Any(x => x.OrderNumber == addOrder.OrderNumber))
			{
				response.Success = false;
				response.Message = "This order already exists, and therefore you cannot add a new one.";
				
			}
			else
			{
				response.Success = true;
				response.Message = "This order has been added to the repository";
				response.NewOrderResponseObject = addOrder;
			}
			return response;
		}

		public Order LoadOrder(DateTime dateDesired, int orderNumber)
		{
			List<Order> ordersForDate = _orderRepository.GetAllOrders(dateDesired);
			var filter = ordersForDate.SingleOrDefault(x => x.OrderNumber == orderNumber);
			return filter;
		}

		public void RemoveOrder(Order orderToBeRemoved)
		{
			_orderRepository.RemoveOrder(orderToBeRemoved);
		}

		public Order AddOrder(Order order)
		{
			var taxInformation = _taxRepo.LoadTaxInformation(order.State);
			var productInformation = _prodRepo.LoadProduct(order.ProductType);

			CalculateOrder(order);

			order.Date = order.Date;
			_orderRepository.AddOrder(order);
			return order;
		}
		private Order GenerateOrderNumber(Order order)
		{
			List<Order> orders = GetAllOrders(order.Date);
			if (orders.Count == 0)
			{
				order.OrderNumber = 1;
			}
			else
			{
				order.OrderNumber = orders[orders.Count - 1].OrderNumber + 1;
			}
			return order;
		}

		public Order CalculateOrder(Order order)
		{
			var taxInformation = _taxRepo.LoadTaxInformation(order.State);
			var productInformation = _prodRepo.LoadProduct(order.ProductType);

			order.OrderNumber = GenerateOrderNumber(order).OrderNumber;
			order.MaterialCostPerSquareFoot = productInformation.LaborCostPerSquareFoot;
			order.LaborCostPerSquareFoot = productInformation.LaborCostPerSquareFoot;
			order.MaterialCost = order.Area * productInformation.MatericalCostPerSquareFoot;
			order.LaborCost = order.Area * productInformation.LaborCostPerSquareFoot;
			order.Tax = (order.MaterialCost + order.LaborCost) * (taxInformation.TaxRate/100);
			order.Total = order.MaterialCost + order.LaborCost + order.Tax;
			order.Date = order.Date;
			return order;
		}
	}
}
