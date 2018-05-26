using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineVideotekaFenixASPNET.Models
{
    public class ProfileViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Birth date")]
        public string BirthDate { get; set; }

        [Required]
        [Display(Name = "Movies watched this week")]
        public string MovieWeek { get; set; }

        [Required]
        [Display(Name = "Movies watched this month")]
        public string MovieMonth { get; set; }

        [Required]
        [Display(Name = "Last movie watched")]
        public string LastMovie { get; set; }
    }

    public class PurchaseViewModel
    {
        [Required]
        [Display(Name = "Paypal account")]
        public string PaypalAcc { get; set; }
        [Required]
        [Display(Name = "Credit card number")]
        public string CreditCardNumber { get; set; }
        [Required]
        [Display(Name = "Email address")]
        public string EmailAdress { get; set; }
        [Required]
        [Display(Name = "City address")]
        public string Address { get; set; }
    }

    public class UserMoviesViewModel
    {
        [Required]
        [Display(Name = "Watch list")]
        public List<String> WatchList { get; set; }

        public string SelectedItem { get; set; }
        public List<SelectListItem> selectItemList { get; set; }
    }
}