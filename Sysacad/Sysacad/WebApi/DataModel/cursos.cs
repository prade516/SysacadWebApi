namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class cursos:BaseDM
    {
        #region Properties
        [Key]
        public int id_curso { get; set; }

        public int id_materia { get; set; }

        public int id_comision { get; set; }

        public int anio_calendario { get; set; }

        public int cupo { get; set; }
        #endregion

        #region Relation
        [ForeignKey("id_comision")]
        public comisiones comisiones { get; set; }
        [ForeignKey("id_materia")]
        public materias materias { get; set; }
        #endregion

        #region List
        public List<alumnos_inscripciones> alumnos_inscripciones { get; set; }
        public List<docentes_cursos> docentes_cursos { get; set; }
        #endregion

    }
}
