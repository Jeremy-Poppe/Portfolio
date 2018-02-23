using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BLL.Responses
{
	public class EditOrderResponse : Response
	{
		public Order responseObject { get; set; }
	}
}
