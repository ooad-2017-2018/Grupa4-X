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
        [Required]
        [Display(Name = "Movies")]
        public List<Film> ListaFilmova
        {
            get
            {
                FenixContext db = new FenixContext();
                List<Film> movies = db.Film.ToList();
                List<Film> listaResult = new List<Film>();
                foreach (Film film in movies)
                {
                    if ((film.NazivFilma.ToLower().Contains(VarGlobal.SearchMovieName.ToLower()) ||
                        VarGlobal.SearchMovieName.ToLower().Contains(film.NazivFilma.ToLower())) &&
                        (film.ZanrFilma.ToLower().Contains(VarGlobal.SearchMovieGenre.ToLower()) ||
                        VarGlobal.SearchMovieGenre.ToLower().Contains(film.ZanrFilma.ToLower())))
                    {
                        listaResult.Add(film);
                    }
                }

                return listaResult;
            }
            set
            {
                if (true);
            }
        }

    }

    public class SearchResultsUserViewModel
    {
        [Display(Name = "Users")]
        public List<Korisnik> ListaKorisnika
        {
            get
            {
                FenixContext db = new FenixContext();
                List<Korisnik> users = db.Korisnik.ToList();
                List<Korisnik> listaResult = new List<Korisnik>();
                foreach (Korisnik korisnik in users)
                {
                    if ((korisnik.ImePrezime.ToLower().Contains(VarGlobal.SearchUserName.ToLower()) ||
                         VarGlobal.SearchUserName.ToLower().Contains(korisnik.ImePrezime.ToLower())) &&
                        (korisnik.Username.ToLower().Contains(VarGlobal.SearchUserUsername.ToLower()) ||
                         VarGlobal.SearchUserUsername.ToLower().Contains(korisnik.Username.ToLower())))
                    {
                        listaResult.Add(korisnik);
                    }
                }

                return users;
            }
            set
            {
                if (true);
            }
        }
    }
}