using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using HotCallsAdmin.Domain.Abstract;
using HotCallsAdmin.Domain.Entities;

namespace HotCallsAdmin.Domain.Concrete
{
	public class OracleSentsRepository : ISentsRepository
	{
		private Table<Sent> sentsTable;
		public OracleSentsRepository(string connectionString)
		{
			sentsTable = (new DataContext(connectionString)).GetTable<Sent>();
		}

		public IQueryable<Sent> Sents
		{
			get { return sentsTable; }
		}

		public void SaveSent(Sent sent)
		{
			// if it's a new sent mail, just attach it to the DataContext
			if (sent.Id == 0)
				sentsTable.InsertOnSubmit(sent);
			else if (sentsTable.GetOriginalEntityState(sent) == null)
			{
				// We're updating an existing sent mail, but it's not attached to this DataContext
				// so attach it and detect changes
				sentsTable.Attach(sent);
				sentsTable.Context.Refresh(RefreshMode.KeepCurrentValues, sent);
			}

			sentsTable.Context.SubmitChanges();
		}

		public void DeleteSent(Sent sent)
		{
			sentsTable.DeleteOnSubmit(sent);
			sentsTable.Context.SubmitChanges();
		}
	}
}
