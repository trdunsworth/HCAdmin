using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using HotCallsAdmin.Domain.Abstract;
using HotCallsAdmin.Domain.Entities;

namespace HotCallsAdmin.Domain.Concrete
{
	public class OracleTypesRepository : ITypesRepository
	{
		private Table<Atype> typesTable;
		public OracleTypesRepository(string connectionString)
		{
			typesTable = (new DataContext(connectionString)).GetTable<Atype>();
		}

		public IQueryable<Atype> Types
		{
			get { return typesTable; }
		}

		public void SaveType(Atype atype)
		{
			// if it's a new type, just attach it to the DataContext
			if (atype.Id == 0)
				typesTable.InsertOnSubmit(atype);
			else if (typesTable.GetOriginalEntityState(atype) == null)
			{
				// We're updating an existing type, but it's not attached to this DataContext
				// so attach it and detect changes
				typesTable.Attach(atype);
				typesTable.Context.Refresh(RefreshMode.KeepCurrentValues, atype);
			}

			typesTable.Context.SubmitChanges();
		}

		public void DeleteType(Atype atype)
		{
			typesTable.DeleteOnSubmit(atype);
			typesTable.Context.SubmitChanges();
		}
	}
}
