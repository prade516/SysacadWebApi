using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DataModel
{
	public class especialidades:BaseDM
	{
		[Key]
		public Int32 id_especialidad { get; set; }
		public String desc_especialidad { get ; set; }
        public List<planes> planes { get; set; }

    }
}
