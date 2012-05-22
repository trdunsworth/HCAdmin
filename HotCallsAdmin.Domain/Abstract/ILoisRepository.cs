using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotCallsAdmin.Domain.Entities;

namespace HotCallsAdmin.Domain.Abstract
{
	public interface ILoisRepository
	{
		IQueryable<Loi> Lois { get; }
		void SaveLoi(Loi loi);
		void DeleteLoi(Loi loi);
	}
}
