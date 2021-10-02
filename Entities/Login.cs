using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class Login
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "ID")]
        public int LoginId { get; set; }

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Proszę napisać imię")]
        public string Imie { get; set; }

        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Wprowadź hasło")]
        public string Pass { get; set; }
    }
}
