using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.DTOs
{
	public class PlanDTO : BaseDto
	{
        public Int32 id_plan { get; set; }
        public Int32 id_especialidad { get; set; }
        public String desc_plan { get; set; }
        public EspecialidadDTO Especialidad { get; set; }
    }
}