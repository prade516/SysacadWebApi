using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.DTOs
{
	public class ComisionDTO:BaseDto
	{
        #region Properties
        public int id_comision { get; set; }
        public int id_plan { get; set; }
        public string desc_comision { get; set; }
        public int anio_especialidad { get; set; }
        #endregion

        #region Relation
        public virtual PlanDTO planes { get; set; }
        #endregion

        #region List
        public List<CursoDTO> cursos { get; set; }
        #endregion
    }
}