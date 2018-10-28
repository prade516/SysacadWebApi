using BusinessEntities;
using BusinessServices.Interface;
using SolveApi.Error;
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
    public class PersonasController : ApiController
	{
		#region Constructor
		private IPersonaServices _services;
		public PersonasController(IPersonaServices services)
		{
			_services = services;
		}
		#endregion
		public IEnumerable<PersonaDTO> GetPesonas(int state = 1, int page = 1,int idconectado=0,
	   int top = 5, string orderby = nameof(PersonaDTO.id_persona), string ascending = "asc",Int32 tipo_persona=0)
		{
			var count = 0;
			var query = _services.GetAll(state, page, idconectado, top, orderby, ascending, ref count, tipo_persona).AsQueryable();
			var dtos = from be in query
					   select Models.Factory.FactoryPersonaDTO.GetInstance().CreateDTO(be);

			return dtos.ToList();
		}
		public PersonaDTO Get(int id)
		{
			var query = _services.GetById(id);
			PersonaDTO dtos = Models.Factory.FactoryPersonaDTO.GetInstance().CreateDTO(query);

			return dtos;
		}
		public async Task<IHttpActionResult> PostPersona(PersonaBE be)
		{
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _services.Create(be);
                return Created(new Uri(Url.Link("DefaultApi", new { Id = be.id_persona })), be);
            }
            catch (Exception ex)
            {
                var except = (ApiBusinessException)HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
                var resp = BadRequest(Convert.ToString(except.ErrorDescription));
                return resp;               
            }
			
		}
		public async Task<IHttpActionResult> PutPersona(Int32 id, PersonaBE be)
		{
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                be.id_persona = id;
                string username = User.Identity.Name;
                _services.Update(id, be);
                return Ok();
            }
            catch (Exception ex)
            {
                var except = (ApiBusinessException)HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
                var resp = BadRequest(Convert.ToString(except.ErrorDescription));
                return resp;
            } 
		}
		public async Task<IHttpActionResult> DeletePersona(int id)
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
