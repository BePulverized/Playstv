namespace Plays.tv_App
{
    partial class RecordingForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordingForm));
            this.cbPage = new System.Windows.Forms.ComboBox();
            this.appTimer = new System.Windows.Forms.Timer(this.components);
            this.lbRecording = new System.Windows.Forms.Label();
            this.lbVideos = new System.Windows.Forms.ListBox();
            this.lbName = new System.Windows.Forms.Label();
            this.pbUser = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbThumbnail = new System.Windows.Forms.PictureBox();
            this.btUpload = new System.Windows.Forms.Button();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.lbRecorded = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbGame = new System.Windows.Forms.Label();
            this.lbCategory = new System.Windows.Forms.Label();
            this.cbGame = new System.Windows.Forms.ComboBox();
            this.cbCat = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnail)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbPage
            // 
            this.cbPage.FormattingEnabled = true;
            this.cbPage.Items.AddRange(new object[] {
            "My Uploaded Videos",
            "Recording",
            "Settings"});
            this.cbPage.Location = new System.Drawing.Point(12, 12);
            this.cbPage.Name = "cbPage";
            this.cbPage.Size = new System.Drawing.Size(141, 21);
            this.cbPage.TabIndex = 2;
            this.cbPage.Text = "Recording";
            this.cbPage.SelectedIndexChanged += new System.EventHandler(this.cbPage_SelectedIndexChanged);
            // 
            // appTimer
            // 
            this.appTimer.Tick += new System.EventHandler(this.appTimer_Tick);
            // 
            // lbRecording
            // 
            this.lbRecording.AutoSize = true;
            this.lbRecording.Location = new System.Drawing.Point(171, 15);
            this.lbRecording.Name = "lbRecording";
            this.lbRecording.Size = new System.Drawing.Size(43, 13);
            this.lbRecording.TabIndex = 3;
            this.lbRecording.Text = "Status: ";
            // 
            // lbVideos
            // 
            this.lbVideos.FormattingEnabled = true;
            this.lbVideos.Location = new System.Drawing.Point(12, 61);
            this.lbVideos.Name = "lbVideos";
            this.lbVideos.Size = new System.Drawing.Size(277, 394);
            this.lbVideos.TabIndex = 4;
            this.lbVideos.SelectedIndexChanged += new System.EventHandler(this.lbVideos_SelectedIndexChanged);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(438, 20);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 6;
            this.lbName.Text = "label1";
            // 
            // pbUser
            // 
            this.pbUser.Location = new System.Drawing.Point(557, 12);
            this.pbUser.Name = "pbUser";
            this.pbUser.Size = new System.Drawing.Size(45, 42);
            this.pbUser.TabIndex = 5;
            this.pbUser.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 15);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pbThumbnail
            // 
            this.pbThumbnail.Image = ((System.Drawing.Image)(resources.GetObject("pbThumbnail.Image")));
            this.pbThumbnail.Location = new System.Drawing.Point(295, 61);
            this.pbThumbnail.Name = "pbThumbnail";
            this.pbThumbnail.Size = new System.Drawing.Size(307, 172);
            this.pbThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbThumbnail.TabIndex = 8;
            this.pbThumbnail.TabStop = false;
            // 
            // btUpload
            // 
            this.btUpload.Location = new System.Drawing.Point(218, 162);
            this.btUpload.Name = "btUpload";
            this.btUpload.Size = new System.Drawing.Size(80, 23);
            this.btUpload.TabIndex = 9;
            this.btUpload.Text = "Upload video";
            this.btUpload.UseVisualStyleBackColor = true;
            this.btUpload.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(351, 281);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(251, 20);
            this.tbTitle.TabIndex = 10;
            // 
            // lbRecorded
            // 
            this.lbRecorded.AutoSize = true;
            this.lbRecorded.Location = new System.Drawing.Point(295, 236);
            this.lbRecorded.Name = "lbRecorded";
            this.lbRecorded.Size = new System.Drawing.Size(57, 13);
            this.lbRecorded.TabIndex = 11;
            this.lbRecorded.Text = "Recorded:";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Location = new System.Drawing.Point(6, 20);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(30, 13);
            this.lbTitle.TabIndex = 12;
            this.lbTitle.Text = "Title:";
            // 
            // lbGame
            // 
            this.lbGame.AutoSize = true;
            this.lbGame.Location = new System.Drawing.Point(6, 41);
            this.lbGame.Name = "lbGame";
            this.lbGame.Size = new System.Drawing.Size(69, 13);
            this.lbGame.TabIndex = 13;
            this.lbGame.Text = "Select game:";
            // 
            // lbCategory
            // 
            this.lbCategory.AutoSize = true;
            this.lbCategory.Location = new System.Drawing.Point(6, 63);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(84, 13);
            this.lbCategory.TabIndex = 14;
            this.lbCategory.Text = "Select category:";
            // 
            // cbGame
            // 
            this.cbGame.FormattingEnabled = true;
            this.cbGame.Location = new System.Drawing.Point(397, 302);
            this.cbGame.Name = "cbGame";
            this.cbGame.Size = new System.Drawing.Size(205, 21);
            this.cbGame.TabIndex = 15;
            // 
            // cbCat
            // 
            this.cbCat.FormattingEnabled = true;
            this.cbCat.Location = new System.Drawing.Point(397, 324);
            this.cbCat.Name = "cbCat";
            this.cbCat.Size = new System.Drawing.Size(205, 21);
            this.cbCat.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbTitle);
            this.groupBox1.Controls.Add(this.lbGame);
            this.groupBox1.Controls.Add(this.lbCategory);
            this.groupBox1.Controls.Add(this.btUpload);
            this.groupBox1.Location = new System.Drawing.Point(298, 264);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 191);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // RecordingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 467);
            this.Controls.Add(this.cbCat);
            this.Controls.Add(this.cbGame);
            this.Controls.Add(this.lbRecorded);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.pbThumbnail);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.pbUser);
            this.Controls.Add(this.lbVideos);
            this.Controls.Add(this.lbRecording);
            this.Controls.Add(this.cbPage);
            this.Controls.Add(this.groupBox1);
            this.Name = "RecordingForm";
            this.Text = "RecordingForm";
            this.Load += new System.EventHandler(this.RecordingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnail)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPage;
        private System.Windows.Forms.Timer appTimer;
        private System.Windows.Forms.Label lbRecording;
        private System.Windows.Forms.ListBox lbVideos;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.PictureBox pbUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbThumbnail;
        private System.Windows.Forms.Button btUpload;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label lbRecorded;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbGame;
        private System.Windows.Forms.Label lbCategory;
        private System.Windows.Forms.ComboBox cbCat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbGame;
    }
}