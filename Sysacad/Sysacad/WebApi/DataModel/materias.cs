namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class materias:BaseDM
    {
        #region Properties
        [Key]
        public int id_materia { get; set; }
        public int id_plan { get; set; }
        public string desc_materia { get; set; }
        public int hs_semanales { get; set; }
        public int hs_totales { get; set; }
        #endregion

        #region Relation
        [ForeignKey("id_plan")]
        public planes planes { get; set; }
        #endregion

        #region List
        public List<cursos> cursos { get; set; }
        #endregion
    }
}
