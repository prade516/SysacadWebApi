using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels.Preferences
{
    public class PreferenceBankVM : BaseVM
    {
        #region members
        private String _name;
        private String _logo;
        private Int64 _idbank;
        private Int64 _idpreference;
        private Int32 _state;
        private Boolean _checked;
        #endregion
        #region properties
        [Display(Name = "Nombre del banco")]
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
        [Display(Name = "Logo")]
        public String Logo
        {
            get
            {
                return _logo;
            }

            set
            {
                _logo = value;
            }
        }

        public Int64 Idbank
        {
            get
            {
                return _idbank;
            }

            set
            {
                _idbank = value;
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

        public Int64 idpreferencebank
        {
            get
            {
                return Id;
            }
        }
        #endregion
    }
}