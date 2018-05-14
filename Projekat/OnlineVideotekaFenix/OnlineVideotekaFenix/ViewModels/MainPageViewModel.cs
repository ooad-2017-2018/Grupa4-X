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
using System.Globalization;

namespace OnlineVideotekaFenix.ViewModels
{
    public class MainPageViewModel
    {
        #region Validacija readonly atributi
        private readonly string[] validatePropertiesLogin = { "Username", "Lozinka" };
        private readonly string[] validatePropertiesRegistracija = { "Username", "Lozinka", "DatumRodjenja", "ImePrezime" };
        private readonly string[] validatePropertiesAzuriranjeFilmova = { "NazivFilma", "Godina", "Zanr", "Reziser", "Glumci", "VrijemeTrajanja", "Cijena", "Sinopsis", "Poster" };        
       

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
        public ICommand AzuriranjeFilmovaLogout { get; set; }

        public ICommand KorisnikOverviewOtvori { get; set; }










        #endregion

        #region Atributi
        public List<Film> RezultatiPretrageFilmova { get; set; }
        public List<Korisnik> RezultatiPretrageKorisnika { get; set; }


        public Administrator loginAdmin { get; set; }
        public Korisnik loginKorisnik { get; set; }
        public string loginKorisnikImePrezime { get; set; }
        public string loginKorisnikUsername { get; set; }
        public string loginKorisnikDatum { get; set; }
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
        public BitmapImage AzuriranjeFilmovaPoster { get; set; }
        


        

        #endregion

        #region Konstruktori
        public MainPageViewModel()
        {
            this.Videoteka = new Videoteka();
            Videoteka.ListaAdministratora.Add(new Administrator( "Goba", "DRVOPROMET"));
            Videoteka.ListaAdministratora.Add(new Administrator("amra", "1234"));
            Videoteka.ListaKorisnika.Add(new Korisnik("Adnan Gobeljic", DateTime.Now, DateTime.Now, "Ado", "MERCATOR"));
            Videoteka.ListaFilmova.Add(new Film("Mad Max: Fury Road", 2015, "Akcija, Avantura, Sci-Fi", "George Miller",
                "Tom Hardy, Charlize Theron, Nicholas Hoult", 120, 10,
                "A woman rebels against a tyrannical ruler in postapocalyptic Australia in search for her home-land with the help of a group of female prisoners, a psychotic worshipper, and a drifter named Max.", "ms-appx:///Assets/novi_logo_100x100.png"));

            #region Otvaranje viewa
            RegistracijaOtvori = new RelayCommand<Object>(RegistracijaOtvoriNew, potvrdi);
            LoginOtvori = new RelayCommand<Object>(LoginKorisnikaOtvori, potvrdi);
            KorisnikOverviewOtvori = new RelayCommand<Object>(KorisnikHomePageOtvori, potvrdi);
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
            AzuriranjeFilmovaLogout = new RelayCommand<Object>(AzuriranjeFilmovaLogoutClick, boolDodaj);


            #endregion

            #region Brisanje filmova buttoni
            BrisanjeFilmovaSearch = new RelayCommand<Object>(BrisanjeFilmovaPretraga, potvrdi);
            #endregion

            #region Brisanje korisnika buttoni
            BrisanjeKorisnikaSearch = new RelayCommand<Object>(BrisanjeKorisnikaPretraga, potvrdi);
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

        public void KorisnikHomePageOtvori(Object o)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(KorisnikOverview), this);
            
        }
        #endregion

        #region Izlaz
        public void IzlazKorisnika(Object o)
        {
            Application.Current.Exit();
        }
        #endregion

        #region Registracija buttoni


        public async void RegistracijaKorisnika(Object o)
        {
            if (!isValidRegistracija())
                return;
            DateTime datum;
            DateTime.TryParseExact(RegistracijaDatumRodjenja, "dd'.'MM'.'yyyy",
                           CultureInfo.InvariantCulture,
                           DateTimeStyles.None,
                           out datum);
            Korisnik korisnik = new Korisnik(RegistracijaImePrezime, datum, DateTime.Now, RegistracijaUsername, RegistracijaPassword);
            Videoteka.ListaKorisnika.Add(korisnik);
            await (new MessageDialog("Uspješna registracija!")).ShowAsync();
            LoginKorisnikaOtvori(o);
            OcistiRegistracija();
        }

