using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using gPetFeeder.Core;
using System.Threading;

namespace gPetFeeder
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            btnAbort.Enabled = false;
            gPetFeederCore.Changed += gPetFeederCore_Changed;
            gPetFeederCore.Log += gPetFeederCore_Log;

            if (File.Exists("gPetFeeder.ini"))
            {
                Int32 newX = 0, newY = 0;
                using (StreamReader sr = new StreamReader("gPetFeeder.ini"))
                {
                    while (!sr.EndOfStream)
                    {
                        String line = sr.ReadLine();
                        if (line.StartsWith("X:"))
                        {
                            newX = Int32.Parse(line.Substring(2).Trim());
                        }
                        else if (line.StartsWith("Y:"))
                        {
                            newY = Int32.Parse(line.Substring(2).Trim());
                        }
                    }
                }
                this.Location = new Point(newX, newY);
            }

            chkAlwaysOnTop.Checked = true;
        }

        private void SetScreenshot()
        {
            gPetFeederCore.ScreenshotTopLeftX = this.Location.X - gPetFeederCore.ScreenshotWidth;
            gPetFeederCore.ScreenshotTopLeftY = this.Location.Y;
            Image scr = gPetFeederCore.GetScreenshot();
            picScreenshot.Image = scr;
            picLeftArrow.Image = gPetFeederCore.LeftArrow;
            picRightArrow.Image = gPetFeederCore.RightArrow;
            picFoodSquare.Image = gPetFeederCore.FoodSquare;
            List<Color> colorList = gPetFeederCore.AnalyseScreenshots();
            picAvgLeftArrow.BackColor = colorList[0];
            picAvgRightArrow.BackColor = colorList[1];
            picAvgFoodSquare.BackColor = colorList[2];
            txtColorLog.Text = string.Empty;
            txtColorLog.Text = colorList[0].ToString() + "\r\n" + colorList[1].ToString() + "\r\n" + colorList[2].ToString() + "\r\nLeft Arrow Active: " + gPetFeederCore.IsLeftArrowActive() + "\r\nRight Arrow Active: " + gPetFeederCore.IsRightArrowActive() + "\r\nFood Active: " + gPetFeederCore.IsFoodActive();
        }

        private void btnGetScreenshot_Click(object sender, EventArgs e)
        {
            try
            {
                SetScreenshot();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDirections_Click(object sender, EventArgs e)
        {
            Int32 moveX = 0, moveY = 0;
            switch (((Button)sender).Name)
            {
                case "btnUp":
                    moveY = -1;
                    break;
                case "btnDown":
                    moveY = 1;
                    break;
                case "btnLeft":
                    moveX = -1;
                    break;
                case "btnRight":
                    moveX = 1;
                    break;
                default:
                    break;
            }
            this.Location = new Point(this.Location.X + moveX, this.Location.Y + moveY);
            SetScreenshot();
        }

        private void chkAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = chkAlwaysOnTop.Checked;
        }

        private void btnSaveScreenshot_Click(object sender, EventArgs e)
        {
            if (picScreenshot.Image != null)
            {
                if (picScreenshot.Image != picScreenshot.ErrorImage)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Title = "Save screenshot";
                    sfd.Filter = "*.png|*.png";
                    sfd.FileName = "screenshot_000.png";
                    if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        picScreenshot.Image.Save(sfd.FileName, ImageFormat.Png);
                        MessageBox.Show("The screenshot was saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void frmMain_Move(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                using (StreamWriter sw = new StreamWriter("gPetFeeder.ini"))
                {
                    sw.WriteLine(String.Format("X:{0}", this.Location.X));
                    sw.Write(String.Format("Y:{0}", this.Location.Y));
                }
            }
        }

        private void btnFeed_Click(object sender, EventArgs e)
        {
            try
            {
                gPetFeederCore.ScreenshotTopLeftX = this.Location.X - gPetFeederCore.ScreenshotWidth;
                gPetFeederCore.ScreenshotTopLeftY = this.Location.Y;

                ThreadStart ts = new ThreadStart(gPetFeederCore.Feed);
                Thread t = new Thread(ts);

                btnFeed.Enabled = false;
                btnAbort.Enabled = true;
                pnlMoveForm.Enabled = false;

                t.Start();
                while (t.ThreadState != System.Threading.ThreadState.Stopped)
                {
                    Application.DoEvents();
                }

                btnFeed.Enabled = true;
                btnAbort.Enabled = false;
                pnlMoveForm.Enabled = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                btnFeed.Enabled = true;
                btnAbort.Enabled = false;
                pnlMoveForm.Enabled = true;
            }
        }

        public delegate void ChangeTextDelegate(String s);

        public void ChangeText(String txt)
        {
            txtColorLog.Text = txt;
        }

        public void AddLog(String txt)
        {
            if (txtFeedLog.Text.Length + txt.Length > txtFeedLog.MaxLength)
            {
                txtFeedLog.Text = String.Empty;
            }
            txtFeedLog.Text += txt + "\r\n";
            txtFeedLog.SelectionStart = txtFeedLog.Text.Length - 1;
            txtFeedLog.ScrollToCaret();
        }

        private void gPetFeederCore_Changed(EventArgs e)
        {
            try
            {
                picScreenshot.Image = gPetFeederCore.Screenshot;
                picLeftArrow.Image = gPetFeederCore.LeftArrow;
                picRightArrow.Image = gPetFeederCore.RightArrow;
                picFoodSquare.Image = gPetFeederCore.FoodSquare;
                List<Color> colorList = gPetFeederCore.ColorList;
                picAvgLeftArrow.BackColor = colorList[0];
                picAvgRightArrow.BackColor = colorList[1];
                picAvgFoodSquare.BackColor = colorList[2];
                String s = gPetFeederCore.GetLog();
                txtColorLog.BeginInvoke(new ChangeTextDelegate(ChangeText), new object[] { s });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void gPetFeederCore_Log(string log)
        {
            txtFeedLog.BeginInvoke(new ChangeTextDelegate(AddLog), new object[] { log });
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                gPetFeederCore.Abort();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void btnLoadScreenshot_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Select screenshot...";
                ofd.Filter = "*.png|*.png";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Image scr = Image.FromFile(ofd.FileName);
                    gPetFeederCore.SetScreenshots(scr);
                    picScreenshot.Image = scr;
                    picLeftArrow.Image = gPetFeederCore.LeftArrow;
                    picRightArrow.Image = gPetFeederCore.RightArrow;
                    picFoodSquare.Image = gPetFeederCore.FoodSquare;
                    List<Color> colorList = gPetFeederCore.AnalyseScreenshots();
                    picAvgLeftArrow.BackColor = colorList[0];
                    picAvgRightArrow.BackColor = colorList[1];
                    picAvgFoodSquare.BackColor = colorList[2];
                    txtColorLog.Text = string.Empty;
                    txtColorLog.Text = gPetFeederCore.GetLog();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

    }
}
