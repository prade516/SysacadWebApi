using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSysacad.Models.ViewModel
{
	public class PlanVM : BaseSysacadVM
	{
		private Int32 _id_plan;
		private String _desc_plan;
		private Int32 _estado;
		private String _name;
		private Int32 _id_especialidad;
		private List<PlanEspecialidadVM> _planespecialidad;
		private List<EspecialidadVM> _especialidad;

		[Display(Name = "Codigo")]
		public int id_plan { get => _id_plan; set => _id_plan = value; }
		[Display(Name = "Plan")]
		[Required]
		public string desc_plan { get => _desc_plan; set => _desc_plan = value; }
		public int estado { get => _estado; set => _estado = value; }
		public List<PlanEspecialidadVM> Planespecialidad { get => _planespecialidad; set => _planespecialidad = value; }
		public string name { get => _name; set => _name = value; }
		public List<EspecialidadVM> especialidad { get => _especialidad; set => _especialidad = value; }
		public int id_especialidad { get => _id_especialidad; set => _id_especialidad = value; }
	}
}