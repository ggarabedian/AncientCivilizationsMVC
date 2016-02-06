namespace AncientCivilizations.Web.Common.Extensions
{
    using System;
    using System.IO;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Web;

    public static class AvatarImageEditor
    {
        public static byte[] ResizeImage(HttpPostedFileBase image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.InputStream.CopyTo(ms);
                using (MemoryStream resizedMs = (MemoryStream)ResizeImageToStream(ms))
                {
                    byte[] resizedImage = resizedMs.GetBuffer();
                    return resizedImage;
                }
            }
        }

        private static Stream ResizeImageToStream(Stream stream)
        {
            int height = 100;
            int width = 100;

            Image originalImage = Image.FromStream(stream);

            double ratio = Math.Min(originalImage.Width, originalImage.Height) /
                           (double)Math.Max(originalImage.Width, originalImage.Height);

            if (originalImage.Width > originalImage.Height)
            {
                height = Convert.ToInt32(height * ratio);
            }
            else
            {
                width = Convert.ToInt32(width * ratio);
            }

            var scaledImage = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(scaledImage))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, width, height);

                var ms = new MemoryStream();
                scaledImage.Save(ms, ImageFormat.Png);
                ms.Position = 0;
                return ms;
            }
        }
    }
}
