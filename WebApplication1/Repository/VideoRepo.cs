﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plays.tv_App.Database;

namespace Plays.tv_App.Controllers
{
    public class VideoRepo
    {
        private IVideoContext context;
        public VideoRepo(IVideoContext context)
        {
            this.context = context;
        }

        public List<Video> GetVideosByUser(User user)
        {
            return context.GetVideosByUser(user);
        }

        public Video Insert(Video video)
        {
            return context.Insert(video);
        }

        public List<Video> GetRecentVideos()
        {
            return context.GetRecentVideos();
        }

        public Video GetVideo(int id)
        {
            return context.GetVideo(id);
        }
    }
}
