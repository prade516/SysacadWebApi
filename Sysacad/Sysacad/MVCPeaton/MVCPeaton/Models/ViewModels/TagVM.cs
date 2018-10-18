using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class TagVM : BaseVM
    {
        #region Members
        // Members
        private String _name;
        private Int32 _state;

        // ForeignKey
        private Int64 _idtagcategory;

        // Lists
        private List<TagCategoryVM> _TagCategories;

        // Links
        private String _MyTagCategoryLink;
        #endregion

        #region Properties
        // Properties
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [RegularExpression("^[a-zA-ZÀ-ÿ0-9]+(\\s+[-_a-zA-ZÀ-ÿ0-9]+)*$", ErrorMessage = "Solamente se permiten letras, numeros y espacios (Solo para separar)")]
        [StringLength(100, ErrorMessage = "Longitud mínima de 1 caracter y máxima de 100 caracteres", MinimumLength = 1)]
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

        public Int64 idtagcategory
        {
            get
            {
                return _idtagcategory;
            }

            set
            {
                _idtagcategory = value;
            }
        }

        // Links
        public String MyTagCategoryLink
        {
            get
            {
                return _MyTagCategoryLink;
            }

            set
            {
                _MyTagCategoryLink = value;
            }
        }
        #endregion

        #region Lists
        public List<TagCategoryVM> TagCategories
        {
            get
            {
                return _TagCategories;
            }

            set
            {
                _TagCategories = value;
            }
        }
        #endregion
    }
}