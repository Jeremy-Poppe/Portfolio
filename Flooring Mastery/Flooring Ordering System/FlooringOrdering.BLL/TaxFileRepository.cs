using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Ordering.Data.Interfaces;

namespace FlooringOrdering.BLL

{
	public class TaxFileRepository : ITaxRepo
	{
		private string _productPath;

		public TaxFileRepository(string filePath)
		{
			_productPath = filePath;
		}
		public List<TaxInformation> LoadTax()
		{
			List<TaxInformation> taxInformation = new List<TaxInformation>();

			using (StreamReader sr = new StreamReader(_productPath))
			{
				sr.ReadLine();
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					TaxInformation taxInformations = new TaxInformation();

					string[] columns = line.Split(',');

					taxInformations.StateAbbreviation = columns[0];
					taxInformations.StateName = columns[1];
					taxInformations.TaxRate = Convert.ToDecimal(columns[2]);

					taxInformation.Add(taxInformations);
				}
			}
			return taxInformation;
		}

		public TaxInformation LoadTaxInformation(string State)
		{
			TaxInformation stateTaxInformation = LoadTax().SingleOrDefault(x => x.StateName == State);
			return stateTaxInformation;
		}
	}
}
