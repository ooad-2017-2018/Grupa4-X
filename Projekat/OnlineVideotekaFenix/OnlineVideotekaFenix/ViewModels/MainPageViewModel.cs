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
        private readonly string[] validatePropertiesRegistracija = { "Username", "Lozinka", "DatumRodjenja", "ImePrezime" };
        private readonly string[] validatePropertiesAzuriranjeFilmova = { "NazivFilma", "Godina", "Zanr", "Reziser", "Glumci", "VrijemeTrajanja", "Cijena", "Sinopsis" };        

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
        public ICommand BrisanjeFilmovaSearch { get; set; }
        public ICommand BrisanjeKorisnikaSearch { get; set; }









        #endregion

        #region Atributi
        public Videoteka Videoteka { get; set; }
        public string LoginUsername { get; set; }
        public string LoginPassword { get; set; }

        public string RegistracijaUsername { get; set; }
        public string RegistracijaPassword { get; set; }
        public string RegistracijaDatumRodjenja { get; set; }
        public string RegistracijaImePrezime { get; set; }

        public string AzuriranjeFilmovaNazivFilma { get; set; }
        public string AzuriranjeFilmovaGodinaFilma { get; set; }
        public string AzuriranjeFilmovaZanrFilma { get; set; }
        public string AzuriranjeFilmovaReziser { get; set; }
        public string AzuriranjeFilmovaGlumci { get; set; }
        public string AzuriranjeFilmovaVrijemeTrajanja { get; set; }
        public string AzuriranjeFilmovaCijena { get; set; }

        public string AzuriranjeFilmovaSinopsis { get; set; }




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

            BrisanjeFilmovaSearch = new RelayCommand<Object>(BrisanjeFilmovaPretraga, potvrdi);

            #endregion

            #region Brisanje korisnika buttoni

            BrisanjeKorisnikaSearch = new RelayCommand<Object>(BrisanjeKorisnikaPretraga, potvrdi);

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
            if (!isValidRegistracija())
                return;
            DateTime datum;
            DateTime.TryParse(RegistracijaDatumRodjenja, out datum);
            Korisnik korisnik = new Korisnik(RegistracijaImePrezime, datum, DateTime.Now, RegistracijaUsername, RegistracijaPassword);
            Videoteka.ListaKorisnika.Add(korisnik);
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
            if (!isValidLogin())
                return;

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
            if (!isValidAzuriranjeFilmova())
                return;


        }


        #endregion

        #region Brisanje filmova buttoni

        public void BrisanjeFilmovaPretraga(Object o)
        {

        }

        #endregion

        #region Brisanje korisnika buttoni

        public void BrisanjeKorisnikaPretraga(Object o)
        {

        }

        #endregion

        #region Validacija

        #region Validacija login

        public bool isValidLogin()
        {

            {
                foreach (string property in validatePropertiesLogin)
                {
                    if (getValidationErrorLogin(property) != null)
                    {
                        showErrorLogin(getValidationErrorLogin(property));
                        return false;
                    }
                }
                return true;
            }
        }

        string getValidationErrorLogin(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "Username":
                    error = validirajUsernameLogin();
                    break;
                case "Lozinka":
                    error = validirajLozinkuLogin();
                    break;
                
            }
            return error;
        }

        private string validirajUsernameLogin()
        {
            if (String.IsNullOrWhiteSpace(LoginUsername)) return "Username";
            return null;
        }

        private string validirajLozinkuLogin()
        {
            if (String.IsNullOrWhiteSpace(LoginPassword)) return "Lozinka";
            return null;
        }

        

        private async void showErrorLogin(string error)
        {
            switch (error)
            {
                case "Username":
                    await (new MessageDialog("Morate unijeti korisničko ime!")).ShowAsync();
                    break;
                case "Lozinka":
                    await (new MessageDialog("Morate unijeti lozinku!")).ShowAsync();
                    break;
            }
            

        }

        #endregion

        #region Validacija registracija

        public bool isValidRegistracija()
        {            
            foreach (string property in validatePropertiesRegistracija)
            {
                if (getValidationErrorRegistracija(property) != null)
                {
                    showErrorRegistracija(getValidationErrorRegistracija(property));
                    return false;
                }
            }
            return true;            
        }

        string getValidationErrorRegistracija(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "Username":
                    error = validirajUsernameRegistracija();
                    break;
                case "Lozinka":
                    error = validirajLozinkuRegistracija();
                    break;
                case "DatumRodjenja":
                    error = validirajDatumRodjenjaRegistracija();
                    break;
                case "ImePrezime":
                    error = validirajImePrezimeRegistracija();
                    break;
            }
            return error;
        }

        private string validirajUsernameRegistracija()
        {
            if (String.IsNullOrWhiteSpace(RegistracijaUsername)) return "Username";
            return null;
        }

        private string validirajLozinkuRegistracija()
        {
            if (String.IsNullOrWhiteSpace(RegistracijaPassword)) return "Lozinka";
            return null;
        }

        private string validirajDatumRodjenjaRegistracija()
        {
            if (String.IsNullOrWhiteSpace(RegistracijaDatumRodjenja)) return "DatumRodjenja";
            return null;
        }

        private string validirajImePrezimeRegistracija()
        {
            if (String.IsNullOrWhiteSpace(RegistracijaImePrezime)) return "ImePrezime";
            return null;
        }

        private async void showErrorRegistracija(string error)
        {
            switch (error)
            {
                case "Username":
                    await (new MessageDialog("Morate unijeti korisničko ime!")).ShowAsync();
                    break;
                case "Lozinka":
                    await (new MessageDialog("Morate unijeti lozinku!")).ShowAsync();
                    break;
                case "DatumRodjenja":
                    await (new MessageDialog("Morate unijeti datum rodjenja!")).ShowAsync();
                    break;
                case "ImePrezime":
                    await (new MessageDialog("Morate unijeti ime i prezime!")).ShowAsync();
                    break;
            }


        }

        #endregion

        #region Validacija azuriranjeFilmova

        public bool isValidAzuriranjeFilmova()
        {
            foreach (string property in validatePropertiesAzuriranjeFilmova)
            {
                if (getValidationErrorAzuriranjeFilmova(property) != null)
                {
                    showErrorAzuriranjeFilmova(getValidationErrorAzuriranjeFilmova(property));
                    return false;
                }
            }
            return true;
        }

        string getValidationErrorAzuriranjeFilmova(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "NazivFilma":
                    error = validirajNazivFilmaAzuriranjeFilmova();
                    break;
                case "Godina":
                    error = validirajGodinaAzuriranjeFilmova();
                    break;
                case "Zanr":
                    error = validirajZanrAzuriranjeFilmova();
                    break;
                case "Reziser":
                    error = validirajReziserAzuriranjeFilmova();
                    break;
                case "Glumci":
                    error = validirajGlumciAzuriranjeFilmova();
                    break;
                case "VrijemeTrajanja":
                    error = validirajVrijemeTrajanjaAzuriranjeFilmova();
                    break;
                case "Cijena":
                    error = validirajCijenaAzuriranjeFilmova();
                    break;
                case "Sinopsis":
                    error = validirajSinopsisAzuriranjeFilmova();
                    break;
            }
            return error;
        }

        public Boolean imaSlova(String s)
        {
            return s.Any(x => char.IsLetter(x));
        }

        private string validirajNazivFilmaAzuriranjeFilmova()
        {
            if (String.IsNullOrWhiteSpace(AzuriranjeFilmovaNazivFilma)) return "Naziv";
            return null;
        }

        private string validirajGodinaAzuriranjeFilmova()
        {
            if (String.IsNullOrWhiteSpace(AzuriranjeFilmovaGodinaFilma)) return "Godina";
            else if (imaSlova(AzuriranjeFilmovaGodinaFilma)) return "Nedozvoljeni znakovi godina";
            return null;
        }

        private string validirajZanrAzuriranjeFilmova()
        {
            if (String.IsNullOrWhiteSpace(AzuriranjeFilmovaZanrFilma)) return "Zanr";
            return null;
        }

        private string validirajReziserAzuriranjeFilmova()
        {
            if (String.IsNullOrWhiteSpace(AzuriranjeFilmovaReziser)) return "Reziser";
            return null;
        }

        private string validirajGlumciAzuriranjeFilmova()
        {
            if (String.IsNullOrWhiteSpace(AzuriranjeFilmovaGlumci)) return "Glumci";
            return null;
        }

        private string validirajVrijemeTrajanjaAzuriranjeFilmova()
        {
            if (String.IsNullOrWhiteSpace(AzuriranjeFilmovaVrijemeTrajanja)) return "VrijemeTrajanja";
            else if (imaSlova(AzuriranjeFilmovaVrijemeTrajanja)) return "Nedozvoljeni znakovi trajanje";
            return null;
        }

        private string validirajCijenaAzuriranjeFilmova()
        {
            if (String.IsNullOrWhiteSpace(AzuriranjeFilmovaCijena)) return "Cijena";
            else if (imaSlova(AzuriranjeFilmovaCijena)) return "Nedozvoljeni znakovi cijena";
            return null;
        }
        private string validirajSinopsisAzuriranjeFilmova()
        {
            if (String.IsNullOrWhiteSpace(AzuriranjeFilmovaSinopsis)) return "Sinopsis";
            return null;
        }

        private async void showErrorAzuriranjeFilmova(string error)
        {
            switch (error)
            {
                case "Naziv":
                    await (new MessageDialog("Morate unijeti naziv filma!")).ShowAsync();
                    break;
                case "Godina":
                    await (new MessageDialog("Morate unijeti godinu!")).ShowAsync();
                    break;
                case "Zanr":
                    await (new MessageDialog("Morate unijeti zanr!")).ShowAsync();
                    break;
                case "Reziser":
                    await (new MessageDialog("Morate unijeti režisera!")).ShowAsync();
                    break;
                case "Glumci":
                    await (new MessageDialog("Morate unijeti glumce!")).ShowAsync();
                    break;
                case "VrijemeTrajanja":
                    await (new MessageDialog("Morate unijeti vrijeme trajanja!")).ShowAsync();
                    break;
                case "Cijena":
                    await (new MessageDialog("Morate unijeti cijenu!")).ShowAsync();
                    break;
                case "Sinopsis":
                    await (new MessageDialog("Morate unijeti sinopsis!")).ShowAsync();
                    break;
                case "Nedozvoljeni znakovi godina":
                    await (new MessageDialog("Godina ne smije sadržavati slova!")).ShowAsync();
                    break;
                case "Nedozvoljeni znakovi cijena":
                    await (new MessageDialog("Cijena ne smije sadržavati slova!")).ShowAsync();
                    break;
                case "Nedozvoljeni znakovi trajanje":
                    await (new MessageDialog("Trajanje filma ne smije sadržavati slova!")).ShowAsync();
                    break;
            }

        }

        #endregion

        #endregion

        #region Pomocne funkcije
        
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
        }




        #endregion

        #endregion

    }
}


