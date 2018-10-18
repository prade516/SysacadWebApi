using Microsoft.IdentityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels.Preferences
{
    public class PreferenceVM : BaseVM
    {
        #region members
        private String _username;
        private List<PreferenceBankVM> _mybanks;
        private List<PreferenceTagVM> _mytags;
        private List<PreferenceItemVM> _myitems;
        private String _mybankslink;
        private String _mytagslink;
        private String _myitemslink;
        #endregion
        #region properties
        public string username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        [Display(Name = "Bancos")]
        public List<PreferenceBankVM> mybanks
        {
            get
            {
                return _mybanks;
            }

            set
            {
                _mybanks = value;
            }
        }
        [Display(Name = "Etiquetas")]
        [CustomDA.ListValidator(5)]
        public List<PreferenceTagVM> mytags
        {
            get
            {
                return _mytags;
            }

            set
            {
                _mytags = value;
            }
        }
        [CustomDA.ListValidator(1)]
        [Display(Name = "Rubros")]
        public List<PreferenceItemVM> myitems
        {
            get
            {
                return _myitems;
            }

            set
            {
                _myitems = value;
            }
        }

        public string mybankslink
        {
            get
            {
                return _mybankslink;
            }

            set
            {
                _mybankslink = value;
            }
        }

        public string mytagslink
        {
            get
            {
                return _mytagslink;
            }

            set
            {
                _mytagslink = value;
            }
        }

        public string myitemslink
        {
            get
            {
                return _myitemslink;
            }

            set
            {
                _myitemslink = value;
            }
        }
        #endregion
    }
}