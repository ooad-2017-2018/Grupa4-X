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


namespace OnlineVideotekaFenix.ViewModels
{
    class MainPageViewModel
    {
        #region Icommands

        public ICommand LoginOtvori { get; set; }
        public ICommand LoginClick { get; set; }
        public ICommand RegistracijaClick { get; set; }
        public ICommand IzlazClick { get; set; }
        public ICommand DodajPosterClick { get; set; }
        public ICommand OtvoriKameruClick { get; set; }
        public ICommand AzuriranjeFilmovaClick { get; set; }

        





        #endregion

        #region Atributi
        public Videoteka Videoteka { get; set; }
        public string LoginUsername { get; set; }
        public string LoginPassword { get; set; }
        public static byte[] dodajPoster = null;

        #endregion

        public MainPageViewModel()
        {
            RegistracijaClick = new RelayCommand<Object>(RegistracijaKorisnika, potvrdi);
            LoginClick = new RelayCommand<Object>(LoginKorisnika, potvrdi);
            LoginOtvori = new RelayCommand<Object>(LoginKorisnikaOtvori, potvrdi);
            IzlazClick = new RelayCommand<Object>(IzlazKorisnika, potvrdi);
            OtvoriKameruClick = new RelayCommand<Object>(OtvoriKameru, boolDodaj);
            AzuriranjeFilmovaClick = new RelayCommand<Object>(AzuriranjeFilmovaOtvori, potvrdi);
            DodajPosterClick = new RelayCommand<Object>(DodajPoster, boolDodaj);


            


        }

        public bool potvrdi(Object o)
        {
           return true;
        }

        public bool boolDodaj(Object o)
        {
            return true;
        }

        public void RegistracijaKorisnika(Object o)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(Registracija));
        
        }
        public void LoginKorisnika(Object o)
        {
           /* var frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(Login));*/

        }

        public void IzlazKorisnika(Object o)
        {
            Application.Current.Exit();
        }

        public void DodajPoster(Object o)
        {

        }

        public void LoginKorisnikaOtvori(Object o)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(Login));

        }
        /*public async void DodajPoster(System.Object sender, RoutedEventArgs e)
        {
            if (Views.KorisnickeKontrole.ImageAndButton != null)
                uploadSlika = UserControls.ImageAndButton.uploadSlika;
        }*/
        public void OtvoriKameru(Object o)
        {
            // Pokrece se web kamera da bi se korisnik uslikao
            // Vanjski uredjaj jos nije implementiran
        }
        
        public void AzuriranjeFilmovaOtvori(Object o)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(AzuriranjeFilmova));
        }


    }
}
