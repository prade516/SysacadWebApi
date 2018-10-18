using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
	public class PlanBE:BaseBE
	{
        public Int32 id_plan { get; set; }
        public String desc_plan { get; set; }
        public EspecialidadBE Especialidad { get; set; }
    }
}
