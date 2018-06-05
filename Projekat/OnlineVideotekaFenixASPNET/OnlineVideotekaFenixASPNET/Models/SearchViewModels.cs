using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineVideotekaFenixASPNET.Models
{
    public class SearchMovieViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public string Genre { get; set; }

    }

    public class SearchUserViewModel
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

    }

    public class SearchResultsMovieViewModel
    {
        [Display(Name = "Users")]
        public List<Korisnik> ListaKorisnika { get; set; }

    }

    public class SearchResultsUserViewModel
    {
        [Display(Name = "Movies")]
        public List<Film> ListaFilmova { get; set; }
    }
}