using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class ResetPasswordVM
    {
        public long idresetpassword { get; set; }
        [Required]
        public string token { get; set; }
        public int state { get; set; }
        public DateTime expiredate { get; set; }
        [Required]
        public string email { get; set; }

        public string rid { get; set; }

        [Required(ErrorMessage = "Ingrese un Password")]
        [Display(Name = "Ingrese su nueva Password")]
        [StringLength(100, ErrorMessage = "Debe escribir un password mayor o igual a 6 caracteres y menor a 100", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string newpassword { get; set; }

        [Required(ErrorMessage = "Confirme su Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Password")]
        [Compare("newpassword", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; }
    }
}