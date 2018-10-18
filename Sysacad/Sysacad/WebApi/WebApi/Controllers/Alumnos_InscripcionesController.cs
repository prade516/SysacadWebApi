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
    public class Alumnos_InscripcionesController : ApiController
    {
		#region Constructor
		private IAlumnos_InscripcionServices _services;
		public Alumnos_InscripcionesController(IAlumnos_InscripcionServices services)
		{
			_services = services;
		}
		#endregion
		public IEnumerable<Alumnos_InscripcionDTO> GetComisiones(int state = 1, int page = 1,
		   int top = 5, string orderby = nameof(Alumnos_InscripcionDTO.id_alumno), string ascending = "asc", Int32 idalumno=0,Int32 id_curso=0)
		{
			var count = 0;
			
			var query = _services.GetAll(state, page, top, orderby, ascending, ref count, idalumno, id_curso).AsQueryable();
			var dtos = from alumno_inscripcion in query
					   select Models.Factory.FactoryAlumnos_InscripcionDTO.GetInstance().CreateDTO(alumno_inscripcion);

			return dtos.ToList();
		}
		public Alumnos_InscripcionDTO Get(int id)
		{
			var query = _services.GetById(id);
			Alumnos_InscripcionDTO dtos = Models.Factory.FactoryAlumnos_InscripcionDTO.GetInstance().CreateDTO(query);

			return dtos;
		}
		public async Task<IHttpActionResult> PostInscripto(Alumnos_InscripcionBE be)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			_services.Create(be);
			return Created(new Uri(Url.Link("DefaultApi", new { Id = be })), be);
		}
		public async Task<IHttpActionResult> PutInscripto(Int32 id, Alumnos_InscripcionBE be)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			be.id_inscripcion = id;
			_services.Update(id, be);
			return Ok();
		}
		public async Task<IHttpActionResult> DeleteInscripto(int id)
		{
			this._services.Delete(id);
			return Ok();
		}
	}
}
