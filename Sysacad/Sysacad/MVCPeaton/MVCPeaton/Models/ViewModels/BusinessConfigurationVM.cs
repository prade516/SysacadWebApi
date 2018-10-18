using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class BusinessConfigurationVM : BaseVM
    {
        #region Members
        // Members
        private String _slogan;
        private String _profilephoto;
        private Int32 _quanityemployees;
        private String _businesstype;

        // ForeignKey
        private Int64 _iditem;
        private Int64 _idbusiness;

        // Navigation property
        private ItemVM _Item;

        //Links
        private String _MyEmployeeAccountsLink;
        private String _MyBranchesLink;

        //Lists
        private List<ItemVM> _Items;
        private List<EmployeeAccountVM> _EmployeeAccounts;
        private List<BrancheVM> _Branches;
        private List<BusinessConfigurationTagVM> _BusinessConfigurationTags;
        private List<BusinessConfigurationTagVM> _MyBusinessConfigurationTags;
        #endregion

        #region Properties
        // Properties
        [DataType(DataType.Text)]
        [RegularExpression("^[a-zA-ZÀ-ÿ0-9]+(\\s+[-_a-zA-ZÀ-ÿ0-9]+)*$", ErrorMessage = "Solamente se permiten letras, numeros y espacios (Solo para separar)")]
        [StringLength(255, ErrorMessage = "Longitud mínima de 1 caracter y máxima de 255 caracteres", MinimumLength = 1)]
        [Display(Name = "Eslogan")]
        public String slogan
        {
            get
            {
                return _slogan;
            }

            set
            {
                _slogan = value;
            }
        }

        [DataType(DataType.Text)]
        [StringLength(500, ErrorMessage = "Longitud mínima de 1 caracter y máxima de 500 caracteres", MinimumLength = 1)]
        [Display(Name = "Foto")]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public String profilephoto
        {
            get
            {
                return _profilephoto;
            }

            set
            {
                _profilephoto = value;
            }
        }
        
        [Range(1, Int32.MaxValue, ErrorMessage = "Debe ser mayor a 0")]
        [RegularExpression("^[0-9]+([0-9]+)*$", ErrorMessage = "Debe ser un número entero")]
        [Display(Name = "Cantidad de empleados")]
        public Int32 quanityemployees
        {
            get
            {
                return _quanityemployees;
            }

            set
            {
                _quanityemployees = value;
            }
        }

        public String businesstype
        {
            get
            {
                return _businesstype;
            }

            set
            {
                _businesstype = value;
            }
        }

        // ForeignKey
        public Int64 iditem
        {
            get
            {
                return _iditem;
            }

            set
            {
                _iditem = value;
            }
        }
        
        public Int64 idbusiness
        {
            get
            {
                return _idbusiness;
            }

            set
            {
                _idbusiness = value;
            }
        }

        // Navigation property
        public ItemVM Item
        {
            get
            {
                return _Item;
            }

            set
            {
                _Item = value;
            }
        }

        // Links
        public String MyEmployeeAccountsLink
        {
            get
            {
                return _MyEmployeeAccountsLink;
            }

            set
            {
                _MyEmployeeAccountsLink = value;
            }
        }

        public String MyBranchesLink
        {
            get
            {
                return _MyBranchesLink;
            }

            set
            {
                _MyBranchesLink = value;
            }
        }
        #endregion

        #region Lists
        public List<ItemVM> Items
        {
            get
            {
                return _Items;
            }

            set
            {
                _Items = value;
            }
        }

        public List<BusinessConfigurationTagVM> MyBusinessConfigurationTags
        {
            get
            {
                return _MyBusinessConfigurationTags;
            }

            set
            {
                _MyBusinessConfigurationTags = value;
            }
        }

        [CustomDA.ListValidator(1, 15, ErrorMessage = "Debe seleccionar de 1 a 15 etiquetas")]
        public List<BusinessConfigurationTagVM> BusinessConfigurationTags
        {
            get
            {
                return _BusinessConfigurationTags;
            }

            set
            {
                _BusinessConfigurationTags = value;
            }
        }

        [CustomDA.ListValidator(0, 5, ErrorMessage = "Solo se permiten 5 cuentas de empleados")]
        public List<EmployeeAccountVM> EmployeeAccounts
        {
            get
            {
                return _EmployeeAccounts;
            }

            set
            {
                _EmployeeAccounts = value;
            }
        }

        [CustomDA.ListValidator(0, 15, ErrorMessage = "Solo se permiten 15 sucursales")]
        public List<BrancheVM> Branches
        {
            get
            {
                return _Branches;
            }

            set
            {
                _Branches = value;
            }
        }
        #endregion
    }
}