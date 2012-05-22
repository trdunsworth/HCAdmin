using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using HotCallsAdmin.Domain.Abstract;
using HotCallsAdmin.Domain.Entities;

namespace HotCallsAdmin.Domain.Concrete
{
	public class OracleCurentsRepository : ICurentsRespository
	{
		private Table<Curent> curentsTable;
		public OracleCurentsRepository(string connectionString)
		{
			curentsTable = (new DataContext(connectionString)).GetTable<Curent>();
		}

		public IQueryable<Curent> Curents
		{
			get { return curentsTable; }
		}

		public void SaveCurent(Curent curent)
		{
			// if it's a new curent, just attach it to the DataContext
			if (curent.Eid == 0)
				curentsTable.InsertOnSubmit(curent);
			else if (curentsTable.GetOriginalEntityState(curent) == null)
			{
				// We're updating an existing curent, but it's not attached to this DataContext
				// so attach it and detect changes
				curentsTable.Attach(curent);
				curentsTable.Context.Refresh(RefreshMode.KeepCurrentValues, curent);
			}

			curentsTable.Context.SubmitChanges();
		}

		public void DeleteCurent(Curent curent)
		{
			curentsTable.DeleteOnSubmit(curent);
			curentsTable.Context.SubmitChanges();
		}
	}
}
