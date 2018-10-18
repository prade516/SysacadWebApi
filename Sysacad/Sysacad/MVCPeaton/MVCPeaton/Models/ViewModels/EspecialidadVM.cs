using MVCPeaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
	public class EspecialidadVM: BaseVM
	{
		#region Members
		private Int32 _idespecialidad;
		private String _descespecialidad;
		private Int32 _estado;
		#endregion
		#region Properties
		public int idespecialidad { get => _idespecialidad; set => _idespecialidad = value; }
		[Display(Name="Especialidad")]
		public string desc_especialidad { get => _descespecialidad; set => _descespecialidad = value; }
		public int estado { get => _estado; set => _estado = value; }
		#endregion
	}
}