using DataModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Repository
{
	public class Modulo_Usuario_repository : GenericRepository.GenericRepository<modulos_usuarios>, IModulo_Usuario_repository
	{
		public Modulo_Usuario_repository(SysacadContext context) : base(context)
		{
		}
		public override void Delete(modulos_usuarios entity, List<string> modifiedfields)
		{
			var modusuario = dbcontext.modulos_usuarios.Find(entity.id_modulo_usuario);
			modusuario.id_modulo = entity.id_modulo;
			modusuario.id_usuario = entity.id_usuario;
			modusuario.alta = entity.alta;
			modusuario.modificacion = entity.modificacion;
			modusuario.baja = entity.baja;
			modusuario.consulta = entity.consulta;
			modusuario.estado = entity.estado;
			dbcontext.modulos_usuarios.Attach(modusuario);
			base.Delete(modusuario, modifiedfields);
		}
	}
}
