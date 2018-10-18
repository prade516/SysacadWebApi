using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class EmployeeAccountVM
    {
        #region Members
        // Members
        private Int64 _idemployeeaccount;
        private String _username;
        private String _password;
        private String _confirm;
        private Int32 _state;

        // ForeignKey
        private Int64 _idbusinessconfiguration;

        // Navigation property
        private BusinessConfigurationVM _BusinessConfiguration;
        #endregion

        #region Properties
        // Properties
        public Int64 idemployeeaccount
        {
            get
            {
                return _idemployeeaccount;
            }

            set
            {
                _idemployeeaccount = value;
            }
        }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Debe ingresar un usuario")]
        [RegularExpression("^[a-zA-ZÀ-ÿ0-9]+(\\s+[-_a-zA-ZÀ-ÿ0-9]+)*$", ErrorMessage = "Solamente se permiten letras, numeros y espacios (Solo para separar)")]
        [StringLength(80, ErrorMessage = "Longitud mínima de 1 caracter y máxima de 80 caracteres", MinimumLength = 1)]
        [Display(Name = "Usuario")]
        public String username
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

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Introduzca una contraseña")]
        [StringLength(20, ErrorMessage = "Debe contener entre 6 a 20 caracteres", MinimumLength = 6)]
        [Display(Name = "Contraseña")]
        public String password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Vuelva a introducir la contraseña")]
        [StringLength(20, ErrorMessage = "Debe contener entre 6 a 20 caracteres", MinimumLength = 6)]
        [Compare("password")]
        public String confirm
        {
            get
            {
                return _confirm;
            }

            set
            {
                _confirm = value;
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