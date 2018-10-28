namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class especialidades:BaseDM
    {
        #region Properties
        [Key]
        public int id_especialidad { get; set; }
        public string desc_especialidad { get; set; }
        #endregion

        #region List
        public List<planes> planes { get; set; }
        #endregion

    }
}
