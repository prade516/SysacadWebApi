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
    public class ComisionesController : ApiController
	{
		#region Constructor
		private IComisionServices _services;
		public ComisionesController(IComisionServices services)
		{
			_services = services;
		}
		#endregion
		public IEnumerable<ComisionDTO> GetComisiones(int state = 1, int page = 1,
		   int top = 5, string orderby = nameof(ComisionDTO.id_comision), string ascending = "asc")
		{
			var count = 0;
			var query = _services.GetAll(state, page, top, orderby, ascending, ref count).AsQueryable();
			var dtos = from comision in query
					   select Models.Factory.FactoryComisionDTO.GetInstance().CreateDTO(comision);

			return dtos.ToList();
		}
		public ComisionDTO Get(int id)
		{
			var query = _services.GetById(id);
			ComisionDTO dtos = Models.Factory.FactoryComisionDTO.GetInstance().CreateDTO(query);

			return dtos;
		}
		public async Task<IHttpActionResult> PostComision(ComisionBE comision)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			_services.Create(comision);
			return Created(new Uri(Url.Link("DefaultApi", new { Id = comision })), comision);
		}
		public async Task<IHttpActionResult> PutComision(Int32 id, ComisionBE comision)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			comision.id_comision = id;
			_services.Update(id, comision);
			return Ok();
		}
		public async Task<IHttpActionResult> DeleteComision(int id)
		{
			this._services.Delete(id);
			return Ok();
		}
	}
}
