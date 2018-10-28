namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class alumnos_inscripciones:BaseDM
    {
        #region Properties
        [Key]
        public int id_inscripcion { get; set; }
        public int id_alumno { get; set; }
        public int id_curso { get; set; }
        public string condicion { get; set; }
        public int nota { get; set; }
        #endregion

        #region Relation
        [ForeignKey("id_curso")]
        public cursos cursos { get; set; }
        [ForeignKey("id_alumno")]
        public personas personas { get; set; }
        #endregion

    }
}
