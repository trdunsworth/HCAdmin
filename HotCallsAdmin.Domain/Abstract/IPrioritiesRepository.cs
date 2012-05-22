using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotCallsAdmin.Domain.Entities;

namespace HotCallsAdmin.Domain.Abstract
{
	public interface IPrioritiesRepository
	{
		IQueryable<Priority> Priorities { get; }
		public void SavePriority(Priority priority);
		public void DeletePriority(Priority priority);
	}
}
