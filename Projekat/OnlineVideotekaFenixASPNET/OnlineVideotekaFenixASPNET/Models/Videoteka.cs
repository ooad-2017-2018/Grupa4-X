using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVideotekaFenixASPNET.Models
{
    public class Videoteka
    {
        public int Id { get; set; }
        public List<Korisnik> ListaKorisnika { get; set; }
        public List<Film> ListaFilmova { get; set; }
        public List<Administrator> ListaAdministratora { get; set; }
    }
}

/*
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);
            StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (photo == null)
                return;

            IRandomAccessStream stream = await photo.OpenAsync(FileAccessMode.Read);
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
            SoftwareBitmap softwareBitmap = await decoder.GetSoftwareBitmapAsync();

            SoftwareBitmap softwareBitmapBGR8 = SoftwareBitmap.Convert(softwareBitmap,
                BitmapPixelFormat.Bgra8,
                BitmapAlphaMode.Premultiplied);

            SoftwareBitmapSource bitmapSource = new SoftwareBitmapSource();
            await bitmapSource.SetBitmapAsync(softwareBitmapBGR8);

            ((Image)slika).Source = bitmapSource;
*/
