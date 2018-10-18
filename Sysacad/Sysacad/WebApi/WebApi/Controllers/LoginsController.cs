using BusinessEntities;
using BusinessServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Models.DTOs;

namespace WebApi.Controllers
{
    public class LoginsController : ApiController
	{
		#region Constructor
		private IPersonaServices _services;
		public LoginsController(IPersonaServices services)
		{
			_services = services;
		}
		#endregion
		public IEnumerable<PersonaDTO> GetLogins(String username, String password)
		{
			var query = _services.Login(username, password);
			var dtos = from be in query
					   select Models.Factory.FactoryPersonaDTO.GetInstance().CreateDTO(be);
			return dtos.ToList();
		}

		public async Task<IHttpActionResult> PutchangePassword(Int32 id, PersonaBE usr)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			UsuarioBE be = new UsuarioBE();
			foreach (var item in usr.Usuarios)
			{
				be.id_usuario = item.id_usuario;
				be.id_persona = item.id_persona;
				be.nombre_usuario = item.nombre_usuario;
				be.clave = item.clave;
				be.cambia_clave = item.cambia_clave;
				be.email = item.email;
				be.habilitado = item.habilitado;
				be.estado = item.estado;
				
			}			
			_services.ChangePassword(id,be);
			return Ok();
		}
	}
}
