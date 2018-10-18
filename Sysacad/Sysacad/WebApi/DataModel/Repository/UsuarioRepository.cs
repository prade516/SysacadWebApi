using DataModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Repository
{
	public class UsuarioRepository : GenericRepository.GenericRepository<usuarios>, IUsuarioRepository
	{
		public UsuarioRepository(SysacadContext context) : base(context)
		{
		}
		public override void Delete(usuarios entity, List<string> modifiedfields)
		{
			var usuario = dbcontext.usuarios.Find(entity.id_usuario);
			usuario.id_persona = entity.id_persona;
			usuario.clave = entity.clave;
			usuario.nombre_usuario = entity.nombre_usuario;
			usuario.email = entity.email;
			usuario.estado = entity.estado;
			usuario.habilitado = entity.habilitado;
			usuario.estado = entity.estado;
			dbcontext.usuarios.Attach(usuario);
			base.Delete(usuario, modifiedfields);
		}
	}
}
