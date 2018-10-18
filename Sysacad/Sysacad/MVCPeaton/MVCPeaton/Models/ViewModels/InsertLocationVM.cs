using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class InsertLocationVM
    {
        #region members
        private String _name;
        private Int32 _idprovince;
        private String _myprovincelink;
        private List<ProvinceVM> _provinces;
        #endregion
        #region properties
        [Required(ErrorMessage = "Debe Ingresar un nombre")]
        [Display(Name = "Localidad")]
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

        public String MyProvinceLink
        {
            get
            {
                return _myprovincelink;
            }

            set
            {
                _myprovincelink = value;
            }
        }
        [Display(Name = "Provincia")]
        public List<ProvinceVM> provinces
        {
            get
            {
                return _provinces;
            }

            set
            {
                _provinces = value;
            }
        }

        public int idprovince
        {
            get
            {
                return _idprovince;
            }

            set
            {
                _idprovince = value;
            }
        }
        #endregion
    }
}