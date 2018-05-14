using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using OnlineVideotekaFenix.ViewModels;
using OnlineVideotekaFenix.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OnlineVideotekaFenix.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AzuriranjeFilmova : Page
    {
        List<Film> filmoviList;
        bool filmOK = false;
        List<Korisnik> korisniciList;
        bool profilOK = false;

        public AzuriranjeFilmova()
        {
            filmoviList = new List<Film>();
            this.InitializeComponent();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;
        }
        MainPageViewModel model;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            model = (MainPageViewModel)e.Parameter;
            DataContext = model;
        }
        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }
        private void filmTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!filmOK)
            {
                filmoviList = ((List<Film>)(FilmoviListView.ItemsSource));
                filmOK = true;
            }
            string textBoxNaziv = pretragaFilmaTextBox.Text.ToLower();
            FilmoviListView.ItemsSource = null;
            FilmoviListView.Items.Clear();
            foreach (Film f in filmoviList)
            {
                string nazivFilmaTemp = f.NazivFilma.ToLower();
                if (nazivFilmaTemp.Contains(textBoxNaziv))
                    FilmoviListView.Items.Add(f);
            }
        }
        private void profilTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!profilOK)
            {
                korisniciList = ((List<Korisnik>)(KorisniciListView.ItemsSource));
                profilOK = true;
            }
            string textBoxUsername = pretragaProfilaTextBox.Text.ToLower();
            KorisniciListView.ItemsSource = null;
            KorisniciListView.Items.Clear();
            foreach (Korisnik k in korisniciList)
            {
                string username = k.Username.ToLower();
                if (username.Contains(textBoxUsername))
                    FilmoviListView.Items.Add(k);
            }
        }


    }
}
