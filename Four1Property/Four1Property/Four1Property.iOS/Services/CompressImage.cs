using System;
using System.Drawing;
using Four1Property.iOS.Services;
using Four1Property.Services;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(CompressImage))]

namespace Four1Property.iOS.Services
{
    public class CompressImage : ICopmressImage
    {
        public byte[] ResizeImage(byte[] imageData, float width, float height)
        {
            UIImage originalImage = ImageFromByteArray(imageData);
            var originalHeight = originalImage.Size.Height;
            var originalWidth = originalImage.Size.Width;
            nfloat newHeight = 0;
            nfloat newWidth = 0;

            if (originalHeight > originalWidth)
            {
                newHeight = height;
                nfloat ratio = originalHeight / height;
                newWidth = originalWidth / ratio;
            }
            else
            {
                newWidth = width;
                nfloat ratio = originalWidth / width;
                newHeight = originalHeight / ratio;
            }

            width = (float)newWidth;
            height = (float)newHeight;

            UIGraphics.BeginImageContext(new SizeF(width, height));
            originalImage.Draw(new RectangleF(0, 0, width, height));
            var resizedImage = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            var bytesImagen = resizedImage.AsJPEG().ToArray();
            resizedImage.Dispose();
            return bytesImagen;
        }
        private UIImage ImageFromByteArray(byte[] imageData)
        {
            UIImage image;
            using (var data = NSData.FromArray(imageData))
            {
                image = UIImage.LoadFromData(data);
            }
            return image;
        }
    }
}