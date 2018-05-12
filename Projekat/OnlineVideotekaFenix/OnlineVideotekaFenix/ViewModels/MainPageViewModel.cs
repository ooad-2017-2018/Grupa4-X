using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OnlineVideotekaFenix.Models;
using OnlineVideotekaFenix.Views;
using OnlineVideotekaFenix.Helper;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using System.Security;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Windows.UI.Popups;

namespace OnlineVideotekaFenix.ViewModels
{
    public class MainPageViewModel
    {
        #region Validacija readonly atributi

        private readonly string[] validatePropertiesLogin = { "Username", "Lozinka" };
        private readonly string[] validatePropertiesRegistracija = { "Username", "Lozinka", "Datumrodjenja", "Imeiprezime" };
        private readonly string[] validatePropertiesAzuriranjeFilmova = { "NazivFilma", "Godina", "Zanr", "Reziser", "Glumci", "VrijemeTrajanja", "Cijena" };
        private readonly string[] validatePropertiesBrisanjeFilmova = { "Username", "Lozinka" };
        private readonly string[] validatePropertiesBrisanjeKorisnika = { "Username", "Lozinka" };

        #endregion

        #region Icommands

        public ICommand LoginOtvori { get; set; }
        public ICommand LoginClick { get; set; }
        public ICommand RegistracijaClick { get; set; }
        public ICommand RegistracijaOtvori { get; set; }
        public ICommand IzlazClick { get; set; }
        public ICommand DodajPosterClick { get; set; }
        public ICommand OtvoriKameruClick { get; set; }
        public ICommand AzuriranjeFilmovaClick { get; set; }

        public ICommand DodajFilmClick { get; set; }







        #endregion

        #region Atributi
        public Videoteka Videoteka { get; set; }
        public string LoginUsername { get; set; }
        public string LoginPassword { get; set; }

        public string RegistracijaUsername { get; set; }
        public string RegistracijaPassword { get; set; }
        public string RegistracijaDatumRodjenja { get; set; }
        public string RegistracijaImePrezime { get; set; }

        public string NazivFilma { get; set; }



        #endregion

        #region Konstruktori

        public MainPageViewModel()
        {
            this.Videoteka = new Videoteka();
            Videoteka.ListaAdministratora.Add(new Administrator("Goba", "DRVOPROMET"));
            Videoteka.ListaKorisnika.Add(new Korisnik("Ado", "MERCATOR"));
            
            

            #region Otvaranje viewa

            RegistracijaOtvori = new RelayCommand<Object>(RegistracijaOtvoriNew, potvrdi);
            LoginOtvori = new RelayCommand<Object>(LoginKorisnikaOtvori, potvrdi);
            AzuriranjeFilmovaClick = new RelayCommand<Object>(AzuriranjeFilmovaOtvori, potvrdi);

            #endregion

            #region Izlaz

            IzlazClick = new RelayCommand<Object>(IzlazKorisnika, potvrdi);

            #endregion

            #region Registracija buttoni

            RegistracijaClick = new RelayCommand<Object>(RegistracijaKorisnika, potvrdi);
            OtvoriKameruClick = new RelayCommand<Object>(OtvoriKameru, boolDodaj);

            #endregion

            #region Login buttoni

            LoginClick = new RelayCommand<Object>(LoginKorisnika, potvrdi);

            #endregion

            #region Azuriranje filmova buttoni

            DodajPosterClick = new RelayCommand<Object>(DodajPoster, boolDodaj);
            DodajFilmClick = new RelayCommand<Object>(DodajFilm, boolDodaj);

            #endregion

            #region Brisanje filmova buttoni

            #endregion

            #region Brisanje korisnika buttoni

            #endregion

            #region Validacija

            #endregion

        }

        #endregion

        #region Funkcije

        #region Potvrde

        public bool potvrdi(Object o)
        {
            return true;
        }

        public bool boolDodaj(Object o)
        {
            return true;
        }

        #endregion

        #region Otvaranje viewa
        public void RegistracijaOtvoriNew(Object o)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(Registracija), this);

        }

        public void LoginKorisnikaOtvori(Object o)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(Login), this);

        }

        public void AzuriranjeFilmovaOtvori(Object o)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(AzuriranjeFilmova), this);
        }

        #endregion

        #region Izlaz

        public void IzlazKorisnika(Object o)
        {
            Application.Current.Exit();
        }

        #endregion

        #region Registracija buttoni

        public void RegistracijaKorisnika(Object o)
        {


        }

        public void OtvoriKameru(Object o)
        {
            // Pokrece se web kamera da bi se korisnik uslikao
            // Vanjski uredjaj jos nije implementiran
        }

        #endregion

        #region Login buttoni

        public async void LoginKorisnika(Object o)
        {
            foreach (Administrator administrator in Videoteka.ListaAdministratora)
            {
                if (administrator.Username.Equals(LoginUsername) && administrator.Lozinka.Equals(LoginPassword))
                {
                    await (new MessageDialog("Uspješan login administratora")).ShowAsync();
                    AzuriranjeFilmovaOtvori(o);
                    return;
                }
            }
             foreach (Korisnik korisnik in Videoteka.ListaKorisnika)
             {
                if (korisnik.Username.Equals(LoginUsername) && korisnik.Lozinka.Equals(LoginPassword))
                {
                    await (new MessageDialog("Uspješan login korisnika")).ShowAsync();
                    RegistracijaOtvoriNew(o);
                    return;
                }     
             }
            await (new MessageDialog("Neispravan unos")).ShowAsync();

        }

        #endregion

        #region Azuriranje filmova buttoni
        public void DodajPoster(Object o)
        {

        }

        public void DodajFilm(Object o)
        {
            

        }


        #endregion

        #region Brisanje filmova buttoni

        #endregion

        #region Brisanje korisnika buttoni

        #endregion

        #region Validacija

        #region Validacija login

        public bool isValid()
        {

            {
                foreach (string property in validatePropertiesLogin)
                {
                    if (getValidationError(property) != null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        string getValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "Username":
                    error = validirajUsername();
                    break;
                case "Lozinka":
                    error = validirajLozinku();
                    break;
            }
            return error;
        }

        private string validirajUsername()
        {
            string username = "";
            if (String.IsNullOrWhiteSpace(username)) return "Morate unijeti korisnicko ime!";
            return null;
        }        private string validirajLozinku()
        {
            string lozinka = "";
            if (String.IsNullOrWhiteSpace(lozinka)) return "Morate unijeti lozinku!";
            return null;
        }

        #endregion

        #region Validacija registracija

        #endregion

        #region Validacija azuriranjeFilmova

        #endregion

        #endregion

        #region Pomocne funkcije
        /*
        public SecureString toSecureString(string lozinka)
        { 
           var secure = new SecureString();
           foreach (char c in lozinka)
           {
               secure.AppendChar(c);
           }
            return secure;
        }
        
        

        String SecureStringToString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = SecureStringMarshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }*/

        


        #endregion

        #endregion

    }
}

/*
 * 
 * 
    */