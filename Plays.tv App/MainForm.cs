using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Plays.tv.Database;
using Plays.tv_App.Controllers;

namespace Plays.tv_App
{
    public partial class MainForm : Form
    {
        private VideoController video;
        private List<Video> myVideos;
        public MainForm()
        {
            
                video = new VideoController(new VideoSQLiteContext());
                myVideos = video.GetVideosByUser((User) AccountController.LoggedUser);
            
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lbName.Text = AccountController.LoggedUser.Name;
            RefreshForm();
        }

        public void RefreshForm()
        {
            
            foreach (Video video in myVideos)
            {
                lbVideos.Items.Add(video.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // This combobox is used for navigating between forms
            switch (comboBox1.Text)
            {
                case "Recording":
                    RecordingForm form = new RecordingForm();
                    form.Show();
                    this.Hide();
                    break;
                case "Settings":
                    SettingsForm sform = new SettingsForm();
                    sform.Show();
                    this.Hide();
                    break;

            }
        }

        private void lbVideos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                lbTitle.Text = "Title: " + myVideos[lbVideos.SelectedIndex].Title;
                lbCategory.Text = "Category: " + myVideos[lbVideos.SelectedIndex].Category.Name;
                lbGame.Text = "Game: " + myVideos[lbVideos.SelectedIndex].Game.Name;
                lbViews.Text = "Views: " + myVideos[lbVideos.SelectedIndex].Views;
                lbLikeNr.Text = myVideos[lbVideos.SelectedIndex].Feedback.Like.ToString();
                lbDislikenr.Text = myVideos[lbVideos.SelectedIndex].Feedback.Dislike.ToString();
            
        }
    }
}
