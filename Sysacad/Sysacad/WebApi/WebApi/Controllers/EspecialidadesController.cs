using BusinessEntities;
using BusinessServices.Interface;
using SolveApi.Error;
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
						   id_especialidad = especialidad.id_especialidad,
						   desc_especialidad = especialidad.desc_especialidad,
						   estado = especialidad.estado
					   };

			

			return dtos.ToList();
		}
		public EspecialidadDTO Get(int id)
		{
			var query = _services.GetById(id);
			EspecialidadDTO dtos = new EspecialidadDTO() 
					   {
						   id_especialidad = query.id_especialidad,
						   desc_especialidad = query.desc_especialidad,
						   estado = query.estado
					   };

			return dtos;
		}
		public async Task<IHttpActionResult> PostEspecialidad(EspecialidadBE especialidad)
		{
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _services.Create(especialidad, "");
                return Created(new Uri(Url.Link("DefaultApi", new { Id = especialidad })), especialidad);
            }
            catch (Exception ex)
            {
                var except = (ApiBusinessException)HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
                var resp = BadRequest(Convert.ToString(except.ErrorDescription));
                return resp;
            }
			
		}
		public async Task<IHttpActionResult> PutEspecialidad(Int32 id,EspecialidadBE especialidad)
		{
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                especialidad.id_especialidad = id;
                string username = User.Identity.Name;
                _services.Update(id, especialidad);
                return Ok();
            }
            catch (Exception ex)
            {
                var except = (ApiBusinessException)HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
                var resp = BadRequest(Convert.ToString(except.ErrorDescription));
                return resp;
            }
			
		}
		public async Task<IHttpActionResult> DeleteEspecialidad(int id)
		{
            try
            {
                this._services.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                var except = (ApiBusinessException)HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
                var resp = BadRequest(Convert.ToString(except.ErrorDescription));
                return resp;
            }			
		}
	}
}
