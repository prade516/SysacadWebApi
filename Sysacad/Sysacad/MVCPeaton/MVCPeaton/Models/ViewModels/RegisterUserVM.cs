using MVCPeaton.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static MVCPeaton.Enums.GenreEnum;

namespace MVCPeaton.Models.ViewModels
{
    public class RegisterUserVM
    {
        [Required(ErrorMessage = "Ingrese un Nombre de Usuario")]
        [Display(Name = "Nombre de Usuario")]
        //[RegularExpression("?:[a-zA-Z0-9]+\\s?)+[a-zA-Z0-9_]+", ErrorMessage ="Solo puede contener números, letras y _ pero no al comienzo")]
        [MinLength(3, ErrorMessage = "Mínimo 3 caracteres")]
        [RegularExpression("^([a-zA-Z0-9])+[a-zA-Z0-9_]+$", ErrorMessage = "Solo puede contener números, letras y _ pero no al comienzo")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Ingrese su Nombre")]
        [Display(Name = "Nombre")]
        [MaxLength(10, ErrorMessage = "Máximo 10 caracteres")]
        [RegularExpression("[a-zA-ZáéíóúÁÉÍÓÚñÑ]+", ErrorMessage = "Solo puede contener letras sin espacios")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Ingrese su Apellido")]
        [Display(Name = "Apellido")]
        [MaxLength(10, ErrorMessage = "Máximo 10 caracteres")]
        [RegularExpression("[a-zA-ZáéíóúÁÉÍÓÚñÑ]+", ErrorMessage = "Solo puede contener letras sin espacios")]
        public string LastName { get; set; }

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

        [Required(ErrorMessage = "Ingrese un Password")]
        [StringLength(100, ErrorMessage = "Debe escribir un password mayor o igual a 6 caracteres y menor a 100", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirme su Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Password")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        [Required(ErrorMessage = "Ingrese un Dni")]
        [MaxLength(8, ErrorMessage = "Menor o igual a 8 caracteres")]
        [MinLength(7, ErrorMessage = "Mayor o igual a 7 caracteres")]
        [Display(Name = "Dni")]
        [RegularExpression("[0-9]+", ErrorMessage = "Solo puede contener números")]
        public string dni { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public int idlocation { get; set; }

        [MaxLength(15, ErrorMessage = "Menor o igual a 15 caracteres")]
        [Display(Name = "Genero")]
        public string genre { get; set; }
        [Display(Name = "Profesión")]
        [MaxLength(20, ErrorMessage = "Menor o igual a 20 caracteres")]
        [RegularExpression("[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+", ErrorMessage = "Solo puede contener letras")]
        public string profession { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        [Required]
        [MaxLength(500)]
        public string profilephoto { get; set; }

        //[Required(ErrorMessage = "Campo Obligatorio")]
        public int state { get; set; }

        [Display(Name = "Edad")]
        [Range(1, 120, ErrorMessage = "Edad entre 1 y 120 años")]
        [Required(ErrorMessage = "Ingrese su Edad")]
        public int age { get; set; }

        [MaxLength(50, ErrorMessage = "Menor o igual a 50 caracteres")]
        [RegularExpression("^([a-zA-Z0-9áéíóúÁÉÍÓÚñÑ])+[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "Solo puede contener números y letras y mayor a 1 caracter")]
        [Display(Name = "Dirección")]
        public string address { get; set; }
        [Display(Name = "N° Calle")]
        [Range(0, 99999, ErrorMessage = "N° entre 1 y 99999")]
        public int addressnumber { get; set; }

        public Int64 idpeatonusers { get; set; }

        public int idprovince { get; set; }
        [Display(Name = "Localidades")]
        public List<LocationVM> locations { get; set; }
        [Display(Name = "Provincias")]
        public List<ProvinceVM> provinces { get; set; }

        [Display(Name = "Género")]
        public List<Genre> genres { get; set; }

    }
}