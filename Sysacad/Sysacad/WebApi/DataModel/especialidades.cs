using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DataModel
{
	public class especialidades
	{
		#region Members
		private Int32 _id_especialidad;
		private String _desc_especialidad;
		private Int32 _estado;
		#endregion
		#region Properties
		[Key]
		public int id_especialidad { get => _id_especialidad; set => _id_especialidad = value; }
		public string desc_especialidad { get => _desc_especialidad; set => _desc_especialidad = value; }
		public int estado { get => _estado; set => _estado = value; }
		#endregion
	}
}
