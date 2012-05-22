using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotCallsAdmin.Domain.Entities;

namespace HotCallsAdmin.Domain.Abstract
{
	public interface ISentsRepository
	{
		IQueryable<Sent> Sents { get; }
	}
}
