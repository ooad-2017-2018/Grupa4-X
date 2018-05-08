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
using System.Security;


namespace OnlineVideotekaFenix.ViewModels
{
    class MainPageViewModel
    {
        #region Icommande i get i set

        public ICommand LoginClick { get; set; }
        public ICommand RegistracijaClick { get; set; }
        public ICommand IzlazClick { get; set; }

        #endregion

        #region Atributi
        public string LoginUsername { get; set; }
        public string LoginPassword { get; set; }

        #endregion

        public MainPageViewModel()
        {
            RegistracijaClick = new RelayCommand<Object>(registracijaKorisnika, potvrdi);
            LoginClick = new RelayCommand<Object>(loginKorisnika, potvrdi);
            IzlazClick = new RelayCommand<Object>(izlazKorisnika, potvrdi);
            /*


            this.Sistem = new GlasackiSistem();
            //this.Sistem = Parent.Sistem;

            ListaKandidata = Sistem.KandidatiD;
            ListaNovosti = Sistem.Novosti;
            NoviKandidat = new Kandidat();
            NovaNovost = new Novost();
            NoviKandidat.DatRodjenja = DateTime.Now;
            Login = new RelayCommand<object>(registrujAdmina, potvrdi);
            DodavanjeKandidata = new RelayCommand<object>(dodajKandidata, boolDodaj);
            DodavanjeNovosti = new RelayCommand<object>(dodajNovost, boolDodaj);
            BrisanjeKandidata = new RelayCommand<object>(obrisiKandidata, boolDodaj);
            BrisanjeNovosti = new RelayCommand<object>(obrisiNovost, boolDodaj);
            IzmjenaKandidata = new RelayCommand<object>(promjenaKandidata, boolDodaj);
            IzmjenaNovosti = new RelayCommand<object>(promjenaNovosti, boolDodaj);
            Odjava = new RelayCommand<object>(odjava, boolDodaj);
            PretragaNovosti = new RelayCommand<object>(nadjiNovosti, boolDodaj);
            PretragaKandidata = new RelayCommand<object>(nadjiKandidate, boolDodaj);
            UcitajSliku = new RelayCommand<object>(dodajSliku, boolDodaj);
            NaziviStranki = new ObservableCollection<string>();
            NaziviStranki.Add("OOAD");
            NaziviStranki.Add("Proba");
            /*
            for (int i=0; i<Sistem.Stranke.Count; i++)
            {
                NaziviStranki.Add(Sistem.Stranke[i].Naziv);
            }
            */
            //NoviKandidat.ErrorsChanged += Vm_ErrorsChanged;
        }

        public bool potvrdi(Object o)
        {
            /*
            string password = new System.Net.NetworkCredential(string.Empty, AdminSifra).Password;
            
            if (AdminIme.Equals("admin") && password.Equals("mrviceljubavi"))
            {
                return true;
            }
            var dialog = new MessageDialog("Neispravni pristupni podaci!");
            */

            //stalno vraca true jer passwordBox pretvara string u SecureString, metode koje sam nasao na Internetu za pretvaranje
            //su za starije verzije VS
            return true;
        }

        public bool boolDodaj(Object o)
        {
            return true;
        }

        public void registracijaKorisnika(Object o)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(Registracija));
        
        }
        public void loginKorisnika(Object o)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(Login));

        }

        public void izlazKorisnika(Object o)
        {
            Application.Current.Exit();
        }

    }
}
