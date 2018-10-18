using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class RenewConfirmRegistrationVM
    {
        [Required(ErrorMessage = "Ingrese un Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Formato de mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Confirme su Email")]
        [Display(Name = "Confirmar Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Formato de mail inválido")]
        [Compare("Email", ErrorMessage = "Los emails no coinciden")]
        public string ConfirmEmail { get; set; }
    }
}