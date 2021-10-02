using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Wpisz swoje imię")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Adres wysyłki")]
        [Display(Name= "Ulica")]
        public string Line1 { get; set; }
        [Display(Name = "Mieszkanie")]
        public string Line2 { get; set; }
        [Display(Name = "Kod")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Wprowadź miasto")]
        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Required(ErrorMessage = "Wprowadź swój kraj")]
        [Display(Name = "Kraj")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
