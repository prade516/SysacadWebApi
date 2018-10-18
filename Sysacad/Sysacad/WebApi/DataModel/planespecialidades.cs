using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class planespecialidades
	{
		private Int32 _idplanespecialidad;
		private Int32 _idplan;
		private Int32 _idespecialidad;
		private Int32 _estado;

		private planes _plan;
		private especialidades _especialidad;

		[Key]
		public int idplanespecialidad { get => _idplanespecialidad; set => _idplanespecialidad = value; }
		public int idplan { get => _idplan; set => _idplan = value; }
		public int idespecialidad { get => _idespecialidad; set => _idespecialidad = value; }
		public int estado { get => _estado; set => _estado = value; }
		[ForeignKey(name: "idplan")]
		public planes Plan { get => _plan; set => _plan = value; }
		[ForeignKey(name: "idespecialidad")]
		public especialidades Especialidad { get => _especialidad; set => _especialidad = value; }
	}
}
