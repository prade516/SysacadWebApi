using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
	public class Docente_CursoBE:BaseBE
	{
        #region Properties
    
        public int id_dictado { get; set; }
        public int cargo { get; set; }
        public int id_docente { get; set; }
        public int id_curso { get; set; }
        #endregion

        #region Relation
        public CursoBE cursos { get; set; }
        public PersonaBE personas { get; set; }
        #endregion
    }
}
