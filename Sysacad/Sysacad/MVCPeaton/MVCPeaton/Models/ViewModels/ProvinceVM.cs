using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class ProvinceVM : BaseVM
    {
        #region members
        [Required(ErrorMessage = "Debe Ingresar un nombre")]
        private String _name;
        private String _country;
        private String _mylocationslink;
        private List<LocationVM> _mylocations;
        #endregion
        #region properties
        [Display(Name = "Provincia")]
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression("^[a-zA-ZÀ-ÿ0-9]+(\\s+[-_a-zA-ZÀ-ÿ0-9]+)*$", ErrorMessage = "Solamente se permiten letras, numeros y espacios (Solo para separar)")]
        [StringLength(50, ErrorMessage = "Longitud mínima de 1 caracter y máxima de 50 caracteres", MinimumLength = 1)]
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

        [Display(Name = "País")]
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression("^[a-zA-ZÀ-ÿ0-9]+(\\s+[-_a-zA-ZÀ-ÿ0-9]+)*$", ErrorMessage = "Solamente se permiten letras, numeros y espacios (Solo para separar)")]
        [StringLength(50, ErrorMessage = "Longitud mínima de 1 caracter y máxima de 50 caracteres", MinimumLength = 1)]
        public String Country
        {
            get
            {
                return _country;
            }

            set
            {
                _country = value;
            }
        }

        public String MyLocationsLink
        {
            get
            {
                return _mylocationslink;
            }

            set
            {
                _mylocationslink = value;
            }
        }

        [Display(Name = "Mis localidades")]
        public List<LocationVM> MyLocations
        {
            get
            {
                return _mylocations;
            }

            set
            {
                _mylocations = value;
            }
        }
        #endregion
    }
}