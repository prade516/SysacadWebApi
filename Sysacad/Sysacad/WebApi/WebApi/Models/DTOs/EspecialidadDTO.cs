using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.DTOs
{
	public class EspecialidadDTO : BaseDto
	{
        public Int32 id_especialidad { get; set; }
        public String desc_especialidad { get; set; }
    }
}