using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Ordering.Data.Interfaces;


namespace Ordering.Data
{
	public class TaxTestRepository : ITaxRepo
	{
		List<TaxInformation> _taxInformations = new List<TaxInformation>() { new TaxInformation()
			{
				StateAbbreviation = "MN",
				StateName = "Minnesota",
				TaxRate = .0625M,
			}, new TaxInformation()
			{
				StateAbbreviation = "WY",
				StateName = "Wyoming",
				TaxRate = .05M,
			}, new TaxInformation()
			{
				StateAbbreviation = "CO",
				StateName = "Colorado",
				TaxRate = .045M,
			}, new TaxInformation()
			{
				StateAbbreviation = "NY",
				StateName = "New York",
				TaxRate = .0525M,
			}
		};

		public TaxInformation LoadTaxInformation(string StateName)
		{
			return _taxInformations.SingleOrDefault(x => x.StateName == StateName);
		}
	}
}
