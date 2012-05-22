using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace HotCallsAdmin.Domain.Entities
{
	[Table(Name = "Jc_Hc_Users")]
	public class User
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert;)]
		public int Id { get; set; }

		[Column] public int Ag_Id { get; set; }
		[Column] public string Email { get; set; }
		[Column] public int Esz { get; set; }
		[Column] public string Fname { get; set; }
		[Column] public int Leo { get; set; }
		[Column] public string Lname { get; set; }
		[Column] public string Loi_Grps { get; set; }
		[Column] public char Oof { get; set; }
		[Column] public string Zip { get; set; }
		[Column] public string Zip2 { get; set; }
		[Column] public string Zip3 { get; set; }
	}
}
