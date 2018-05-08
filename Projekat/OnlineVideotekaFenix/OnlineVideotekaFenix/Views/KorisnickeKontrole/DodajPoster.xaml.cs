using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace OnlineVideotekaFenix.Views.KorisnickeKontrole
{
    public sealed partial class DodajPoster : UserControl
    {
        public DodajPoster()
        {
            this.InitializeComponent();
        }
        
        private async void DodajPosterClick(System.Object sender, RoutedEventArgs e)
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
                poster.Source = varimage;
            }
            else
            {
                 //
            }
        }
        
    }
}
