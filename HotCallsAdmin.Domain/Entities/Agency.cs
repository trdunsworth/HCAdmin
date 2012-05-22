using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace HotCallsAdmin.Domain.Entities
{
	[Table(Name = "Jc_Hc_Agnecy")]
	public class Agency
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
		public int Id { get; set; }

		[Column] public string Ag_Id { get; set; }
		[Column] public int Units { get; set; }
	}
}