        public void OtvoriKameru(Object o)
        {
            // Pokrece se web kamera da bi se korisnik uslikao
            // Vanjski uredjaj jos nije implementiran
        }
        public void OcistiRegistracija()
        {
            RegistracijaUsername = "";
            RegistracijaPassword = "";
            RegistracijaDatumRodjenja = "";
            RegistracijaImePrezime = "";
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
                    loginAdmin = administrator;
                    AzuriranjeFilmovaOtvori(o);
                    
                    
                    return;
                }
            }
             foreach (Korisnik korisnik in Videoteka.ListaKorisnika)
             {
                if (korisnik.Username.Equals(LoginUsername) && korisnik.Lozinka.Equals(LoginPassword))
                {
                    await (new MessageDialog("Uspješan login korisnika")).ShowAsync();
                    loginKorisnik = korisnik;
                    loginKorisnikDatum = korisnik.DatumRodjenja.ToString("dd.MM.yyyy");
                    loginKorisnikImePrezime = korisnik.ImePrezime.ToString();
                    loginKorisnikUsername = korisnik.Username.ToString();
                    KorisnikHomePageOtvori(o);

                    return;
                }     
             }
            await (new MessageDialog("Neispravan unos")).ShowAsync();
        }
        public void OcistiLogin()
        {
            LoginUsername = "";
            LoginPassword = "";            
        }


        #endregion

        #region Azuriranje filmova buttoni
        public async void DodajPoster(Object poster)
        {
            
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".png");
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                var varimage = new BitmapImage();
                varimage.SetSource(stream);
                ((Image)poster).Source = varimage;
                AzuriranjeFilmovaPoster = new BitmapImage();
                AzuriranjeFilmovaPoster = varimage;
            }
            else
            {
                //
            }
        
         }

        public void DodajFilm(Object poster)
        {
            if (!isValidAzuriranjeFilmova())
                return;
            int godinaFilma;
            int vrijemeTrajanja;
            double cijenaFilma;
            Int32.TryParse(AzuriranjeFilmovaGodinaFilma, out godinaFilma);
            Int32.TryParse(AzuriranjeFilmovaVrijemeTrajanja, out vrijemeTrajanja);
            double.TryParse(AzuriranjeFilmovaCijena, out cijenaFilma);

            Videoteka.ListaFilmova.Add(new Film(AzuriranjeFilmovaNazivFilma, godinaFilma, AzuriranjeFilmovaZanrFilma, AzuriranjeFilmovaReziser, AzuriranjeFilmovaGlumci, vrijemeTrajanja, cijenaFilma, AzuriranjeFilmovaSinopsis, AzuriranjeFilmovaPoster));
            
            
        }

        public void AzuriranjeFilmovaLogoutClick(Object o)
        {
            AzuriranjeFilmovaPoster = null;
            LoginKorisnikaOtvori(o);
            OcistiAzuriranjeFilmova();
        }

        public void OcistiAzuriranjeFilmova()
        {
            AzuriranjeFilmovaNazivFilma = "";
            AzuriranjeFilmovaGodinaFilma = "";
            AzuriranjeFilmovaZanrFilma = "";
            AzuriranjeFilmovaReziser = "";
            AzuriranjeFilmovaVrijemeTrajanja = "";
            AzuriranjeFilmovaCijena = "";
            AzuriranjeFilmovaSinopsis = "";
        }




        #endregion

        #region Brisanje filmova buttoni
        public void BrisanjeFilmovaPretraga(Object o)
        {
            foreach (Film f in Videoteka.ListaFilmova)
            {
                if (AzuriranjeFilmovaNazivFilma.Equals(f.NazivFilma))
                    RezultatiPretrageFilmova.Add(f);
            }

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
        private bool neispravanDatum(string datum)
        {
            DateTime Datum;
            return !(DateTime.TryParseExact(datum, "dd'.'MM'.'yyyy",
                           CultureInfo.InvariantCulture,
                           DateTimeStyles.None,
                           out Datum) && DateTime.Compare(DateTime.Now,Datum)>=0);
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
            else if (neispravanDatum(RegistracijaDatumRodjenja)) return "Neispravan datum";
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
                case "Neispravan datum":
                    await (new MessageDialog("Unijeli ste neispravan datum!")).ShowAsync();
                    break;
                case "ImePrezime":
                    await (new MessageDialog("Morate unijeti ime i prezime!")).ShowAsync();
                    break;
            }


        }

        #endregion

        #region Validacija AzuriranjeFilmova
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
                case "Poster":
                    error = validirajPosterAzuriranjeFilmova();
                    break;
            }
            return error;
        }

        public Boolean imaSlova(String s)
        {
            return s.Any(x => char.IsLetter(x));
        }

        public Boolean neispravnaGodina(String godina)
        {
            int Godina;
            return !(Int32.TryParse(godina, out Godina) && Godina >= 0 && Godina<=DateTime.Now.Year);               
        }

        public Boolean neispravnoVrijemeTrajanja(String vrijemeTrajanja)
        {
            int VrijemeTrajanja;
            return !(Int32.TryParse(vrijemeTrajanja, out VrijemeTrajanja) && VrijemeTrajanja > 0);
        }

        public Boolean neispravnaCijena(String cijena)
        {
            double Cijena;
            return !(double.TryParse(cijena, out Cijena) && Cijena>=0); // Film može biti besplatan
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
            else if (neispravnaGodina(AzuriranjeFilmovaGodinaFilma)) return "Neispravna godina";
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
            else if (neispravnoVrijemeTrajanja(AzuriranjeFilmovaVrijemeTrajanja)) return "Neispravno vrijeme trajanja";
            return null;
        }

        private string validirajCijenaAzuriranjeFilmova()
        {
            if (String.IsNullOrWhiteSpace(AzuriranjeFilmovaCijena)) return "Cijena";
            else if (imaSlova(AzuriranjeFilmovaCijena)) return "Nedozvoljeni znakovi cijena";
            else if (neispravnaCijena(AzuriranjeFilmovaCijena)) return "Neispravna cijena";
            return null;
        }
        private string validirajSinopsisAzuriranjeFilmova()
        {
            if (String.IsNullOrWhiteSpace(AzuriranjeFilmovaSinopsis)) return "Sinopsis";
            return null;
        }
        private string validirajPosterAzuriranjeFilmova()
        {
            if (AzuriranjeFilmovaPoster==null) return "Poster";
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
                case "Poster":
                    await (new MessageDialog("Morate unijeti poster!")).ShowAsync();
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
                case "Neispravna godina":
                    await (new MessageDialog("Neispravna godina filma!")).ShowAsync();
                    break;
                case "Neispravno vrijeme trajanja":
                    await (new MessageDialog("Neispravno vrijeme trajanja!")).ShowAsync();
                    break;
                case "Neispravna cijena":
                    await (new MessageDialog("Neispravna cijena filma!")).ShowAsync();
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


/*Source="{Binding AzuriranjeFilmovaPoster}"*/
