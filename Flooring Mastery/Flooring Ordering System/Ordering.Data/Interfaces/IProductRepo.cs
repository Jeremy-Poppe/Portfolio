using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Ordering.Data.Interfaces
{
	public interface IProductRepo
	{
		Product LoadProduct(string productType);
	}
}
