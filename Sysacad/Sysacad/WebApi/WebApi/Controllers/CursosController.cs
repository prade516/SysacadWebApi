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
    public class CursosController : ApiController
	{
		#region Constructor
		private ICursoServices _services;
		public CursosController(ICursoServices services)
		{
			_services = services;
		}
		#endregion
		public IEnumerable<CursoDTO> GetCursos(int state = 1, int page = 1,
	   int top = 5, string orderby = nameof(CursoDTO.id_curso), string ascending = "asc")
		{
			var count = 0;
			var query = _services.GetAll(state, page, top, orderby, ascending, ref count).AsQueryable();
			var dtos = from curso in query
					   select Models.Factory.FactoryCursoDTO.GetInstance().CreateDTO(curso);

			//HybridDictionary myfilters = new HybridDictionary();
			//myfilters.Add("state", state);
			//EspecialidadDTOCollection dt = new EspecialidadDTOCollection(dtos.ToList(),
			//  FilterHelper.GenerateFilter(myfilters, top, orderby, ascending), page, count, top);

			return dtos.ToList();
		}
		public CursoDTO Get(int id)
		{
			var query = _services.GetById(id);
			CursoDTO dtos = Models.Factory.FactoryCursoDTO.GetInstance().CreateDTO(query);

			//HybridDictionary myfilters = new HybridDictionary();
			//myfilters.Add("state", state);
			//EspecialidadDTOCollection dt = new EspecialidadDTOCollection(dtos.ToList(),
			//  FilterHelper.GenerateFilter(myfilters, top, orderby, ascending), page, count, top);

			return dtos;
		}
		public async Task<IHttpActionResult> PostCursos(CursoBE curso)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			_services.Create(curso);
			return Created(new Uri(Url.Link("DefaultApi", new { Id = curso })), curso);
		}
		public async Task<IHttpActionResult> PutCursos(Int32 id, CursoBE curso)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			curso.id_curso = id;
			_services.Update(id, curso);
			return Ok();
		}
		public async Task<IHttpActionResult> DeleteCursos(int id)
		{
			this._services.Delete(id);
			return Ok();
		}
	}
}
