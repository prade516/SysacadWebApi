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
    public class MateriasController : ApiController
	{
		#region Constructor
		private IMateriaServicescs _services;
		public MateriasController(IMateriaServicescs services)
		{
			_services = services;
		}
		#endregion
		public IEnumerable<MateriaDTO> GetMaterias(int state = 1, int page = 1,
	   int top = 5, string orderby = nameof(MateriaDTO.id_materia), string ascending = "asc")
		{
			var count = 0;
			var query = _services.GetAll(state, page, top, orderby, ascending, ref count).AsQueryable();
			var dtos = from materia in query
					   select Models.Factory.FactoryMateriaDTO.GetInstance().CreateDTO(materia);

			return dtos.ToList();
		}
		public MateriaDTO Get(int id)
		{
			var query = _services.GetById(id);
			MateriaDTO dtos = Models.Factory.FactoryMateriaDTO.GetInstance().CreateDTO(query);

			return dtos;
		}
		public async Task<IHttpActionResult> PostMateria(MateriaBE plan)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			_services.Create(plan);
			return Created(new Uri(Url.Link("DefaultApi", new { Id = plan })), plan);
		}
		public async Task<IHttpActionResult> PutMateria(Int32 id, MateriaBE plan)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			plan.id_materia = id;
			_services.Update(id, plan);
			return Ok();
		}
		public async Task<IHttpActionResult> DeleteMateria(int id)
		{
			this._services.Delete(id);
			return Ok();
		}
	}
}
