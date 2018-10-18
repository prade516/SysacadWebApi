using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Hypermedia;
using WebApi.Models.Representacion;

namespace WebApi.Models.DTOs
{
	public class PlanDTO : BaseDto
	{
        public Int32 id_plan { get; set; }
        public String desc_plan { get; set; }
        public EspecialidadDTO Especialidad { get; set; }
    }
}