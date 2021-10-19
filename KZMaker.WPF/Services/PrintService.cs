using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KZMaker.WPF.Services
{
    public class PrintService
    {
        public void test(Bitmap bitmap)
        {
            var visual = new DrawingVisual();

            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                using (var dc = visual.RenderOpen())
                {
                    dc.DrawImage(bitmapImage, new System.Windows.Rect { Width = bitmapImage.Width, Height = bitmapImage.Height});
                };
            }

            
            PrintDialog printDialog = new PrintDialog();
            printDialog.PrintVisual(visual, "Karta zbiórki");
        }
    }
}
