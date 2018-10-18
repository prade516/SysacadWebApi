using MVCPeaton.Models.Misc;
using MVCPeaton.Tools.ListResolvers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static MVCPeaton.Enums.GenreEnum;

namespace MVCPeaton.Models.ViewModels
{
    public class RegisterBusinessVM
    {
        [Required(ErrorMessage = "Ingrese un Nombre de Usuario")]
        [Display(Name = "Nombre de Usuario")]
        [MinLength(3, ErrorMessage = "Mínimo 3 caracteres")]
        [RegularExpression("^([a-zA-Z0-9])+[a-zA-Z0-9_]+$", ErrorMessage = "Solo puede contener números, letras y _ pero no al comienzo")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string Username { get; set; }

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

        public Int64 idbusiness { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public int idlocation { get; set; }
        public int state { get; set; }

        [MaxLength(50, ErrorMessage = "Menor o igual a 50 caracteres")]
        [RegularExpression("^([a-zA-ZáéíóúÁÉÍÓÚñÑ])+[a-zA-Z áéíóúÁÉÍÓÚñÑ]+$", ErrorMessage = "Solo puede contener letras")]
        [Required(ErrorMessage = "Debe ingresar el nombre de la empresa")]
        [Display(Name = "Nombre de la Empresa")]
        public string name { get; set; }

        [Required(ErrorMessage = "Debe ingresar la dirección")]
        [MaxLength(50, ErrorMessage = "Menor o igual a 50 caracteres")]
        [RegularExpression("^([a-zA-Z0-9áéíóúÁÉÍÓÚñÑ])+[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "Solo puede contener números y letras y mayor a 1 caracter")]
        [Display(Name = "Dirección")]
        public string address { get; set; }

        [Required(ErrorMessage = "Debe ingresar la altura")]
        [Display(Name = "Altura")]
        [Range(0, 99999, ErrorMessage = "N° entre 1 y 99999")]
        public int addressnumber { get; set; }

        [Display(Name = "Piso")]
        [RegularExpression("^([a-zA-Z0-9áéíóúÁÉÍÓÚñÑ ])+$", ErrorMessage = "Solo puede contener números y letras ")]
        public string floor { get; set; }
        [Display(Name = "Dirección en Piso")]
        [RegularExpression("^([a-zA-Z0-9áéíóúÁÉÍÓÚñÑ ])+$", ErrorMessage = "Solo puede contener números y letras")]
        public string floornumber { get; set; }

        [Required(ErrorMessage = "Ingrese su Nombre")]
        [Display(Name = "Nombre Responsable")]
        [MaxLength(40, ErrorMessage = "Máximo 40 caracteres")]
        [RegularExpression("[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+", ErrorMessage = "Solo puede contener letras")]
        public string responsablename { get; set; }

        [Required(ErrorMessage = "Ingrese su Teléfono")]
        [Display(Name = "Teléfono")]
        [StringLength(20, ErrorMessage = "Longitud mínima 6 caracteres y máxima 20 caracteres", MinimumLength = 6)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Incorrecto, Ej Válido: 3414255502")]
        public string responsablephone { get; set; }

        [Required(ErrorMessage = "Ingrese un CUIT, CUIL o CDI")]
        [MaxLength(20, ErrorMessage="Menor o igual a 20 caracteres")]
        [RegularExpression("[0-9]+", ErrorMessage = "Solo puede contener números")]
        [Display(Name = "CUIT/CUIL/CDI")]
        public string cuitcuilcdi { get; set; }
        [Required]
        public long idtypedocument { get; set; }
        [Required]
        [MaxLength(20)]
        public string businesstype { get; set; }

        [Required]
        public long playeruserid { get; set; }



        public long idplayeruser { get; set; }


        
        [Display(Name = "Nombre Público")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        [RegularExpression("[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+", ErrorMessage = "Solo puede contener letras")]
        public string publicname { get; set; }


        [MaxLength(20)]
        public string genre { get; set; }

        
        public DateTime birthdate { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public string birthdate2 { get; set; }

        [Display(Name = "Profesión")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
        [RegularExpression("[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+", ErrorMessage = "Solo puede contener letras")]
        public string profession { get; set; }
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        [MaxLength(500)]
        public string profilephoto { get; set; }

        [MaxLength(8, ErrorMessage = "Menor o igual a 8 caracteres")]
        [MinLength(7, ErrorMessage = "Mayor o igual a 7 caracteres")]
        [Display(Name = "Dni")]
        [RegularExpression("[0-9]+", ErrorMessage = "Solo puede contener números")]
        public string dni { get; set; }

        public int stateplayeruser { get; set; }

        [Required]
        [Display(Name = "¿Crear usuario jugador?")]
        public bool CreatePlayerUser { get; set; }

        public int idprovince { get; set; }
        
        [Display(Name = "Localidades")]
        public List<LocationVM> locations { get; set; }
        [Display(Name = "Provincias")]
        public List<ProvinceVM> provinces { get; set; }

        [Display(Name = "Género")]
        public List<Genre> genres { get; set; }

        [Display(Name = "Tipo de Documento")]
        public List<TypeDocumentVM> typesdocuments  { get; set; }

        [Display(Name = "Persona Jurídica")]
        public List<TypeActorVM> typesactors { get; set; }
    }
}