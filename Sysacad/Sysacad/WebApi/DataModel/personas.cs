namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class personas:BaseDM
    {
        #region Properties
        [Key]
        public int id_persona { get; set; }
        public int id_plan { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public DateTime fecha_nac { get; set; }
        public int legajo { get; set; }
        public int tipo_persona { get; set; }
        #endregion

        #region Relation
        public planes planes { get; set; }
        #endregion

        #region List
        public List<alumnos_inscripciones> alumnos_inscripciones { get; set; }
        public List<docentes_cursos> docentes_cursos { get; set; }
        public List<usuarios> usuarios { get; set; }
        #endregion     
    }
}
