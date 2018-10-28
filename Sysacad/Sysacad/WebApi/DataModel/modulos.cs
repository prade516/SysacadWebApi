namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class modulos:BaseDM
    {
        #region Properties
        [Key]
        public int id_modulo { get; set; }
        public string desc_modulo { get; set; }
        public string ejecuta { get; set; }
        #endregion

        #region List
        public List<modulos_usuarios> modulos_usuarios { get; set; }
        #endregion
    }
}
