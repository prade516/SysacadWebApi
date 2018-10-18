using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Interface
{
	public interface IAlumnos_InscripcionServices
	{
		Alumnos_InscripcionBE GetById(Int32 Id);
		List<Alumnos_InscripcionBE> GetAll(Int32 state, Int32 page, Int32 top, String orderBy, String ascending, ref Int32 count,Int32 idalumno, Int32 id_curso);
		Int64 Create(Alumnos_InscripcionBE Be);
		Boolean Update(Int64 Id, Alumnos_InscripcionBE Be);
		Boolean Delete(Int32 Id);
	}
}
