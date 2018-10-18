using BusinessEntities;
using BusinessServices.Interface;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Helpers;
using WebApi.Models.DTOCollection;
using WebApi.Models.DTOs;

namespace WebApi.Controllers
{
    public class EspecialidadesController : ApiController
	{
		#region Constructor
		private IEspecialidadServices _services;
		public EspecialidadesController(IEspecialidadServices services)
		{
			_services = services;
		}
		#endregion
		public IEnumerable<EspecialidadDTO> GetEspecialidades(int state = 1, int page = 1,
	   int top = 5, string orderby = nameof(EspecialidadDTO.id_especialidad), string ascending = "asc")
		{
			var count = 0;
			var query = _services.GetAll(state, page, top, orderby, ascending, ref count).AsQueryable();
			var dtos = from especialidad in query
					   select new EspecialidadDTO()
					   {
						   id_especialidad = especialidad.idespecialidad,
						   desc_especialidad = especialidad.desc_especialidad,
						   estado = especialidad.estado
					   };

			//HybridDictionary myfilters = new HybridDictionary();
			//myfilters.Add("state", state);
			//EspecialidadDTOCollection dt = new EspecialidadDTOCollection(dtos.ToList(),
			//  FilterHelper.GenerateFilter(myfilters, top, orderby, ascending), page, count, top);

			return dtos.ToList();
		}
		public EspecialidadDTO Get(int id)
		{
			var query = _services.GetById(id);
			EspecialidadDTO dtos = new EspecialidadDTO() 
					   {
						   id_especialidad = query.idespecialidad,
						   desc_especialidad = query.desc_especialidad,
						   estado = query.estado
					   };

			//HybridDictionary myfilters = new HybridDictionary();
			//myfilters.Add("state", state);
			//EspecialidadDTOCollection dt = new EspecialidadDTOCollection(dtos.ToList(),
			//  FilterHelper.GenerateFilter(myfilters, top, orderby, ascending), page, count, top);

			return dtos;
		}
		public async Task<IHttpActionResult> PostEspecialidad(EspecialidadBE especialidad)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			_services.Create(especialidad,"");
			return Created(new Uri(Url.Link("DefaultApi", new { Id = especialidad })), especialidad);
		}
		public async Task<IHttpActionResult> PutEspecialidad(Int32 id,EspecialidadBE especialidad)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			especialidad.idespecialidad = id;
			string username = User.Identity.Name;
			_services.Update(id, especialidad);
			return Ok();
		}
		public async Task<IHttpActionResult> DeleteEspecialidad(int id)
		{
			this._services.Delete(id);
			return Ok();
		}
	}
}
