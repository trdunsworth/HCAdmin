using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace HotCallsAdmin.Domain.Entities
{
	[Table(Name = "Jc_Hc_Types")]
	public class Atype
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
		public int Id { get; set; }

		[Column] public string Agency { get; set; }
		[Column] public char Alwys_Snd { get; set; }
		[Column] public char Nevr_Snd { get; set; }
		[Column] public char Not4Pub { get; set; }
		[Column] public string Priority { get; set; }
		[Column] public string Sub_Tycod { get; set; }
		[Column] public string Tycod { get; set; }
		[Column] public int Un_Cnt { get; set; }
	}
}
