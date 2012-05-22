using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using HotCallsAdmin.Domain.Abstract;
using HotCallsAdmin.Domain.Entities;

namespace HotCallsAdmin.Domain.Concrete
{
	public class OracleUsersRepository : IUsersRepository
	{
		private Table<User> usersTable;
		public OracleUsersRepository(string connectionString)
		{
			usersTable = (new DataContext(connectionString)).GetTable<User>();
		}

		public IQueryable<User> Users
		{
			get { return usersTable; }
		}

		public void SaveUser(User user)
		{
			// if it's a new user, just attach it to the DataContext
			if (user.Id == 0)
				usersTable.InsertOnSubmit(user);
			else if (usersTable.GetOriginalEntityState(user) == null)
			{
				// We're updating an existing user, but it's not attached to this DataContext
				// so attach it and detect changes
				usersTable.Attach(user);
				usersTable.Context.Refresh(RefreshMode.KeepCurrentValues, user);
			}

			usersTable.Context.SubmitChanges();
		}

		public void DeleteUser(User user)
		{
			usersTable.DeleteOnSubmit(user);
			usersTable.Context.SubmitChanges();
		}
	}
}
