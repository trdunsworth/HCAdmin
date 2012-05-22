using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotCallsAdmin.Domain.Abstract;
using System.Data.Linq;
using HotCallsAdmin.Domain.Entities;

namespace HotCallsAdmin.Domain.Concrete
{
	public class OracleAgenciesRepository : IAgenciesRepository
	{
		private Table<Agency> agenciesTable;
		public OracleAgenciesRepository (string connectionString)
		{
			agenciesTable = (new DataContext(connectionString)).GetTable<Agency>();
		}

		public IQueryable<Agency> Agencies
		{
			get { return agenciesTable; }
		}

		public void SaveAgency(Agency agency)
		{
			// if it's a new agency, just attach it to the DataContext
			if (agency.Id == 0)
				agenciesTable.InsertOnSubmit(agency);
			else if (agenciesTable.GetOriginalEntityState(agency) == null)
			{
				// We;'re updating an existing product, but it's not attached to this DataContext,
				// so attach it and detect changes
				agenciesTable.Attach(agency);
				agenciesTable.Context.Refresh(RefreshMode.KeepCurrentValues, agency);
			}

			agenciesTable.Context.SubmitChanges();
		}

		public void DeleteAgency(Agency agency)
		{
			agenciesTable.DeleteOnSubmit(agency);
			agenciesTable.Context.SubmitChanges();
		}
	}
}
