namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class comisiones:BaseDM
    {
        #region Properties
        [Key]
        public int id_comision { get; set; }

        public int id_plan { get; set; }

        public string desc_comision { get; set; }

        public int anio_especialidad { get; set; }
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
