using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels.Preferences
{
    public class PreferenceTagVM : BaseVM
    {
        #region Members
        private String _name;
        private Int64 _idpreference;
        private Int64 _idtag;
        private Int32 _state;
        private Boolean _checked;
        #endregion

        #region Properties
        [Display(Name = "Nombre")]
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

        public Int64 Idtag
        {
            get
            {
                return _idtag;
            }

            set
            {
                _idtag = value;
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
        public Int64 idpreferencetag
        {
            get
            {
                return Id;
            }
        }

        #endregion
    }
}