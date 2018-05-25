using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;


namespace OnlineVideotekaFenixASPNET.Models
{
    public class FilmViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Year")]
        public string Year { get; set; }

        [Required]
        [Display(Name = "Rating")]
        public string Rating { get; set; }

        [Required]
        [Display(Name = "Duration")]
        public string Duration { get; set; }

        [Required]
        [Display(Name = "Length")]
        public string Length { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public string Genre { get; set; }

        [Required]
        [Display(Name = "Director")]
        public string Director { get; set; }

        [Required]
        [Display(Name = "Actors")]
        public string Actors { get; set; }

        [Required]
        [Display(Name = "Price")]
        public string Price { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }


        public FilmViewModel()
        {
            Name = "Mad Max: Fury Road";
            Year = "2015";
            Rating = "8.1";
            Duration = "123 minutes";
            Genre = "Action";
            Director = "George Miller";
            Actors = "Tom Hardy, Charlize Theron";
            Price = "2.00 $";
        }

       
        


    }
}