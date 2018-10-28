namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class planes:BaseDM
    {
        #region Properties
        [Key]
        public int id_plan { get; set; }
        public int id_especialidad { get; set; }
        public string desc_plan { get; set; }
        #endregion

        #region Relation
        [ForeignKey("id_especialidad")]
        public especialidades especialidades { get; set; }
        #endregion

        #region List
        public List<comisiones> comisiones { get; set; }
        public List<materias> materias { get; set; }
        public List<personas> personas { get; set; }
        #endregion

       
    }
}
