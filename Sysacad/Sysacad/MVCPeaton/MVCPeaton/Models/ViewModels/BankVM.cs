using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class BankVM: BaseVM
    {
        //public long idbank { get; set; }
       
        private String _name;
        private String _logo;
        [Required(ErrorMessage = "Debe Ingresar el nombre del banco")]
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
        [Required(ErrorMessage = "Debe Ingresar el logo del banco")]
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
    }
}