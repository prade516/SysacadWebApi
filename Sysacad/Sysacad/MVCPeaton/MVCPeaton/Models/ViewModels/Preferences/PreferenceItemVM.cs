using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels.Preferences
{
    public class PreferenceItemVM : BaseVM
    {
        #region members
        private Int64 _idItem;
        private String _name;
        private Int64 _idpreference;
        private Int32 _state;
        private Boolean _checked;
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

        
        [Display(Name = "Nombre del rubro")]
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

        public Int64 Idpreference
        {
            get
            {
                return _idpreference;
            }

            set
            {
                _idpreference = value;
            }
        }

        public Int32 State
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

        public Boolean ischecked
        {
            get
            {
                return _checked;
            }

            set
            {
                _checked = value;
            }
        }
        public Int64 idpreferenceitem
        {
            get
            {
                return Id;
            }
        }
        #endregion
    }
}