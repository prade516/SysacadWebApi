namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class docentes_cursos:BaseDM
    {
        #region Properties
        [Key]
        public int id_dictado { get; set; }
        public int cargo { get; set; }
        public int id_docente { get; set; }
        public int id_curso { get; set; }
        #endregion

        #region Relation
        [ForeignKey("id_curso")]
        public cursos cursos { get; set; }
        [ForeignKey("id_docente")]
        public personas personas { get; set; }
        #endregion
    }
}
