using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class planmaterias
	{
		private Int32 _idplanmateria;
		private Int32 _idplan;
		private Int32 _idmateria;
		private Int32 _estado;

		private materias _materia;
		private planes _plan;

		[Key]
		public int idplanmateria { get => _idplanmateria; set => _idplanmateria = value; }
		public int idplan { get => _idplan; set => _idplan = value; }
		public int idmateria { get => _idmateria; set => _idmateria = value; }
		public int estado { get => _estado; set => _estado = value; }
		[ForeignKey("idmateria")]
		public materias materia { get => _materia; set => _materia = value; }
		[ForeignKey("idplan")]
		public planes plan { get => _plan; set => _plan = value; }
	}
}
