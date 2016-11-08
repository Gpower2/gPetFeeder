using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gPetFeeder.Core
{
    public class BitmapHelper
    {
        public static Image GetDesktopScreenshot(Int32 argTopLeftX = Int32.MinValue, Int32 argTopLeftY = Int32.MinValue, Int32 argWidth = Int32.MinValue, Int32 argHeight = Int32.MinValue)
        {
            Int32 TopLeftX = argTopLeftX == Int32.MinValue ? Screen.PrimaryScreen.Bounds.X : argTopLeftX;
            Int32 TopLeftY = argTopLeftY == Int32.MinValue ? Screen.PrimaryScreen.Bounds.Y : argTopLeftY;
            Int32 Width = argWidth == Int32.MinValue ? Screen.PrimaryScreen.Bounds.Width : argWidth;
            Int32 Height = argHeight == Int32.MinValue ? Screen.PrimaryScreen.Bounds.Height : argHeight;

            // Create the screenshot Bitmap
            Image bmpScreenshot = new Bitmap(Width, Height);

            // Create a graphics object from the bitmap.
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            // Take the screenshot acording to arguments
            gfxScreenshot.CopyFromScreen(TopLeftX, TopLeftY, 0, 0, new Size(Width, Height),
                                        CopyPixelOperation.SourceCopy);

            return bmpScreenshot;
        }

    }
}
