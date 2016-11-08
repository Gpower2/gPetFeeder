namespace gPetFeeder
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picScreenshot = new System.Windows.Forms.PictureBox();
            this.btnGetScreenshot = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.pnlMoveForm = new System.Windows.Forms.Panel();
            this.btnLoadScreenshot = new System.Windows.Forms.Button();
            this.chkAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.btnSaveScreenshot = new System.Windows.Forms.Button();
            this.btnFeed = new System.Windows.Forms.Button();
            this.picLeftArrow = new System.Windows.Forms.PictureBox();
            this.picRightArrow = new System.Windows.Forms.PictureBox();
            this.picFoodSquare = new System.Windows.Forms.PictureBox();
            this.picAvgFoodSquare = new System.Windows.Forms.PictureBox();
            this.picAvgLeftArrow = new System.Windows.Forms.PictureBox();
            this.picAvgRightArrow = new System.Windows.Forms.PictureBox();
            this.txtColorLog = new System.Windows.Forms.TextBox();
            this.btnAbort = new System.Windows.Forms.Button();
            this.txtFeedLog = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picScreenshot)).BeginInit();
            this.pnlMoveForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLeftArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRightArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoodSquare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvgFoodSquare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvgLeftArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvgRightArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // picScreenshot
            // 
            this.picScreenshot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picScreenshot.Location = new System.Drawing.Point(7, 5);
            this.picScreenshot.Name = "picScreenshot";
            this.picScreenshot.Size = new System.Drawing.Size(267, 219);
            this.picScreenshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picScreenshot.TabIndex = 0;
            this.picScreenshot.TabStop = false;
            // 
            // btnGetScreenshot
            // 
            this.btnGetScreenshot.Location = new System.Drawing.Point(19, 23);
            this.btnGetScreenshot.Name = "btnGetScreenshot";
            this.btnGetScreenshot.Size = new System.Drawing.Size(60, 30);
            this.btnGetScreenshot.TabIndex = 1;
            this.btnGetScreenshot.Text = "Get Scr";
            this.btnGetScreenshot.UseVisualStyleBackColor = true;
            this.btnGetScreenshot.Click += new System.EventHandler(this.btnGetScreenshot_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnUp.Location = new System.Drawing.Point(67, 89);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(25, 25);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "↑";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnDirections_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnLeft.Location = new System.Drawing.Point(36, 103);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(25, 25);
            this.btnLeft.TabIndex = 3;
            this.btnLeft.Text = "←";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnDirections_Click);
            // 
            // btnRight
            // 
            this.btnRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnRight.Location = new System.Drawing.Point(98, 103);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(25, 25);
            this.btnRight.TabIndex = 4;
            this.btnRight.Text = "→";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnDirections_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnDown.Location = new System.Drawing.Point(67, 120);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(25, 25);
            this.btnDown.TabIndex = 5;
            this.btnDown.Text = "↓";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDirections_Click);
            // 
            // pnlMoveForm
            // 
            this.pnlMoveForm.Controls.Add(this.btnLoadScreenshot);
            this.pnlMoveForm.Controls.Add(this.btnUp);
            this.pnlMoveForm.Controls.Add(this.btnDown);
            this.pnlMoveForm.Controls.Add(this.btnLeft);
            this.pnlMoveForm.Controls.Add(this.btnRight);
            this.pnlMoveForm.Controls.Add(this.chkAlwaysOnTop);
            this.pnlMoveForm.Controls.Add(this.btnGetScreenshot);
            this.pnlMoveForm.Controls.Add(this.btnSaveScreenshot);
            this.pnlMoveForm.Location = new System.Drawing.Point(277, 5);
            this.pnlMoveForm.Name = "pnlMoveForm";
            this.pnlMoveForm.Size = new System.Drawing.Size(151, 147);
            this.pnlMoveForm.TabIndex = 6;
            // 
            // btnLoadScreenshot
            // 
            this.btnLoadScreenshot.Location = new System.Drawing.Point(19, 56);
            this.btnLoadScreenshot.Name = "btnLoadScreenshot";
            this.btnLoadScreenshot.Size = new System.Drawing.Size(60, 30);
            this.btnLoadScreenshot.TabIndex = 9;
            this.btnLoadScreenshot.Text = "Load Scr";
            this.btnLoadScreenshot.UseVisualStyleBackColor = true;
            this.btnLoadScreenshot.Click += new System.EventHandler(this.btnLoadScreenshot_Click);
            // 
            // chkAlwaysOnTop
            // 
            this.chkAlwaysOnTop.AutoSize = true;
            this.chkAlwaysOnTop.Location = new System.Drawing.Point(22, 3);
            this.chkAlwaysOnTop.Name = "chkAlwaysOnTop";
            this.chkAlwaysOnTop.Size = new System.Drawing.Size(101, 17);
            this.chkAlwaysOnTop.TabIndex = 7;
            this.chkAlwaysOnTop.Text = "Always On Top";
            this.chkAlwaysOnTop.UseVisualStyleBackColor = true;
            this.chkAlwaysOnTop.CheckedChanged += new System.EventHandler(this.chkAlwaysOnTop_CheckedChanged);
            // 
            // btnSaveScreenshot
            // 
            this.btnSaveScreenshot.Location = new System.Drawing.Point(81, 23);
            this.btnSaveScreenshot.Name = "btnSaveScreenshot";
            this.btnSaveScreenshot.Size = new System.Drawing.Size(60, 30);
            this.btnSaveScreenshot.TabIndex = 8;
            this.btnSaveScreenshot.Text = "Save Scr";
            this.btnSaveScreenshot.UseVisualStyleBackColor = true;
            this.btnSaveScreenshot.Click += new System.EventHandler(this.btnSaveScreenshot_Click);
            // 
            // btnFeed
            // 
            this.btnFeed.Location = new System.Drawing.Point(277, 157);
            this.btnFeed.Name = "btnFeed";
            this.btnFeed.Size = new System.Drawing.Size(151, 30);
            this.btnFeed.TabIndex = 9;
            this.btnFeed.Text = "Feed!";
            this.btnFeed.UseVisualStyleBackColor = true;
            this.btnFeed.Click += new System.EventHandler(this.btnFeed_Click);
            // 
            // picLeftArrow
            // 
            this.picLeftArrow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLeftArrow.Location = new System.Drawing.Point(7, 230);
            this.picLeftArrow.Name = "picLeftArrow";
            this.picLeftArrow.Size = new System.Drawing.Size(40, 88);
            this.picLeftArrow.TabIndex = 10;
            this.picLeftArrow.TabStop = false;
            // 
            // picRightArrow
            // 
            this.picRightArrow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picRightArrow.Location = new System.Drawing.Point(54, 230);
            this.picRightArrow.Name = "picRightArrow";
            this.picRightArrow.Size = new System.Drawing.Size(40, 88);
            this.picRightArrow.TabIndex = 11;
            this.picRightArrow.TabStop = false;
            // 
            // picFoodSquare
            // 
            this.picFoodSquare.BackColor = System.Drawing.SystemColors.Control;
            this.picFoodSquare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFoodSquare.Location = new System.Drawing.Point(104, 230);
            this.picFoodSquare.Name = "picFoodSquare";
            this.picFoodSquare.Size = new System.Drawing.Size(87, 107);
            this.picFoodSquare.TabIndex = 12;
            this.picFoodSquare.TabStop = false;
            // 
            // picAvgFoodSquare
            // 
            this.picAvgFoodSquare.Location = new System.Drawing.Point(104, 343);
            this.picAvgFoodSquare.Name = "picAvgFoodSquare";
            this.picAvgFoodSquare.Size = new System.Drawing.Size(87, 25);
            this.picAvgFoodSquare.TabIndex = 13;
            this.picAvgFoodSquare.TabStop = false;
            // 
            // picAvgLeftArrow
            // 
            this.picAvgLeftArrow.Location = new System.Drawing.Point(7, 343);
            this.picAvgLeftArrow.Name = "picAvgLeftArrow";
            this.picAvgLeftArrow.Size = new System.Drawing.Size(40, 25);
            this.picAvgLeftArrow.TabIndex = 14;
            this.picAvgLeftArrow.TabStop = false;
            // 
            // picAvgRightArrow
            // 
            this.picAvgRightArrow.Location = new System.Drawing.Point(53, 343);
            this.picAvgRightArrow.Name = "picAvgRightArrow";
            this.picAvgRightArrow.Size = new System.Drawing.Size(40, 25);
            this.picAvgRightArrow.TabIndex = 15;
            this.picAvgRightArrow.TabStop = false;
            // 
            // txtColorLog
            // 
            this.txtColorLog.Location = new System.Drawing.Point(201, 230);
            this.txtColorLog.Multiline = true;
            this.txtColorLog.Name = "txtColorLog";
            this.txtColorLog.ReadOnly = true;
            this.txtColorLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtColorLog.Size = new System.Drawing.Size(227, 138);
            this.txtColorLog.TabIndex = 16;
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(277, 193);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(151, 30);
            this.btnAbort.TabIndex = 17;
            this.btnAbort.Text = "Abort!";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // txtFeedLog
            // 
            this.txtFeedLog.Location = new System.Drawing.Point(7, 374);
            this.txtFeedLog.Multiline = true;
            this.txtFeedLog.Name = "txtFeedLog";
            this.txtFeedLog.ReadOnly = true;
            this.txtFeedLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFeedLog.Size = new System.Drawing.Size(421, 82);
            this.txtFeedLog.TabIndex = 18;
            this.txtFeedLog.WordWrap = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(434, 461);
            this.Controls.Add(this.txtFeedLog);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.txtColorLog);
            this.Controls.Add(this.picAvgRightArrow);
            this.Controls.Add(this.picAvgLeftArrow);
            this.Controls.Add(this.picAvgFoodSquare);
            this.Controls.Add(this.picFoodSquare);
            this.Controls.Add(this.picRightArrow);
            this.Controls.Add(this.picLeftArrow);
            this.Controls.Add(this.btnFeed);
            this.Controls.Add(this.pnlMoveForm);
            this.Controls.Add(this.picScreenshot);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "gPetFeeder";
            this.Move += new System.EventHandler(this.frmMain_Move);
            ((System.ComponentModel.ISupportInitialize)(this.picScreenshot)).EndInit();
            this.pnlMoveForm.ResumeLayout(false);
            this.pnlMoveForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLeftArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRightArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoodSquare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvgFoodSquare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvgLeftArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvgRightArrow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picScreenshot;
        private System.Windows.Forms.Button btnGetScreenshot;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Panel pnlMoveForm;
        private System.Windows.Forms.CheckBox chkAlwaysOnTop;
        private System.Windows.Forms.Button btnSaveScreenshot;
        private System.Windows.Forms.Button btnFeed;
        private System.Windows.Forms.PictureBox picLeftArrow;
        private System.Windows.Forms.PictureBox picRightArrow;
        private System.Windows.Forms.PictureBox picFoodSquare;
        private System.Windows.Forms.PictureBox picAvgFoodSquare;
        private System.Windows.Forms.PictureBox picAvgLeftArrow;
        private System.Windows.Forms.PictureBox picAvgRightArrow;
        private System.Windows.Forms.TextBox txtColorLog;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.TextBox txtFeedLog;
        private System.Windows.Forms.Button btnLoadScreenshot;
    }
}

