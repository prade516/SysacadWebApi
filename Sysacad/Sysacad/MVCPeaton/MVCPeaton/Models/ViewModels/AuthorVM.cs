using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPeaton.Models.ViewModels
{
    public class AuthorVM:BaseVM
    {
        
        //public long Id { get; set; }
        [Required(ErrorMessage ="Debe Ingresar un nombre")]
        public string Name { get; set; }

        public string MyBooksLink{ get; set; }
        public List<BookVM> mybooks { get; set; }
    }
}