using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plays.tv_App
{
    public class Video
    {
        public int ID { get; set; }
        public User Author { get; set; }
        public int Views { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        public Feedback Feedback { get; set; }
        public Game Game { get; set; }
        public string Link { get; set; }
        public byte[] Data { get; set; }
        public byte[] Thumbnail { get; set; }

        public Video(int id, User author, int views, string title, Category category, Feedback feedback, Game game)
        {
            ID = id;
            Author = author;
            Views = views;
            Title = title;
            Category = category;
            Feedback = feedback;
            Game = game;
        }

        public Video(User author, int views, string title, Category category, Game game, string link)
        {
            Author = author;
            Views = views;
            Title = title;
            Category = category;
            Game = game;
            Link = link;
        }

        public Video(int id, User author, int views, string title, Category category, Feedback feedback, Game game, byte[] data, byte[] thumbnail)
        {
            ID = id;
            Author = author;
            Views = views;
            Title = title;
            Category = category;
            Feedback = feedback;
            Game = game;
            Data = data;
            Thumbnail = thumbnail;
        }


        public override string ToString()
        {
            return Title + " - Views: " + Views;
        }
    }
}
