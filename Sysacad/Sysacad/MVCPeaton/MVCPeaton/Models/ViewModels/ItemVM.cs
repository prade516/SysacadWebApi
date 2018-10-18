using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class ItemVM : BaseVM
    {
        #region members
        private Int64 _idItem;
        private String _name;
        #endregion

        #region properties
        public Int64 IdItem
        {
            get
            {
                return _idItem;
            }

            set
            {
                _idItem = value;
            }
        }

        [Required(ErrorMessage = "Debe Ingresar un rubro")]
        [Display(Name = "Nombre del rubro")]
        [DataType(DataType.Text)]
        [RegularExpression("^[a-zA-ZÀ-ÿ0-9]+(\\s+[-_a-zA-ZÀ-ÿ0-9]+)*$", ErrorMessage = "Solamente se permiten letras, numeros y espacios (Solo para separar)")]
        [StringLength(20, ErrorMessage = "La cantidad de caracteres debe estar entre 1 y 20", MinimumLength = 1)]
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        #endregion
    }
}