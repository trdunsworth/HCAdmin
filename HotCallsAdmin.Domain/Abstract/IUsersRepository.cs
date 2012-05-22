using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotCallsAdmin.Domain.Entities;

namespace HotCallsAdmin.Domain.Abstract
{
	public interface IUsersRepository
	{
		IQueryable<User> Users { get; }
		public void SaveUser(User user);
		public void DeleteUser(User user);
	}
}
