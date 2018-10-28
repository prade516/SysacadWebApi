namespace BusinessServices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class materias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public materias()
        {
            cursos = new HashSet<cursos>();
        }

        [Key]
        public int id_materia { get; set; }

        public int id_plan { get; set; }

        public string desc_materia { get; set; }

        public int hs_semanales { get; set; }

        public int hs_totales { get; set; }

        public int estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cursos> cursos { get; set; }

        public virtual planes planes { get; set; }
    }
}
