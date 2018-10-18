using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSysacad.Models.ViewModel
{
	public class PlanEspecialidadVM
	{
		private Int32 _idplanespecialidad;
		private Int32 _idplan;
		private Int32 _idespecialidad;
		private Int32 _estado;

		private PlanVM _plan;
		private EspecialidadVM _especialidad;

		[Display(Name = "Codigo")]
		public int idplanespecialidad { get => _idplanespecialidad; set => _idplanespecialidad = value; }
		public int idplan { get => _idplan; set => _idplan = value; }
		public int idespecialidad { get => _idespecialidad; set => _idespecialidad = value; }
		public int estado { get => _estado; set => _estado = value; }
		public PlanVM Plan { get => _plan; set => _plan = value; }
		public EspecialidadVM Especialidad { get => _especialidad; set => _especialidad = value; }
	}
}