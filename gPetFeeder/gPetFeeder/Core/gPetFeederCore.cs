using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace gPetFeeder.Core
{
    // A delegate type for hooking up change notifications.
    public delegate void ChangedEventHandler(EventArgs e);
    public delegate void LogEventHandler(String log);

    public class gPetFeederCore
    {
        public const Int32 ScreenshotWidth = 726;
        public const Int32 ScreenshotHeight = 494;

        public const Int32 ArrowWidth = 40;
        public const Int32 ArrowHeight = 88;
        public const Int32 ArrowLeftLeftX = 4;
        public const Int32 ArrowRightLeftX = 676;
        public const Int32 ArrowTopY = 200;

        public const Int32 FoodWidth = 87;
        public const Int32 FoodHeight = 107;
        public const Int32 FoodLeftX = 78;
        public const Int32 FoodTopY = 334;

        public const Int32 ReloadWidth = 155;
        public const Int32 ReloadHeight = 40;
        public const Int32 ReloadLeftX = 197;
        public const Int32 ReloadTopY = 375;

        public const Int32 AcceptWidth = 140;
        public const Int32 AcceptHeight = 28;
        public const Int32 AcceptLeftX = 514;
        public const Int32 AcceptTopY = 90;

        public const Int32 PlayWidth = 147;
        public const Int32 PlayHeight = 28;
        public const Int32 PlayLeftX = 524;
        public const Int32 PlayTopY = 88;

        public const Int32 PetsWidth = 55;
        public const Int32 PetsHeight = 51;
        public const Int32 PetsLeftX = 0;
        public const Int32 PetsTopY = 65;

        public const Int32 SendWidth = 49;
        public const Int32 SendHeight = 24;
        public const Int32 SendLeftX = 677;
        public const Int32 SendTopY = 205;

        public const Int32 CloseWidth = 25;
        public const Int32 CloseHeight = 25;
        public const Int32 CloseLeftX = 677;
        public const Int32 CloseTopY = 2;

        public const Int32 LevelWidth = 154;
        public const Int32 LevelHeight = 36;
        public const Int32 LevelLeftX = 284;
        public const Int32 LevelTopY = 449;

        // An event that clients can use to be notified whenever the
        // elements of the list change.
        public static event ChangedEventHandler Changed;
        public static event LogEventHandler Log;

        public static Int32 ScreenshotTopLeftX = Int32.MinValue;
        public static Int32 ScreenshotTopLeftY = Int32.MinValue;

        public static Image Screenshot = null;
        public static Image LeftArrow = new Bitmap(ArrowWidth, ArrowHeight);
        public static Image RightArrow = new Bitmap(ArrowWidth, ArrowHeight);
        public static Image FoodSquare = new Bitmap(FoodWidth, FoodHeight);
        public static Image Reload = new Bitmap(ReloadWidth, ReloadHeight);
        public static Image Accept = new Bitmap(AcceptWidth, AcceptHeight);
        public static Image Play = new Bitmap(PlayWidth, PlayHeight);
        public static Image Pets = new Bitmap(PetsWidth, PetsHeight);
        public static Image Send = new Bitmap(SendWidth, SendHeight);
        public static Image Close = new Bitmap(CloseWidth, CloseHeight);
        public static Image Level = new Bitmap(LevelWidth, LevelHeight);

        public static List<Color> ColorList = new List<Color>();

        public static Color ArrowActive = Color.FromArgb(50, 153, 63);
        public static Color ArrowInactive = Color.FromArgb(133, 143, 134);
        public static Color FoodActive = Color.FromArgb(53, 200, 60);
        public static Color FoodInactive = Color.FromArgb(155, 160, 156);
        public static Color ReloadActive = Color.FromArgb(118, 234, 113);
        public static Color AcceptActive = Color.FromArgb(96, 190, 96);
        public static Color PlayActive = Color.FromArgb(6, 148, 217);
        public static Color PetsActive = Color.FromArgb(98, 101, 100);
        public static Color SendActive = Color.FromArgb(79, 106, 162);
        public static Color CloseActive = Color.FromArgb(116, 121, 131);
        public static Color LevelActive = Color.FromArgb(114, 230, 109);

        private static Boolean _Abort = false;

        public static Image GetScreenshot()
        {
            Int32 TopLeftX = ScreenshotTopLeftX == Int32.MinValue ? Screen.PrimaryScreen.Bounds.X : ScreenshotTopLeftX;
            Int32 TopLeftY = ScreenshotTopLeftY == Int32.MinValue ? Screen.PrimaryScreen.Bounds.Y : ScreenshotTopLeftY;
            Image scr = BitmapHelper.GetDesktopScreenshot(TopLeftX, TopLeftY, ScreenshotWidth, ScreenshotHeight);
            SetScreenshots(scr);
            return scr;
        }

        public static void SetScreenshots(Image scr)
        {
            if (Screenshot != null)
            {
                Screenshot = null;
            }
            Screenshot = scr;
            Graphics g = Graphics.FromImage(LeftArrow);
            g.DrawImage(Screenshot, new Rectangle(0, 0, ArrowWidth, ArrowHeight), new Rectangle(ArrowLeftLeftX, ArrowTopY, ArrowWidth, ArrowHeight), GraphicsUnit.Pixel);
            //LeftArrow.Save(@"d:\leftarrow.png", ImageFormat.Png);

            g = Graphics.FromImage(RightArrow);
            g.DrawImage(Screenshot, new Rectangle(0, 0, ArrowWidth, ArrowHeight), new Rectangle(ArrowRightLeftX, ArrowTopY, ArrowWidth, ArrowHeight), GraphicsUnit.Pixel);
            //RightArrow.Save(@"d:\rightarrow.png", ImageFormat.Png);

            g = Graphics.FromImage(FoodSquare);
            g.DrawImage(Screenshot, new Rectangle(0, 0, FoodWidth, FoodHeight), new Rectangle(FoodLeftX, FoodTopY, FoodWidth, FoodHeight), GraphicsUnit.Pixel);
            //FoodSquare.Save(@"d:\foodsquare.png", ImageFormat.Png);

            g = Graphics.FromImage(Reload);
            g.DrawImage(Screenshot, new Rectangle(0, 0, ReloadWidth, ReloadHeight), new Rectangle(ReloadLeftX, ReloadTopY, ReloadWidth, ReloadHeight), GraphicsUnit.Pixel);

            g = Graphics.FromImage(Accept);
            g.DrawImage(Screenshot, new Rectangle(0, 0, AcceptWidth, AcceptHeight), new Rectangle(AcceptLeftX, AcceptTopY, AcceptWidth, AcceptHeight), GraphicsUnit.Pixel);

            g = Graphics.FromImage(Play);
            g.DrawImage(Screenshot, new Rectangle(0, 0, PlayWidth, PlayHeight), new Rectangle(PlayLeftX, PlayTopY, PlayWidth, PlayHeight), GraphicsUnit.Pixel);

            g = Graphics.FromImage(Pets);
            g.DrawImage(Screenshot, new Rectangle(0, 0, PetsWidth, PetsHeight), new Rectangle(PetsLeftX, PetsTopY, PetsWidth, PetsHeight), GraphicsUnit.Pixel);

            g = Graphics.FromImage(Send);
            g.DrawImage(Screenshot, new Rectangle(0, 0, SendWidth, SendHeight), new Rectangle(SendLeftX, SendTopY, SendWidth, SendHeight), GraphicsUnit.Pixel);

            g = Graphics.FromImage(Close);
            g.DrawImage(Screenshot, new Rectangle(0, 0, CloseWidth, CloseHeight), new Rectangle(CloseLeftX, CloseTopY, CloseWidth, CloseHeight), GraphicsUnit.Pixel);

            g = Graphics.FromImage(Level);
            g.DrawImage(Screenshot, new Rectangle(0, 0, LevelWidth, LevelHeight), new Rectangle(LevelLeftX, LevelTopY, LevelWidth, LevelHeight), GraphicsUnit.Pixel);
        }

        private static Int32 GetAverage(Int32 sum, Int32 count)
        {
            return Convert.ToInt32(Convert.ToDouble(sum) / Convert.ToDouble(count));
        }

        public static List<Color> AnalyseScreenshots()
        {
            ColorList.Clear();
            if (Screenshot != null)
            {
                Int32 sumLeftR = 0, sumLeftG = 0, sumLeftB = 0;
                Int32 sumRightR = 0, sumRightG = 0, sumRightB = 0;
                Int32 arrowLeftX = ArrowWidth - 3;
                Int32 arrowRightX = 3;
                for (Int32 i = 0; i < ArrowHeight; i++)
                {
                    // Left Arrow
                    sumLeftR += ((Bitmap)LeftArrow).GetPixel(arrowLeftX, i).R;
                    sumLeftG += ((Bitmap)LeftArrow).GetPixel(arrowLeftX, i).G;
                    sumLeftB += ((Bitmap)LeftArrow).GetPixel(arrowLeftX, i).B;

                    // Right Arrow
                    sumRightR += ((Bitmap)RightArrow).GetPixel(arrowRightX, i).R;
                    sumRightG += ((Bitmap)RightArrow).GetPixel(arrowRightX, i).G;
                    sumRightB += ((Bitmap)RightArrow).GetPixel(arrowRightX, i).B;
                }

                ColorList.Add(Color.FromArgb(GetAverage(sumLeftR, ArrowHeight),
                    GetAverage(sumLeftG, ArrowHeight),
                    GetAverage(sumLeftB, ArrowHeight)));

                ColorList.Add(Color.FromArgb(GetAverage(sumRightR, ArrowHeight),
                    GetAverage(sumRightG, ArrowHeight),
                    GetAverage(sumRightB, ArrowHeight)));

                // Food Square
                Int32 foodStartY = 5;
                Int32 foodEndY = 5 + 40;
                Int32 foodX = FoodWidth - 10;

                Int32 sumFoodR = 0, sumFoodG = 0, sumFoodB = 0;
                for (Int32 i = foodStartY; i <= foodEndY; i++)
                {
                    sumFoodR += ((Bitmap)FoodSquare).GetPixel(foodX, i).R;
                    sumFoodG += ((Bitmap)FoodSquare).GetPixel(foodX, i).G;
                    sumFoodB += ((Bitmap)FoodSquare).GetPixel(foodX, i).B;
                }

                ColorList.Add(Color.FromArgb(GetAverage(sumFoodR, foodEndY - foodStartY + 1),
                    GetAverage(sumFoodG, foodEndY - foodStartY + 1),
                    GetAverage(sumFoodB, foodEndY - foodStartY + 1)));

                // Reload
                Int32 sumReloadR = 0, sumReloadG = 0, sumReloadB = 0;
                for (Int32 i = 0; i < ReloadWidth; i++)
                {
                    sumReloadR += ((Bitmap)Reload).GetPixel(i, 5).R;
                    sumReloadG += ((Bitmap)Reload).GetPixel(i, 5).G;
                    sumReloadB += ((Bitmap)Reload).GetPixel(i, 5).B;
                }

                ColorList.Add(Color.FromArgb(GetAverage(sumReloadR, ReloadWidth),
                    GetAverage(sumReloadG, ReloadWidth),
                    GetAverage(sumReloadB, ReloadWidth)));

                // Accept
                Int32 sumAcceptR = 0, sumAcceptG = 0, sumAcceptB = 0;
                for (Int32 i = 0; i < AcceptWidth; i++)
                {
                    sumAcceptR += ((Bitmap)Accept).GetPixel(i, 5).R;
                    sumAcceptG += ((Bitmap)Accept).GetPixel(i, 5).G;
                    sumAcceptB += ((Bitmap)Accept).GetPixel(i, 5).B;
                }

                ColorList.Add(Color.FromArgb(GetAverage(sumAcceptR, AcceptWidth),
                    GetAverage(sumAcceptG, AcceptWidth),
                    GetAverage(sumAcceptB, AcceptWidth)));

                // Play
                Int32 sumPlayR = 0, sumPlayG = 0, sumPlayB = 0;
                for (Int32 i = 0; i < PlayWidth; i++)
                {
                    sumPlayR += ((Bitmap)Play).GetPixel(i, 5).R;
                    sumPlayG += ((Bitmap)Play).GetPixel(i, 5).G;
                    sumPlayB += ((Bitmap)Play).GetPixel(i, 5).B;
                }

                ColorList.Add(Color.FromArgb(GetAverage(sumPlayR, PlayWidth),
                    GetAverage(sumPlayG, PlayWidth),
                    GetAverage(sumPlayB, PlayWidth)));

                // Pets
                Int32 sumPetsR = 0, sumPetsG = 0, sumPetsB = 0;
                for (Int32 i = 0; i < PetsWidth; i++)
                {
                    sumPetsR += ((Bitmap)Pets).GetPixel(i, PetsWidth - 5).R;
                    sumPetsG += ((Bitmap)Pets).GetPixel(i, PetsWidth - 5).G;
                    sumPetsB += ((Bitmap)Pets).GetPixel(i, PetsWidth - 5).B;
                }

                ColorList.Add(Color.FromArgb(GetAverage(sumPetsR, PetsWidth),
                    GetAverage(sumPetsG, PetsWidth),
                    GetAverage(sumPetsB, PetsWidth)));

                // Send
                Int32 sumSendR = 0, sumSendG = 0, sumSendB = 0;
                for (Int32 i = 0; i < SendWidth; i++)
                {
                    sumSendR += ((Bitmap)Send).GetPixel(i, 5).R;
                    sumSendG += ((Bitmap)Send).GetPixel(i, 5).G;
                    sumSendB += ((Bitmap)Send).GetPixel(i, 5).B;
                }

                ColorList.Add(Color.FromArgb(GetAverage(sumSendR, SendWidth),
                    GetAverage(sumSendG, SendWidth),
                    GetAverage(sumSendB, SendWidth)));

                // Close
                Int32 sumCloseR = 0, sumCloseG = 0, sumCloseB = 0;
                for (Int32 i = 0; i < CloseWidth; i++)
                {
                    sumCloseR += ((Bitmap)Close).GetPixel(i, i).R;
                    sumCloseG += ((Bitmap)Close).GetPixel(i, i).G;
                    sumCloseB += ((Bitmap)Close).GetPixel(i, i).B;
                }

                ColorList.Add(Color.FromArgb(GetAverage(sumCloseR, CloseWidth),
                    GetAverage(sumCloseG, CloseWidth),
                    GetAverage(sumCloseB, CloseWidth)));

                // Level
                Int32 sumLevelR = 0, sumLevelG = 0, sumLevelB = 0;
                for (Int32 i = 0; i < LevelWidth; i++)
                {
                    sumLevelR += ((Bitmap)Level).GetPixel(i, 5).R;
                    sumLevelG += ((Bitmap)Level).GetPixel(i, 5).G;
                    sumLevelB += ((Bitmap)Level).GetPixel(i, 5).B;
                }

                ColorList.Add(Color.FromArgb(GetAverage(sumLevelR, LevelWidth),
                    GetAverage(sumLevelG, LevelWidth),
                    GetAverage(sumLevelB, LevelWidth)));
            }
            return ColorList;
        }

        private static Double getPercentage(Int32 original, Int32 check)
        {
            return Math.Abs(Convert.ToDouble(original - check) / Convert.ToDouble(original) * 100.0);
        }

        private static Boolean CheckColor(Color original, Color check, double percentage)
        {
            return (getPercentage(original.R, check.R) <= percentage
                && getPercentage(original.G, check.G) <= percentage
                && getPercentage(original.B, check.B) <= percentage);
        }

        public static Boolean IsLeftArrowActive()
        {
            if (CheckColor(ArrowActive, ColorList[0], 10.0))
            {
                return true;
            }
            else if (CheckColor(ArrowInactive, ColorList[0], 10.0))
            {
                return false;
            }
            else
            {
                return true;
                //throw new Exception("Color was not recognised!");
            }
        }

        public static Boolean IsRightArrowActive()
        {
            if (CheckColor(ArrowActive, ColorList[1], 10.0))
            {
                return true;
            }
            else if (CheckColor(ArrowInactive, ColorList[1], 10.0))
            {
                return false;
            }
            else
            {
                return true;
                //throw new Exception("Color was not recognised!");
            }
        }

        public static Boolean IsFoodActive()
        {
            if (CheckColor(FoodActive, ColorList[2], 10.0))
            {
                return true;
            }
            else if (CheckColor(FoodInactive, ColorList[2], 10.0))
            {
                return false;
            }
            else
            {
                Debug.WriteLine("Food Color was not recognised!");
                return false;
                //throw new Exception("Color was not recognised!");
            }
        }

        public static Boolean IsReloadActive()
        {
            return CheckColor(ReloadActive, ColorList[3], 10.0);
        }

        public static Boolean IsAcceptActive()
        {
            return CheckColor(AcceptActive, ColorList[4], 10.0);
        }

        public static Boolean IsPlayActive()
        {
            return CheckColor(PlayActive, ColorList[5], 10.0);
        }

        public static Boolean IsPetsActive()
        {
            return CheckColor(PetsActive, ColorList[6], 10.0);
        }

        public static Boolean IsSendActive()
        {
            return CheckColor(SendActive, ColorList[7], 10.0);
        }

        public static Boolean IsCloseActive()
        {
            return CheckColor(CloseActive, ColorList[8], 10.0);
        }

        public static Boolean IsLevelActive()
        {
            return CheckColor(LevelActive, ColorList[9], 10.0);
        }

        public static void ArrowLeftLeftClick()
        {
            Point originalMousePosition = Cursor.Position;
            Int32 arrowX = ScreenshotTopLeftX + ArrowLeftLeftX + (ArrowWidth / 2);
            Int32 arrowY = ScreenshotTopLeftY + ArrowTopY + (ArrowHeight / 2);
            MouseHelper.MouseMove(arrowX, arrowY);
            MouseHelper.MouseLeftClick();
            MouseHelper.MouseMove(originalMousePosition.X, originalMousePosition.Y);
        }

        public static void ArrowRightLeftClick()
        {
            Point originalMousePosition = Cursor.Position;
            Int32 arrowX = ScreenshotTopLeftX + ArrowRightLeftX + (ArrowWidth / 2);
            Int32 arrowY = ScreenshotTopLeftY + ArrowTopY + (ArrowHeight / 2);
            MouseHelper.MouseMove(arrowX, arrowY);
            MouseHelper.MouseLeftClick();
            MouseHelper.MouseMove(originalMousePosition.X, originalMousePosition.Y);
        }

        public static void FoodLeftClick()
        {
            Point originalMousePosition = Cursor.Position;
            Int32 foodX = ScreenshotTopLeftX + FoodLeftX + (FoodWidth / 2);
            Int32 foodY = ScreenshotTopLeftY + FoodTopY + (FoodHeight / 2);
            MouseHelper.MouseMove(foodX, foodY);
            MouseHelper.MouseLeftClick();
            MouseHelper.MouseMove(originalMousePosition.X, originalMousePosition.Y);
        }

        public static void ReloadLeftClick()
        {
            Point originalMousePosition = Cursor.Position;
            Int32 reloadX = ScreenshotTopLeftX + ReloadLeftX + (ReloadWidth / 2);
            Int32 reloadY = ScreenshotTopLeftY + ReloadTopY + (ReloadHeight / 2);
            MouseHelper.MouseMove(reloadX, reloadY);
            MouseHelper.MouseLeftClick();
            MouseHelper.MouseMove(originalMousePosition.X, originalMousePosition.Y);
        }

        public static void AcceptLeftClick()
        {
            Point originalMousePosition = Cursor.Position;
            Int32 AcceptX = ScreenshotTopLeftX + AcceptLeftX + (AcceptWidth / 2);
            Int32 AcceptY = ScreenshotTopLeftY + AcceptTopY + (AcceptHeight / 2);
            MouseHelper.MouseMove(AcceptX, AcceptY);
            MouseHelper.MouseLeftClick();
            MouseHelper.MouseMove(originalMousePosition.X, originalMousePosition.Y);
        }

        public static void PlayLeftClick()
        {
            Point originalMousePosition = Cursor.Position;
            Int32 PlayX = ScreenshotTopLeftX + PlayLeftX + (PlayWidth / 2);
            Int32 PlayY = ScreenshotTopLeftY + PlayTopY + (PlayHeight / 2);
            MouseHelper.MouseMove(PlayX, PlayY);
            MouseHelper.MouseLeftClick();
            MouseHelper.MouseMove(originalMousePosition.X, originalMousePosition.Y);
        }

        public static void PetsLeftClick()
        {
            Point originalMousePosition = Cursor.Position;
            Int32 PetsX = ScreenshotTopLeftX + PetsLeftX + (PetsWidth / 2);
            Int32 PetsY = ScreenshotTopLeftY + PetsTopY + (PetsHeight / 2);
            MouseHelper.MouseMove(PetsX, PetsY);
            MouseHelper.MouseLeftClick();
            MouseHelper.MouseMove(originalMousePosition.X, originalMousePosition.Y);
        }

        public static void SendLeftClick()
        {
            Point originalMousePosition = Cursor.Position;
            Int32 SendX = ScreenshotTopLeftX + SendLeftX + (SendWidth / 2);
            Int32 SendY = ScreenshotTopLeftY + SendTopY + (SendHeight / 2);
            MouseHelper.MouseMove(SendX, SendY);
            MouseHelper.MouseLeftClick();
            MouseHelper.MouseMove(originalMousePosition.X, originalMousePosition.Y);
        }

        public static void CloseLeftClick()
        {
            Point originalMousePosition = Cursor.Position;
            Int32 CloseX = ScreenshotTopLeftX + CloseLeftX + (CloseWidth / 2);
            Int32 CloseY = ScreenshotTopLeftY + CloseTopY + (CloseHeight / 2);
            MouseHelper.MouseMove(CloseX, CloseY);
            MouseHelper.MouseLeftClick();
            MouseHelper.MouseMove(originalMousePosition.X, originalMousePosition.Y);
        }

        public static void LevelLeftClick()
        {
            Point originalMousePosition = Cursor.Position;
            Int32 LevelX = ScreenshotTopLeftX + LevelLeftX + (LevelWidth / 2);
            Int32 LevelY = ScreenshotTopLeftY + LevelTopY + (LevelHeight / 2);
            MouseHelper.MouseMove(LevelX, LevelY);
            MouseHelper.MouseLeftClick();
            MouseHelper.MouseMove(originalMousePosition.X, originalMousePosition.Y);
        }

        public static void Abort()
        {
            _Abort = true;
        }

        public static void Feed()
        {
            OnLog("Started feeding");
            while (!_Abort)
            {
                try
                {
                    // Get the screenshots
                    GetScreenshot();
                    OnLog("Got screenshots");
                    AnalyseScreenshots();
                    OnLog("Analysed screenshots");
                    // Fire the event
                    OnChanged(EventArgs.Empty);
                    if (IsReloadActive())
                    {
                        ReloadLeftClick();
                        OnLog("Clicked reload");
                        Thread.Sleep(15000);
                        continue;
                    }
                    if (IsAcceptActive())
                    {
                        AcceptLeftClick();
                        OnLog("Clicked accept");
                        Thread.Sleep(1000);
                        continue;
                    }
                    if (IsPlayActive())
                    {
                        PlayLeftClick();
                        OnLog("Clicked play");
                        Thread.Sleep(10000);
                        continue;
                    }
                    if (IsPetsActive())
                    {
                        PetsLeftClick();
                        OnLog("Clicked pets");
                        Thread.Sleep(3000);
                        continue;
                    }
                    if (IsSendActive())
                    {
                        SendLeftClick();
                        OnLog("Clicked send");
                        Thread.Sleep(3000);
                        continue;
                    }
                    if (IsCloseActive())
                    {
                        CloseLeftClick();
                        OnLog("Clicked close");
                        Thread.Sleep(2000);
                        continue;
                    }
                    if (IsLevelActive())
                    {
                        LevelLeftClick();
                        OnLog("Clicked level");
                        Thread.Sleep(2000);
                        continue;
                    }
                    if (IsFoodActive())
                    {
                        FoodLeftClick();
                        OnLog("Clicked food");
                        Thread.Sleep(3000);
                        continue;
                    }
                    if (IsRightArrowActive())
                    {
                        ArrowRightLeftClick();
                        OnLog("Clicked right arrow");
                        Thread.Sleep(5000);
                        continue;
                    }
                    if (IsLeftArrowActive())
                    {
                        ArrowLeftLeftClick();
                        OnLog("Clicked left arrow");
                        Thread.Sleep(5000);
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    OnLog("Error! " + ex.Message);
                    continue;
                }
            }
            OnLog("Stopped feeding");
            _Abort = false;
        }

        // Invoke the Changed event; called whenever list changes
        public static void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(e);
        }

        public static void OnLog(String txt)
        {
            if (Log != null)
                Log(String.Format("{0} {1}", DateTime.Now.ToString("[yyyy-MM-dd][hh:mm.ss fff]"), txt));
        }

        public static String GetLog()
        {
            return ColorList[0].ToString() + "\r\n" +
                        ColorList[1].ToString() + "\r\n" +
                        ColorList[2].ToString() + "\r\n" +
                        ColorList[3].ToString() + "\r\n" +
                        ColorList[4].ToString() + "\r\n" +
                        ColorList[5].ToString() + "\r\n" +
                        ColorList[6].ToString() + "\r\n" +
                        ColorList[7].ToString() + "\r\n" +
                        ColorList[8].ToString() + "\r\n" +
                        ColorList[9].ToString() + 
                        "\r\nLeft Arrow Active: " + IsLeftArrowActive() + 
                        "\r\nRight Arrow Active: " + IsRightArrowActive() + 
                        "\r\nFood Active: " + IsFoodActive() + 
                        "\r\nReload Active: " + IsReloadActive() + 
                        "\r\nAccept Active: " + IsAcceptActive() + 
                        "\r\nPlay Active: " + IsPlayActive() + 
                        "\r\nPets Active: " + IsPetsActive() + 
                        "\r\nSend Active: " + IsSendActive() + 
                        "\r\nClose Active: " + IsCloseActive() +
                        "\r\nLevel Active: " + IsLevelActive();
        }
    }
}
