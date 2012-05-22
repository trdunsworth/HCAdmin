using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using HotCallsAdmin.Domain.Abstract;
using HotCallsAdmin.Domain.Entities;

namespace HotCallsAdmin.Domain.Concrete
{
	public class OraclePrioritiesRepository : IPrioritiesRepository
	{
		private Table<Priority> prioritiesTable;
		public OraclePrioritiesRepository(string connectionString)
		{
			prioritiesTable = (new DataContext(connectionString)).GetTable<Priority>();
		}

		public IQueryable<Priority> Priorities
		{
			get { return prioritiesTable; }
		}

		public void SavePriority(Priority priority)
		{
			// if it's a new priority matrix, just attach it to the DataContext
			if (priority.Ag_Id == null)
				prioritiesTable.InsertOnSubmit(priority);
			else if (prioritiesTable.GetOriginalEntityState(priority) == null)
			{
				// We're updating an existing priority matrix, but it's not attached to this DataContext
				// so attach it and detect changes
				prioritiesTable.Attach(priority);
				prioritiesTable.Context.Refresh(RefreshMode.KeepCurrentValues, priority);
			}

			prioritiesTable.Context.SubmitChanges();
		}

		public void DeletePriority(Priority priority)
		{
			prioritiesTable.DeleteOnSubmit(priority);
			prioritiesTable.Context.SubmitChanges();
		}
	}
}
