using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class EspecialidadBE
    {
		#region Members
		private Int32 _idespecialidad;
		private String _descespecialidad;
		private Int32 _estado;
		#endregion
		#region Properties
		public int idespecialidad { get => _idespecialidad; set => _idespecialidad = value; }
		public string desc_especialidad { get => _descespecialidad; set => _descespecialidad = value; }
		public int estado { get => _estado; set => _estado = value; }
		#endregion
	}
}
