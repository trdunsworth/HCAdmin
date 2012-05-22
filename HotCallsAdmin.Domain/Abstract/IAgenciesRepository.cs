using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotCallsAdmin.Domain.Entities;

namespace HotCallsAdmin.Domain.Abstract
{
	public interface IAgenciesRepository
	{
		IQueryable<Agency> Agencies { get; }
		void SaveAgency(Agency agency);
		void DeleteAgency(Agency agency);
	}
}
