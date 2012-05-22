using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace HotCallsAdmin.Domain.Entities
{
	[Table(Name = "Jc_Hc_Sent")]
	public class Sent
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
		public int Id { get; set; }

		[Column] public string Ag_Id { get; set; }
		[Column] public int Eid { get; set; }
		[Column] public string Email_Sent { get; set; }
		[Column] public DateTime Sent_Dt { get; set; }
		[Column] public string Sub_Tycod { get; set; }
		[Column] public string Tycod { get; set; }
	}
}
