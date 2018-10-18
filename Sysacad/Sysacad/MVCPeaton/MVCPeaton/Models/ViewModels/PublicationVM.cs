using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class PublicationVM : BaseVM
    {
        #region Members
        private String _title;
        private String _description;
        private String _photo;
        private String _termscondition;
        private Int32 _maxquantity;
        private String _visiblecondition;
        private Int64 _idpublicationcategory;
        private Int32 _state;
        private String _name;
        private List<PublicationCategoryVM> _publicationcategories;
        private List<PublicationBCTagVM> _tags;


        //private List<PublicationBCTagVM> _tags;
        #endregion

        #region Properties
        [RegularExpression("^(?!^ *$)^.+$", ErrorMessage = "No puede ingresar solo espacios")]
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Título")]
        public String title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value.TrimStart(' ').TrimEnd(' ');
            }
        }
        [RegularExpression("^(?!^ *$)^.+$", ErrorMessage = "No puede ingresar solo espacios")]
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Descripción")]
        public String description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value.TrimStart(' ').TrimEnd(' ');
            }
        }
        [Required(ErrorMessage = "Introduzca una imagen para la publicación")]
        [Display(Name = "Foto")]
        public String photo
        {
            get
            {
                return _photo;
            }

            set
            {
                _photo = value;
            }
        }
        [RegularExpression("^(?!^ *$)^.+$", ErrorMessage = "No puede ingresar solo espacios")]
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Términos y condiciones")]
        public String termscondition
        {
            get
            {
                return _termscondition;
            }

            set
            {
                _termscondition = value.TrimStart(' ').TrimEnd(' ');
            }
        }
        [Display(Name = "Cantidad máxima")]
        public Int32 maxquantity
        {
            get
            {
                return _maxquantity;
            }

            set
            {
                _maxquantity = value;
            }
        }
        [Display(Name = "Condición visible")]
        public String visiblecondition
        {
            get
            {
                return _visiblecondition;
            }

            set
            {
                _visiblecondition = value.TrimStart(' ').TrimEnd(' ');
            }
        }
        [Display(Name = "Categoría")]
        public Int64 idpublicationcategory
        {
            get
            {
                return _idpublicationcategory;
            }

            set
            {
                _idpublicationcategory = value;
            }
        }
        [Display(Name = "Estado")]
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
        [Display(Name = "Categorías")]
        public List<PublicationCategoryVM> publicationcategories
        {
            get
            {
                return _publicationcategories;
            }

            set
            {
                _publicationcategories = value;
            }
        }
        [Display(Name = "Etiquetas")]
        [CustomDA.ListValidator(1, 15, ErrorMessage = "Debe seleccionar entre 1 y 15 etiquetas")]
        public List<PublicationBCTagVM> tags
        {
            get
            {
                return _tags;
            }

            set
            {
                _tags = value;
            }
        }
        [Display(Name = "Categoría")]
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
        #endregion



    }
}