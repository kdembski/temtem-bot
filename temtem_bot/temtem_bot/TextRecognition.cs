using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronOcr;

namespace temtem_bot
{
    class TextRecognition : Screen
    {
        /// <summary>
        /// function recognize text from image
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static string Recognize(int Xmin, int Ymin, int Xmax, int Ymax)
        {
            Bitmap bmpScreenshot = Screenshot(Xmin, Ymin, Xmax, Ymax);
            bmpScreenshot = ExtractText(bmpScreenshot);

            var Ocr = new AutoOcr();
            string outString = Ocr.Read(bmpScreenshot).ToString();
            outString = outString.ToLower();
            return outString;
        }
        /// <summary>
        /// extract only black pixels from image
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        private static Bitmap ExtractBlack(Bitmap bitmap)
        {
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    //get pixel value
                    Color c = bitmap.GetPixel(i, j);
                    //check if pixel is not black
                    if (!(c.R == 0 && c.G == 0 && c.B == 0))
                    {
                        //if not set it color to white
                        bitmap.SetPixel(i, j, Color.White);
                    }
                }
            }
            return bitmap;
        }
        private static Bitmap ExtractText(Bitmap bitmap)
        {
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    //get pixel value
                    Color c = bitmap.GetPixel(i, j);
                    //check if pixel is not black
                    if (c.R == c.G && c.R == c.B && c.R > 140 && c.G > 140 && c.B > 140)
                    {
                        bitmap.SetPixel(i, j, Color.Black);
                    }
                    else
                    {
                        bitmap.SetPixel(i, j, Color.White);
                    }
                }
            }
            return bitmap;
        }
        /// <summary>
        /// makes negative of bitmap
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        private static Bitmap Negative(Bitmap bitmap)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    //get pixel value
                    Color p = bitmap.GetPixel(x, y);
                    //extract ARGB value from p
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;
                    //find negative value
                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;
                    //set new ARGB value in pixel
                    bitmap.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            return bitmap;
        }
    }
}
