using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AForge.Video.FFMPEG;
using AForge.Video;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.Remoting.Channels;
using NReco.VideoConverter;
using Plays.tv.Database;
using Plays.tv_App.Controllers;

namespace Plays.tv_App
{
    public partial class RecordingForm : Form
    {

        //Recording
        private Recording rec;
        //Database 
        private GameRepository game;
        private VideoRepository video;
        private List<Category> combocat;
        private List<Game> combogame;
        private List<string> Games;

        public RecordingForm()
        {
            InitializeComponent();
            appTimer.Start();
            rec = new Recording();
            video = new VideoRepository(new VideoSQLiteContext());
            game = new GameRepository(new GameSQLiteContext());
            Games = new List<string>() {"League of legends", "Overwatch", "Rocket League"};
            combocat = game.GetAllCats();
            combogame = game.GetAll();
        }


        // Initializes the recording of a video, makes a file with username and date made


        // Check if games are running, when games are running start recording
        private void appTimer_Tick(object sender, EventArgs e)
        {
            CheckGame("League of legends");


        }

        // This methods checks for a game to be running, when it starts it will start the recording method. This will automaticly set run false which makes the recording method stop
        public void CheckGame(string gamename)
        {
            
            
                Process[] pname = Process.GetProcessesByName(gamename);
                if (pname.Length == 0)
                {
                    rec.SetRecord(false);
                    lbRecording.Text = "Status: Not Recording";
                }
                else

                {
                    lbRecording.Text = "Status: Recording";
                    rec.StartRecording(@"C:\\Users\\BePulverized\\Videos\\Recordings");

                }
            
            
        }


        private void btStop_Click(object sender, EventArgs e)
        {
            try
            {

                rec.SetRecord(false);

                MessageBox.Show("File saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RecordingForm_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        // Refresh the form
        private void RefreshForm()
        {
            try
            {
                DirectoryInfo d = new DirectoryInfo(@"C:\\Users\\BePulverized\\Videos\\Recordings");
                //Assuming Test is your Folder
                FileInfo[] Files = d.GetFiles("*.mp4"); //Getting Text files
                string str = "";
                lbVideos.Items.Clear();
                cbGame.Items.Clear();
                cbCat.Items.Clear();
                foreach (FileInfo file in Files)
                {
                    str = file.Name;

                    lbVideos.Items.Add(str);
                }

                foreach (Game game in combogame)
                {
                    cbGame.Items.Add(game.ToString());

                }
                foreach (Category category in combocat)
                {
                    cbCat.Items.Add(category.ToString());
                }
                lbName.Text = AccountRepository.LoggedUser.Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void lbVideos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string videofile = @"C:\\Users\\BePulverized\\Videos\\Recordings\\" + lbVideos.SelectedItem.ToString();
                var ffmpeg = new NReco.VideoConverter.FFMpegConverter();
                string thumbnail = @"C:\\Users\\BePulverized\\Videos\\Recordings\\" + lbVideos.SelectedItem.ToString() +
                                   ".jpg";
                ffmpeg.GetVideoThumbnail(videofile, thumbnail, 20);
                pbThumbnail.ImageLocation = @"C:\\Users\\BePulverized\\Videos\\Recordings\\" +
                                            lbVideos.SelectedItem.ToString() + ".jpg";
                string date = videofile.Substring(videofile.IndexOf('_') + 1);
                int index = date.IndexOf(".");
                if (index > 0)
                    date = date.Substring(0, index);
                lbRecorded.Text = "Recorded: " + date;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbVideos.SelectedItem != null)
                {
                    byte[] bytes = File.ReadAllBytes(@"C:\\Users\\BePulverized\\Videos\\Recordings" + @"\\" + lbVideos.SelectedItem.ToString());
                    byte[] thumbnail =
                        File.ReadAllBytes(@"C:\\Users\\BePulverized\\Videos\\Recordings" + @"\\" +
                                           lbVideos.SelectedItem.ToString() + ".jpg");
                    Video videoUpload = new Video((User) AccountRepository.LoggedUser, 0, tbTitle.Text,
                        combocat[cbCat.SelectedIndex], combogame[cbGame.SelectedIndex], lbVideos.SelectedItem.ToString(), bytes, thumbnail);
                    video.Insert(videoUpload);
                    System.IO.Directory.CreateDirectory(@"C:\\Users\\BePulverized\\Videos\\Uploads" + @"\\" +
                                                        videoUpload.Author.ID);

                }
                else
                {
                    MessageBox.Show("Selecteer een video in de lijst!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbPage.Text)
            {
                case "My Uploaded Videos":
                    MainForm form = new MainForm();
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
    }
}

