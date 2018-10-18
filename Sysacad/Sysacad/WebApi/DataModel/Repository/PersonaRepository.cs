using DataModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Repository
{
	public class PersonaRepository : GenericRepository.GenericRepository<personas>, IPersonaRepository
	{
		public PersonaRepository(SysacadContext context) : base(context)
		{
		}
		public override void Delete(personas entity, List<string> modifiedfields)
		{
			var persona = dbcontext.personas.Find(entity.id_persona);
			persona.id_plan = entity.id_plan;
			persona.apellido = entity.apellido;
			persona.nombre = entity.nombre;
			persona.direccion = entity.direccion;
			persona.estado = entity.estado;
			persona.fecha_nac = entity.fecha_nac;
			persona.tipo_persona = entity.tipo_persona;
			dbcontext.personas.Attach(persona);
			base.Delete(persona, modifiedfields);
		}
	}
}
