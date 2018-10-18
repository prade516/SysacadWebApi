using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class PublicationCategoryVM : BaseVM
    {
        #region Members
        private String _name;
        private Int32 _state;
        private String _description;
        #endregion
        #region Properties
        [RegularExpression("^(?!^ *$)^.+$", ErrorMessage = "No puede ingresar solo espacios")]
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Nombre")]
        public String name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value.TrimStart(' ').TrimEnd(' ');
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
        [Display(Name = "Descripción")]
        [RegularExpression("^(?!^ *$)^.+$",ErrorMessage ="No puede ingresar solo espacios")]
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
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
        #endregion
    }
}