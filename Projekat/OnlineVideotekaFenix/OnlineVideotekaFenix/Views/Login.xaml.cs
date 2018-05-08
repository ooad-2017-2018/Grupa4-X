using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OnlineVideotekaFenix.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        static readonly string[] validateProperties = { "Username","Lozinka" };
        public Login()
        {
            this.InitializeComponent();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void RegistracijaClick(Object sender,RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Registracija));
        }

        private void IzlazClick(Object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
        public bool IsValid
        {
            get
            {
                foreach (string property in validateProperties)
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
            string username = "";/* ((TextBox)Cumez.FindName("Username")).get*/
            if (String.IsNullOrWhiteSpace(username)) return "Morate unijeti korisnicko ime!";
            return null;
        }        private string validirajLozinku()
        {
            string lozinka = "";/*                                            */
            if(String.IsNullOrWhiteSpace(lozinka)) return "Morate unijeti lozinku!";
            return null;
        }






    }
}
