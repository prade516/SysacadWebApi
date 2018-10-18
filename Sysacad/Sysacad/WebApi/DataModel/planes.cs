using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModel
{
	public class planes:BaseDM
	{
		[Key]
		public Int32 id_plan { get; set; }
		public String desc_plan { get; set; }
		public List<especialidades> Especialidad { get; set; }
	}
}