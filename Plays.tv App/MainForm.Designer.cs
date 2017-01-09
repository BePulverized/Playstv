namespace Plays.tv_App
{
    partial class MainForm
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
            this.lbVideos = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbName = new System.Windows.Forms.Label();
            this.gpVideoInfo = new System.Windows.Forms.GroupBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbCategory = new System.Windows.Forms.Label();
            this.lbGame = new System.Windows.Forms.Label();
            this.lbViews = new System.Windows.Forms.Label();
            this.lbDislike = new System.Windows.Forms.Label();
            this.lbLike = new System.Windows.Forms.Label();
            this.lbLikeNr = new System.Windows.Forms.Label();
            this.lbDislikenr = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gpVideoInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbVideos
            // 
            this.lbVideos.FormattingEnabled = true;
            this.lbVideos.Location = new System.Drawing.Point(12, 63);
            this.lbVideos.Name = "lbVideos";
            this.lbVideos.Size = new System.Drawing.Size(277, 394);
            this.lbVideos.TabIndex = 0;
            this.lbVideos.SelectedIndexChanged += new System.EventHandler(this.lbVideos_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "My Videos",
            "Recording",
            "Settings"});
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(141, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "My Uploaded Videos";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(557, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 42);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(438, 20);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 3;
            this.lbName.Text = "label1";
            // 
            // gpVideoInfo
            // 
            this.gpVideoInfo.Controls.Add(this.lbDislikenr);
            this.gpVideoInfo.Controls.Add(this.lbLikeNr);
            this.gpVideoInfo.Controls.Add(this.lbLike);
            this.gpVideoInfo.Controls.Add(this.lbDislike);
            this.gpVideoInfo.Controls.Add(this.lbViews);
            this.gpVideoInfo.Controls.Add(this.lbGame);
            this.gpVideoInfo.Controls.Add(this.lbCategory);
            this.gpVideoInfo.Controls.Add(this.lbTitle);
            this.gpVideoInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpVideoInfo.Location = new System.Drawing.Point(295, 63);
            this.gpVideoInfo.Name = "gpVideoInfo";
            this.gpVideoInfo.Size = new System.Drawing.Size(307, 188);
            this.gpVideoInfo.TabIndex = 4;
            this.gpVideoInfo.TabStop = false;
            this.gpVideoInfo.Text = "Info";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(6, 29);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(42, 21);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Titel:";
            // 
            // lbCategory
            // 
            this.lbCategory.AutoSize = true;
            this.lbCategory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategory.Location = new System.Drawing.Point(6, 49);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(76, 21);
            this.lbCategory.TabIndex = 1;
            this.lbCategory.Text = "Category:";
            // 
            // lbGame
            // 
            this.lbGame.AutoSize = true;
            this.lbGame.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGame.Location = new System.Drawing.Point(6, 70);
            this.lbGame.Name = "lbGame";
            this.lbGame.Size = new System.Drawing.Size(54, 21);
            this.lbGame.TabIndex = 2;
            this.lbGame.Text = "Game:";
            // 
            // lbViews
            // 
            this.lbViews.AutoSize = true;
            this.lbViews.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbViews.Location = new System.Drawing.Point(6, 91);
            this.lbViews.Name = "lbViews";
            this.lbViews.Size = new System.Drawing.Size(54, 21);
            this.lbViews.TabIndex = 3;
            this.lbViews.Text = "Views:";
            // 
            // lbDislike
            // 
            this.lbDislike.AutoSize = true;
            this.lbDislike.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDislike.Location = new System.Drawing.Point(139, 112);
            this.lbDislike.Name = "lbDislike";
            this.lbDislike.Size = new System.Drawing.Size(44, 37);
            this.lbDislike.TabIndex = 4;
            this.lbDislike.Text = "👎";
            // 
            // lbLike
            // 
            this.lbLike.AutoSize = true;
            this.lbLike.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLike.Location = new System.Drawing.Point(3, 112);
            this.lbLike.Name = "lbLike";
            this.lbLike.Size = new System.Drawing.Size(44, 37);
            this.lbLike.TabIndex = 5;
            this.lbLike.Text = "👍";
            // 
            // lbLikeNr
            // 
            this.lbLikeNr.AutoSize = true;
            this.lbLikeNr.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLikeNr.Location = new System.Drawing.Point(41, 125);
            this.lbLikeNr.Name = "lbLikeNr";
            this.lbLikeNr.Size = new System.Drawing.Size(19, 21);
            this.lbLikeNr.TabIndex = 6;
            this.lbLikeNr.Text = "0";
            // 
            // lbDislikenr
            // 
            this.lbDislikenr.AutoSize = true;
            this.lbDislikenr.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDislikenr.Location = new System.Drawing.Point(178, 125);
            this.lbDislikenr.Name = "lbDislikenr";
            this.lbDislikenr.Size = new System.Drawing.Size(19, 21);
            this.lbDislikenr.TabIndex = 7;
            this.lbDislikenr.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 467);
            this.Controls.Add(this.gpVideoInfo);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lbVideos);
            this.Name = "MainForm";
            this.Text = "My Videos";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gpVideoInfo.ResumeLayout(false);
            this.gpVideoInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbVideos;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.GroupBox gpVideoInfo;
        private System.Windows.Forms.Label lbGame;
        private System.Windows.Forms.Label lbCategory;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbDislikenr;
        private System.Windows.Forms.Label lbLikeNr;
        private System.Windows.Forms.Label lbLike;
        private System.Windows.Forms.Label lbDislike;
        private System.Windows.Forms.Label lbViews;
    }
}