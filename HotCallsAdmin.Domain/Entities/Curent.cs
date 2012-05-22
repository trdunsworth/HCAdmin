using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace HotCallsAdmin.Domain.Entities
{
	[Table(Name = "Jc_Hc_Curent")]
	public class Curent
	{
		[Column] public int Ad_Sec { get; set; }
		[Column] public string Ad_Ts { get; set; }
		[Column] public string Ag_Id { get; set; }
		[Column] public string Ccity { get; set; }
		[Column] public string Curent { get; set; }
		[Column] public string Eapt { get; set; }
		[Column] public string Edirpre { get; set; }
		[Column] public string Edirsuf { get; set; }
		[Column] public string Efeanme { get; set; }
		[Column] public string Efeatyp { get; set; }
		[Column] public int Eid { get; set; }
		[Column] public string Estnum { get; set; }
		[Column] public char Hc_Sent { get; set; }
		[Column] public char Loc_Sent { get; set; }
		[Column] public char Loi_Sent { get; set; }
		[Column] public string Sub_Tycod { get; set; }
		[Column] public char Tr_Sent { get; set; }
		[Column] public string Tycod { get; set; }
		[Column] public string Udts { get; set; }
		[Column] public int Unit_Count { get; set; }
		[Column] public int Usec { get; set; }
		[Column] public string Xdts { get; set; }
	}
}
