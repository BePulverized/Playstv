using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.FFMPEG;

namespace Plays.tv_App
{
    // In deze klassen wordt al het werk gedaan ivm met het opnemen van videos. De ffmpeg dll wordt hiervoor vaak gebruikt. Uiteindelijk wordt het bestand opgeslagen als een flv bestand. 
    public class Recording
    {
        private bool _run = false;
        private bool rec = false;
        private Rectangle screenSize = Screen.PrimaryScreen.Bounds;
        private UInt32 framecount = 0;
        private VideoFileWriter writer;
        private int width = SystemInformation.PrimaryMonitorSize.Width;
        private int height = SystemInformation.PrimaryMonitorSize.Height;
        private AForge.Video.ScreenCaptureStream streamVideo;
        Stopwatch stopWatch = new Stopwatch();

        public Recording()
        {
            writer = new VideoFileWriter();
        }
        // Er kan gekozen worden voor verschillende bitrates (De kwaliteit van de video hangt hier erg van af)
        private enum bitRate
        {
            _50kbit = 5000,
            _100kbit = 10000,
            _500kbit = 50000,
            _1000kbit = 1000000,
            _2000kbit = 2000000,
            _3000kbit = 3000000
        }

        public void SetRecord(bool record)
        {
            rec = record;
        }

        public void StartRecording(string path)
        {
            if (rec == false)
            {
                rec = true;

                framecount = 0;
                string time = DateTime.Now.ToString("d_MMM_yyy_HH_mm_ssff");
                string compName = Environment.UserName;
                string fullName = path + @"\\" + compName.ToUpper() + "_" + time;

                try
                {
                    writer.Open(fullName + ".mp4", width, height, 10, VideoCodec.MPEG4);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                DoJob();
            }
        }

        private void DoJob()
        {
            try
            {
                streamVideo = new ScreenCaptureStream(screenSize);

                streamVideo.NewFrame += new NewFrameEventHandler(video_NewFrame);

                streamVideo.Start();

                stopWatch.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // As long as recording = true keep this event active
        private void video_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            try
            {
                if (rec)
                {
                    framecount++;
                    writer.WriteVideoFrame(eventArgs.Frame);

                }
                else
                {

                    stopWatch.Reset();
                    Thread.Sleep(500);
                    streamVideo.SignalToStop();
                    Thread.Sleep(500);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
