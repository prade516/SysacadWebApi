using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class BrancheVM
    {
        #region Members
        // Members
        private Int64 _idbranche;
        private String _name;
        private String _address;
        private Int32 _addressnumber;
        private Int32 _state;

        // ForeignKey
        private Int64 _idbusinessconfiguration;

        // Navigation property
        private BusinessConfigurationVM _BusinessConfiguration;
        #endregion

        #region Properties
        // Properties
        public Int64 idbranche
        {
            get
            {
                return _idbranche;
            }

            set
            {
                _idbranche = value;
            }
        }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [RegularExpression("^[a-zA-ZÀ-ÿ0-9]+(\\s+[-_a-zA-ZÀ-ÿ0-9]+)*$", ErrorMessage = "Solamente se permiten letras, numeros y espacios (Solo para separar)")]
        [StringLength(80, ErrorMessage = "Longitud mínima de 1 caracter y máxima de 80 caracteres", MinimumLength = 1)]
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

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Debe ingresar una calle")]
        [RegularExpression("^[a-zA-ZÀ-ÿ0-9]+(\\s+[-_a-zA-ZÀ-ÿ0-9]+)*$", ErrorMessage = "Solamente se permiten letras, numeros y espacios (Solo para separar)")]
        [StringLength(80, ErrorMessage = "Longitud mínima de 1 caracter y máxima de 80 caracteres", MinimumLength = 1)]
        [Display(Name = "Calle")]
        public String address
        {
            get
            {
                return _address;
            }

            set
            {
                _address = value;
            }
        }

        [Required(ErrorMessage = "Debe ingresar un numero de direccion")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Debe ser mayor a 0")]
        [RegularExpression("^[0-9]+([0-9]+)*$", ErrorMessage = "Debe ser un número entero")]
        [Display(Name = "Numero de direccion")]
        public Int32 addressnumber
        {
            get
            {
                return _addressnumber;
            }

            set
            {
                _addressnumber = value;
            }
        }

        [Required]
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

        // ForeignKey
        public Int64 idbusinessconfiguration
        {
            get
            {
                return _idbusinessconfiguration;
            }

            set
            {
                _idbusinessconfiguration = value;
            }
        }

        // Navigation property
        public BusinessConfigurationVM BusinessConfiguration
        {
            get
            {
                return _BusinessConfiguration;
            }

            set
            {
                _BusinessConfiguration = value;
            }
        }
        #endregion
    }
}