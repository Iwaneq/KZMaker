using KZMaker.Core.Services;
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
    public class PrintService : IPrintService
    {
        public void PrintBitmap(Bitmap bitmap)
        {
            var visual = new DrawingVisual();
            PrintDialog printDialog = new PrintDialog();

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
                    dc.DrawImage(bitmapImage, new System.Windows.Rect { Width = printDialog.PrintableAreaWidth, Height = printDialog.PrintableAreaHeight });
                };
            }

            
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(visual, "Karta zbiórki");
            }
            
        }
    }
}
