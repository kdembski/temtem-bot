using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace temtem_bot
{
    //class containing functions related to screen
    class Screen
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindowDC(IntPtr window);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int ReleaseDC(IntPtr window, IntPtr dc);
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern uint GetPixel(IntPtr dc, int x, int y);

        /// <summary>
        /// takes a snapshot of the screen
        /// </summary>
        /// <returns>a snapshot of the screen</returns>
        protected static Bitmap Screenshot()
        {
            // this is where we will store a snapshot of the screen
            Bitmap bmpScreenshot = new Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
            // creates a graphics object so we can draw the screen in the bitmap (bmpScreenshot)
            Graphics g = Graphics.FromImage(bmpScreenshot);
            // copy from screen into the bitmap we created
            g.CopyFromScreen(0, 0, 0, 0, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size);
            return bmpScreenshot;
        }
        /// <summary>
        /// get color of pixel
        /// </summary>
        /// <param name="point">pixel location</param>
        /// <returns>color of pixel</returns>
        protected static Color GetColorAt(Point point)
        {
            int x = point.X;
            int y = point.Y;
            IntPtr desk = GetDesktopWindow();
            IntPtr dc = GetWindowDC(desk);
            int a = (int)GetPixel(dc, x, y);
            ReleaseDC(desk, dc);
            return Color.FromArgb(255, (a >> 0) & 0xff, (a >> 8) & 0xff, (a >> 16) & 0xff);
        }
        /// <summary>
        /// takes part snapshot of the screen
        /// </summary>
        /// <returns>a snapshot of the screen</returns>
        protected static Bitmap Screenshot(int Xmin, int Ymin, int Xmax, int Ymax)
        {
            Rectangle rect = new Rectangle(Xmin, Ymin, Xmax - Xmin, Ymax - Ymin);
            // this is where we will store a snapshot of the screen
            Bitmap bmpScreenshot = new Bitmap(rect.Width, rect.Height);
            // creates a graphics object so we can draw the screen in the bitmap (bmpScreenshot)
            Graphics g = Graphics.FromImage(bmpScreenshot);
            // copy from screen into the bitmap we created
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmpScreenshot.Size);

            return bmpScreenshot;
        }
        /// <summary>
        /// find the location of a bitmap within another bitmap and return if it was successfully found
        /// </summary>
        /// <param name="bmpNeedle">the image we want to find</param>
        /// <param name="bmpHaystack">where we want to search for the image</param>
        /// <param name="location">where we found the image</param>
        /// <returns>if the bmpNeedle was found successfully</returns>
        protected static bool FindBitmap(Bitmap bmpNeedle, Bitmap bmpScreenshot, int outerX, int outerY, int outerXmax, int outerYmax, out Point location)
        {
            Rectangle bitmapPiece = new Rectangle(outerX, outerY, outerXmax - outerX, outerYmax - outerY);
            Bitmap bmpHaystack = new Bitmap(bmpScreenshot.Clone(bitmapPiece, bmpScreenshot.PixelFormat));

            for (outerX = 0; outerX < bmpHaystack.Width; outerX++)
            {
                for (outerY = 0; outerY < bmpHaystack.Height; outerY++)
                {
                    for (int innerX = 0; innerX < bmpNeedle.Width; innerX++)
                    {
                        for (int innerY = 0; innerY < bmpNeedle.Height; innerY++)
                        {
                            Color cNeedle = bmpNeedle.GetPixel(innerX, innerY);
                            Color cHaystack = bmpHaystack.GetPixel(innerX + outerX, innerY + outerY);

                            if (cNeedle.R != cHaystack.R || cNeedle.G != cHaystack.G || cNeedle.B != cHaystack.B)
                            {
                                goto notFound;
                            }
                        }
                    }
                    location = new Point(outerX, outerY);
                    return true;
                notFound:
                    continue;
                }
            }
            location = Point.Empty;
            return false;
        }
    }
}
