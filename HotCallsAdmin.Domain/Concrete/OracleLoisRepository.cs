using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using HotCallsAdmin.Domain.Abstract;
using HotCallsAdmin.Domain.Entities;

namespace HotCallsAdmin.Domain.Concrete
{
	public class OracleLoisRepository : ILoisRepository
	{
		private Table<Loi> loisTable;
		public OracleLoisRepository(string connectionString)
		{
			loisTable = (new DataContext(connectionString)).GetTable<Loi>();
		}

		public IQueryable<Loi> Lois
		{
			get { return loisTable; }
		}

		public void SaveLoi(Loi loi)
		{
			// if it's a new location, just attach it to the DataContext
			if (loi.Id == 0)
				loisTable.InsertOnSubmit(loi);
			else if (loisTable.GetOriginalEntityState(loi) == null)
			{
				// We're updating an existing agency, but it's not attached to this DataContext
				// so attach it and detect changes
				loisTable.Attach(loi);
				loisTable.Context.Refresh(RefreshMode.KeepCurrentValues, loi);
			}

			loisTable.Context.SubmitChanges();
		}

		public void DeleteLoi(Loi loi)
		{
			loisTable.DeleteOnSubmit(loi);
			loisTable.Context.SubmitChanges();
		}
	}
}
