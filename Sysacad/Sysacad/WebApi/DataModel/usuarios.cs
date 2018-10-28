namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class usuarios:BaseDM
    {
        #region Properties
        [Key]
        public int id_usuario { get; set; }

        public string nombre_usuario { get; set; }

        public string clave { get; set; }

        public bool habilitado { get; set; }

        public string email { get; set; }

        public bool cambia_clave { get; set; }

        public int id_persona { get; set; }
        #endregion

        #region List
         public List<modulos_usuarios> modulos_usuarios { get; set; }
        #endregion

        #region Relation
        [ForeignKey("id_persona")]
        public personas personas { get; set; }
        #endregion
    }
}
