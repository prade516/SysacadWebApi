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
    public class ModulosController : ApiController
	{
		#region Constructor
		private IModuloServices _services;
		public ModulosController(IModuloServices services)
		{
			_services = services;
		}
		#endregion
		public IEnumerable<ModuloDTO> GetModulos(int state = 1, int page = 1,
	   int top = 5, string orderby = nameof(ModuloDTO.id_modulo), string ascending = "asc")
		{
			var count = 0;
			var query = _services.GetAll(state, page, top, orderby, ascending, ref count).AsQueryable();
			var dtos = from modulo in query
					   select Models.Factory.FactoryModuloDTO.GetInstance().CreateDTO(modulo);

			return dtos.ToList();
		}
		public ModuloDTO Get(int id)
		{
			var query = _services.GetById(id);
			ModuloDTO dtos = Models.Factory.FactoryModuloDTO.GetInstance().CreateDTO(query);

			return dtos;
		}
		public async Task<IHttpActionResult> PostModulo(ModuloBE modulo)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			_services.Create(modulo);
			return Created(new Uri(Url.Link("DefaultApi", new { Id = modulo })), modulo);
		}
		public async Task<IHttpActionResult> PutModulo(Int32 id, ModuloBE modulo)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			modulo.id_modulo = id;
			string username = User.Identity.Name;
			_services.Update(id, modulo);
			return Ok();
		}
		public async Task<IHttpActionResult> DeleteModulo(int id)
		{
			this._services.Delete(id);
			return Ok();
		}
	}
}
