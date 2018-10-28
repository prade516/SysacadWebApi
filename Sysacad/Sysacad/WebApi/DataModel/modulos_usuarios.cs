namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class modulos_usuarios:BaseDM
    {
        #region Properties
        [Key]
        public int id_modulo_usuario { get; set; }
        public int id_modulo { get; set; }
        public int id_usuario { get; set; }
        public bool alta { get; set; }
        public bool baja { get; set; }
        public bool modificacion { get; set; }
        public bool consulta { get; set; }
        #endregion

        #region Relation
        [ForeignKey("id_modulo")]
        public modulos modulos { get; set; }
        [ForeignKey("id_usuario")]
        public usuarios usuarios { get; set; }
        #endregion
    }
}
