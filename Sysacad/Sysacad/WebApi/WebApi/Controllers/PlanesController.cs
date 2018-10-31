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
    public class PlanesController : ApiController
	{
		#region Constructor
		private IPlanServices _services;
		public PlanesController(IPlanServices services)
		{
			_services = services;
		}
		#endregion
		public IEnumerable<PlanDTO> Getplanes(int state = 1, int page = 1,
	   int top = 5, string orderby = nameof(PlanDTO.id_plan), string ascending = "asc")
		{
			var count = 0;
			var query = _services.GetAll(state, page, top, orderby, ascending, ref count).AsQueryable();
			var dtos = from especialidad in query
					     select Models.Factory.FactoryPlanDTO.GetInstance().CreateDTO(especialidad);

			return dtos.ToList();
		}
		public PlanDTO Get(int id)
		{
			var query = _services.GetById(id);
			PlanDTO dtos =Models.Factory.FactoryPlanDTO.GetInstance().CreateDTO(query); 

			return dtos;
		}
		public async Task<IHttpActionResult> PostPlan(PlanBE plan)
		{
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _services.Create(plan);
                return Created(new Uri(Url.Link("DefaultApi", new { Id = plan })), plan);
            }
            catch (Exception ex)
            {
                var except = (ApiBusinessException)HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
                var resp = BadRequest(Convert.ToString(except.ErrorDescription));
                return resp;
            }			
		}
		public async Task<IHttpActionResult> PutPlan(Int32 id, PlanBE plan)
		{
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                plan.id_plan = id;
                _services.Update(id, plan);
                return Ok();
            }
            catch (Exception ex)
            {
                var except = (ApiBusinessException)HandlerErrorExceptions.GetInstance().RunCustomExceptions(ex);
                var resp = BadRequest(Convert.ToString(except.ErrorDescription));
                return resp;
            }
			
		}
		public async Task<IHttpActionResult> DeletePlan(int id)
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
