using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSysacad.Models.ViewModel
{
	public class EspecialidadVM:BaseSysacadVM
	{
		#region Members
		private Int32 _idespecialidad;
		private String _descespecialidad;
		private Int32 _estado;
		#endregion
		#region Properties
		[Display(Name = "Codigo")]
		public int id_especialidad { get => _idespecialidad; set => _idespecialidad = value; }
		[Display(Name="Especialidad")]
		[Required]
		public string desc_especialidad { get => _descespecialidad; set => _descespecialidad = value; }
		public int estado { get => _estado; set => _estado = value; }
		#endregion
	}
}