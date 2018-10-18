using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSysacad.Models.ViewModel
{
	public class BaseSysacadVM
	{
		public Int32 Id { get; set; }
		public string MyLink { get; set; }
		public string UpdateLink { get; set; }
		public string DeleteLink { get; set; }
	}
}