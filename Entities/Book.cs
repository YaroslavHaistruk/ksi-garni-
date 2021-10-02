using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class Book
    {
        [HiddenInput(DisplayValue=false)]
        [Display(Name = "ID")]
        public int BookId { get; set; }

        [Display(Name="Nazwa")]
        [Required(ErrorMessage= "Proszę podać nazwę książki")]
        public string Name { get; set; }

        [Display(Name = "Autor")]
        [Required(ErrorMessage = "Podaj nazwisko autora")]
        public string Author { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Wprowadź opis książki")]
        public string Description { get; set; }

        [Display(Name = "Kategoria")]
        [Required(ErrorMessage = "Proszę napisać kategorię pracy")]
        public string Genre { get; set; }

        [Display(Name = "Cena (zl)")]
        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage = "Wpisz dodatnią wartość ceny")]
        public decimal Price { get; set; }
    }
}
