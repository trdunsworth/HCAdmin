using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace HotCallsAdmin.Domain.Entities
{
	[Table(Name = "Jc_Hc_Loi")]
	public class Loi
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
		public int Id { get; set; }

		[Column] public string Edirpre { get; set; }
		[Column] public string Edirsuf { get; set; }
		[Column] public string Efeanme { get; set; }
		[Column] public string Efeatyp { get; set; }
		[Column] public string Estnum { get; set; }
		[Column] public int Esz { get; set; }
		[Column] public string Hndr_Blck { get; set; }
		[Column] public string Loi_Grp_Id { get; set; }
		[Column] public string Zip { get; set; }
	}
}
