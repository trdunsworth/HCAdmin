using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotCallsAdmin.Domain.Entities;

namespace HotCallsAdmin.Domain.Abstract
{
	public interface ITypesRepository
	{
		IQueryable<Atype> Types { get; }
		public void SaveType(Atype atype);
		public void DeleteType(Atype atype);
	}
}
