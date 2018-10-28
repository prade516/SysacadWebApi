namespace BusinessServices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class docentes_cursos
    {
        [Key]
        public int id_dictado { get; set; }

        public int estado { get; set; }

        public int cargo { get; set; }

        public int id_docente { get; set; }

        public int id_curso { get; set; }

        public virtual cursos cursos { get; set; }

        public virtual personas personas { get; set; }
    }
}
