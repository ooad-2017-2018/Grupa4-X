using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
}