using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class TagCategoryVM : BaseVM
    {
        #region Members
        // Members
        private String _name;
        private Int32 _state;

        // Navigation property
        private List<TagVM> _Tags;

        // Links
        private String _MyTagsLink;
        #endregion

        #region Properties
        // Properties
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [RegularExpression("^[a-zA-ZÀ-ÿ0-9]+(\\s+[-_a-zA-ZÀ-ÿ0-9]+)*$", ErrorMessage = "Solamente se permiten letras, numeros y espacios (Solo para separar)")]
        [StringLength(50, ErrorMessage = "Longitud mínima de 1 caracter y máxima de 50 caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre")]
        public String name
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

        public Int32 state
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
            }
        }

        // Links
        public String MyTagsLink
        {
            get
            {
                return _MyTagsLink;
            }

            set
            {
                _MyTagsLink = value;
            }
        }
        #endregion

        #region Lists
        public List<TagVM> Tags
        {
            get
            {
                return _Tags;
            }

            set
            {
                _Tags = value;
            }
        }
        #endregion
    }
}