namespace BusinessServices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class alumnos_inscripciones
    {
        [Key]
        public int id_inscripcion { get; set; }

        public int id_alumno { get; set; }

        public int id_curso { get; set; }

        public string condicion { get; set; }

        public int nota { get; set; }

        public int estado { get; set; }

        public virtual cursos cursos { get; set; }

        public virtual personas personas { get; set; }
    }
}
