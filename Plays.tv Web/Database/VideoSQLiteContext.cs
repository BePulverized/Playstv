using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Plays.tv_App;
using Plays.tv_App.Database;

namespace Plays.tv.Database
{
    public class VideoSQLiteContext:IVideoContext
    {
        public List<Video> GetAll()
        {
            List<Video> result = new List<Video>();
            //using (SqlConnection connection = Database.Connection)
            //{
            //    string query = "SELECT * FROM VIDEO ORDER BY Id";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                int id = reader.GetInt32(0);
            //                User author = new User(1, "Bepulverized", "test", "password", "BePulverized", "test.png", 0);
            //                string title = reader.GetString(3);
            //                int views = reader.GetInt32(2);
            //                int likes = reader.GetInt32(4);
            //                int dislikes = reader.GetInt32(5);
            //                Game game = new Game(1, "test");
            //                Category category = new Category("test", 0);
            //                Video video = new Video(id, author, title, views, likes, dislikes, game, category);
            //                result.Add(video);
            //            }
            //        }
            //    }
            //}
            return result;
        }

        public List<Video> GetVideosbyGame(Game game)
        {
            List<Video> result = new List<Video>();
            //using (SqlConnection conn = Database.Connection)
            //{
            //    //query 
            //    string query =
            //        "SELECT * FROM VIDEO WHERE GAME_ID = @gameid ORDER BY Id";
            //    //opent de connectie vanuit de database classe            
            //    SqlCommand cmd = new SqlCommand(query, conn);
            //    cmd.Parameters.Add(new SqlParameter("@gameid", game.ID));
                
            //    //uitvoeren van de query
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {

            //            int id = reader.GetInt32(0);
            //            User author = new User(1, "Bepulverized", "test", "password", "BePulverized", "test.png",0);
            //            string title = reader.GetString(3);
            //            int views = reader.GetInt32(2);
            //            int likes = reader.GetInt32(4);
            //            int dislikes = reader.GetInt32(5);
            //            int gameid = reader.GetInt32(6);

            //            Video newVideo = new Video(id, author, title, views, likes, dislikes, game, new Category("MOBA", 20000));
            //            result.Add(newVideo);
            //        }
            //        // Check wat role is returned, based on role it initializes a different account
                    

            //    }
            //}
            return result;
        }

        public Video Insert(Video video)
        {
            using (SqlConnection connection = new SqlConnection(Database.Connection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO VIDEO(ACCOUNT_ID, VIEWS, TITLE, GAME_ID, CATEGORY_ID, LINK) VALUES(@account_id, @views, @title, @game_id, 1, @link)";
                    command.Parameters.AddWithValue("@account_id", video.Author.ID);
                    command.Parameters.AddWithValue("@views", video.Views);
                    command.Parameters.AddWithValue("@title", video.Title);
                    command.Parameters.AddWithValue("@game_id", video.Game.ID);
                    command.Parameters.AddWithValue("@link", @"C:\\Users\\BePulverized\\Videos\\Uploads" + video.Author.ID + @"\\" + video.Link);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }

                }
            }
            return video;
        }

        public bool Update(Video video)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Video> GetAllVideosReactions()
        {
            List<Video> result = new List<Video>();
            //using (SqlConnection connection = Database.Connection)
            //{
            //    string query =
            //        "SELECT V.TITLE, COUNT(R.ID) AS 'AANTAL REACTIES' FROM VIDEO V, REACTION R, VIDEO_REACTION VR WHERE R.ID = VR.REACTION_ID AND V.ID = VR.VIDEO_ID GROUP BY V.TITLE HAVING COUNT(R.ID) >= 10 ORDER BY COUNT(R.ID) DESC";

            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                string title = reader.GetString(0);
            //                int Reactions = reader.GetInt32(1);
            //                Video video = new Video(title,Reactions);
            //                result.Add(video);

                            

            //            }
            //        }
            //    }
            //}
            return result;
        }

        public List<Video> GetVideosByUser(User user)
        {
            List<Video> result = new List<Video>();
            using (SqlConnection conn = Database.Connection)
            {
                //query 
                string query = "SELECT ACCOUNT.NAME, ACCOUNT.EMAIL, ACCOUNT.PASSWORD, ACCOUNT.NICKNAME, ACCOUNT.PROFILEPIC,  VIDEO.ID, VIDEO.TITLE, VIDEO.VIEWS, G.ID, G.NAME, C.NAME, C.VIEWS, ACCOUNT.ID, SUM(F.[LIKE]), SUM(F.DISLIKE) FROM ACCOUNT FULL OUTER JOIN VIDEO ON VIDEO.ACCOUNT_ID = ACCOUNT.ID JOIN GAME G ON G.ID = VIDEO.GAME_ID LEFT JOIN CATEGORY C ON C.ID = VIDEO.CATEGORY_ID LEFT JOIN FEEDBACK F ON F.VIDEO_ID = VIDEO.ID GROUP BY ACCOUNT.NAME, ACCOUNT.EMAIL, ACCOUNT.PASSWORD, ACCOUNT.NICKNAME, ACCOUNT.PROFILEPIC, VIDEO.ID, VIDEO.TITLE, VIDEO.VIEWS, G.ID, G.NAME, C.NAME, C.VIEWS, ACCOUNT.ID HAVING ACCOUNT.NAME like @accountName";
                //opent de connectie vanuit de database classe            
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@accountName", user.Name));
                bool breakflag = false;
                //uitvoeren van de query
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read() && !breakflag)
                    {
                        if (reader.IsDBNull(5))
                        {
                            return null;
                        }
                        int id = reader.GetInt32(5);
                        string name = reader.GetString(0);
                        string email = reader.GetString(1);
                        string password = reader.GetString(2);
                        string nickname = string.Empty;
                        string profilepic = string.Empty;
                        int authorid = reader.GetInt32(12);
                        if (!reader.IsDBNull(3))
                        {
                            nickname = reader.GetString(3);
                        }
                        if (!reader.IsDBNull(4))
                        {
                            profilepic = reader.GetString(4);
                        }
                        string title = reader.GetString(6);
                        int views = reader.GetInt32(7);
                        int gameid = reader.GetInt32(8);
                        string gameTitle = reader.GetString(9);
                        string categoryName = reader.GetString(10);
                        int categoryViews = reader.GetInt32(11);
                        int likes = 0;
                        int dislikes = 0;
                        if (!reader.IsDBNull(13))
                        {
                            likes = reader.GetInt32(13);
                        }
                        
                        if (!reader.IsDBNull(14))
                        {
                            dislikes = reader.GetInt32(14);
                        }
                        
                        User author = new User(authorid, name, email, password, nickname, profilepic);
                        Game game = new Game(gameid, gameTitle);
                        Video newVideo = new Video(id, author, views, title, new Category(categoryName, categoryViews), new Feedback(likes,dislikes), game);
                        result.Add(newVideo);
                    }
                    // Check wat role is returned, based on role it initializes a different account


                }
            }
            return result;
        }

        public List<Video> GetRecentVideos()
        {
            List<Video> result = new List<Video>();
            using (SqlConnection conn = Database.Connection)
            {
                //query 
                string query = "SELECT TOP 10 ACCOUNT.NAME, ACCOUNT.EMAIL, ACCOUNT.PASSWORD, ACCOUNT.NICKNAME, ACCOUNT.PROFILEPIC,  VIDEO.ID, VIDEO.TITLE, VIDEO.VIEWS, G.ID, G.NAME, C.NAME, C.VIEWS, ACCOUNT.ID, SUM(F.[LIKE]), SUM(F.DISLIKE) FROM ACCOUNT FULL OUTER JOIN VIDEO ON VIDEO.ACCOUNT_ID = ACCOUNT.ID JOIN GAME G ON G.ID = VIDEO.GAME_ID LEFT JOIN CATEGORY C ON C.ID = VIDEO.CATEGORY_ID LEFT JOIN FEEDBACK F ON F.VIDEO_ID = VIDEO.ID GROUP BY ACCOUNT.NAME, ACCOUNT.EMAIL, ACCOUNT.PASSWORD, ACCOUNT.NICKNAME, ACCOUNT.PROFILEPIC, VIDEO.ID, VIDEO.TITLE, VIDEO.VIEWS, G.ID, G.NAME, C.NAME, C.VIEWS, ACCOUNT.ID ORDER BY VIDEO.ID DESC";
                //opent de connectie vanuit de database classe            
                SqlCommand cmd = new SqlCommand(query, conn);
               
                bool breakflag = false;
                //uitvoeren van de query
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read() && !breakflag)
                    {
                        if (reader.IsDBNull(5))
                        {
                            return null;
                        }
                        int id = reader.GetInt32(5);
                        string name = reader.GetString(0);
                        string email = reader.GetString(1);
                        string password = reader.GetString(2);
                        string nickname = string.Empty;
                        string profilepic = string.Empty;
                        int authorid = reader.GetInt32(12);
                        if (!reader.IsDBNull(3))
                        {
                            nickname = reader.GetString(3);
                        }
                        if (!reader.IsDBNull(4))
                        {
                            profilepic = reader.GetString(4);
                        }
                        string title = reader.GetString(6);
                        int views = reader.GetInt32(7);
                        int gameid = reader.GetInt32(8);
                        string gameTitle = reader.GetString(9);
                        string categoryName = reader.GetString(10);
                        int categoryViews = reader.GetInt32(11);
                        int likes = 0;
                        int dislikes = 0;
                        if (!reader.IsDBNull(13))
                        {
                            likes = reader.GetInt32(13);
                        }

                        if (!reader.IsDBNull(14))
                        {
                            dislikes = reader.GetInt32(14);
                        }
                        
                        User author = new User(authorid, name, email, password, nickname, profilepic);
                        Game game = new Game(gameid, gameTitle);
                        Video newVideo = new Video(id, author, views, title, new Category(categoryName, categoryViews), new Feedback(likes, dislikes), game);
                        result.Add(newVideo);
                    }
                    // Check wat role is returned, based on role it initializes a different account


                }
            }
            return result;
        }

        public Video GetVideo(int videoid)
        {
            Video result = null;
            using (SqlConnection conn = Database.Connection)
            {
                //query 
                string query = "SELECT ACCOUNT.NAME, ACCOUNT.EMAIL, ACCOUNT.PASSWORD, ACCOUNT.NICKNAME, ACCOUNT.PROFILEPIC,  VIDEO.ID, VIDEO.TITLE, VIDEO.VIEWS, G.ID, G.NAME, C.NAME, C.VIEWS, ACCOUNT.ID, SUM(F.[LIKE]), SUM(F.DISLIKE), VIDEO.DATA, VIDEO.THUMBNAIL FROM ACCOUNT FULL OUTER JOIN VIDEO ON VIDEO.ACCOUNT_ID = ACCOUNT.ID JOIN GAME G ON G.ID = VIDEO.GAME_ID LEFT JOIN CATEGORY C ON C.ID = VIDEO.CATEGORY_ID LEFT JOIN FEEDBACK F ON F.VIDEO_ID = VIDEO.ID GROUP BY ACCOUNT.NAME, ACCOUNT.EMAIL, ACCOUNT.PASSWORD, ACCOUNT.NICKNAME, ACCOUNT.PROFILEPIC, VIDEO.ID, VIDEO.TITLE, VIDEO.VIEWS, G.ID, G.NAME, C.NAME, C.VIEWS, ACCOUNT.ID, VIDEO.DATA, VIDEO.THUMBNAIL HAVING VIDEO.ID = @videoid";
                //opent de connectie vanuit de database classe            
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@videoid", videoid);
                bool breakflag = false;
                //uitvoeren van de query
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read() && !breakflag)
                    {
                        if (reader.IsDBNull(5))
                        {
                            return null;
                        }
                        int id = reader.GetInt32(5);
                        string name = reader.GetString(0);
                        string email = reader.GetString(1);
                        string password = reader.GetString(2);
                        string nickname = string.Empty;
                        string profilepic = string.Empty;
                        int authorid = reader.GetInt32(12);
                        if (!reader.IsDBNull(3))
                        {
                            nickname = reader.GetString(3);
                        }
                        if (!reader.IsDBNull(4))
                        {
                            profilepic = reader.GetString(4);
                        }
                        string title = reader.GetString(6);
                        int views = reader.GetInt32(7);
                        int gameid = reader.GetInt32(8);
                        string gameTitle = reader.GetString(9);
                        string categoryName = reader.GetString(10);
                        int categoryViews = reader.GetInt32(11);
                        int likes = 0;
                        int dislikes = 0;
                        if (!reader.IsDBNull(13))
                        {
                            likes = reader.GetInt32(13);
                        }

                        if (!reader.IsDBNull(14))
                        {
                            dislikes = reader.GetInt32(14);
                        }
                        byte[] data = (byte[])reader["data"];
                        byte[] thumbnail = (byte[]) reader["thumbnail"];
                        User author = new User(authorid, name, email, password, nickname, profilepic);
                        Game game = new Game(gameid, gameTitle);
                        Video newVideo = new Video(id, author, views, title, new Category(categoryName, categoryViews), new Feedback(likes, dislikes), game,data, thumbnail);
                        result = newVideo;
                    }
                    // Check wat role is returned, based on role it initializes a different account


                }
            }
            return result;
        }

        public List<Video> SearchVideos(string search)
        {
            List<Video> result = new List<Video>();
            using (SqlConnection conn = Database.Connection)
            {
                //query 
                string query = "SELECT TOP 10 ACCOUNT.NAME, ACCOUNT.EMAIL, ACCOUNT.PASSWORD, ACCOUNT.NICKNAME, ACCOUNT.PROFILEPIC,  VIDEO.ID, VIDEO.TITLE, VIDEO.VIEWS, G.ID, G.NAME, C.NAME, C.VIEWS, ACCOUNT.ID, SUM(F.[LIKE]), SUM(F.DISLIKE) FROM ACCOUNT FULL OUTER JOIN VIDEO ON VIDEO.ACCOUNT_ID = ACCOUNT.ID JOIN GAME G ON G.ID = VIDEO.GAME_ID LEFT JOIN CATEGORY C ON C.ID = VIDEO.CATEGORY_ID LEFT JOIN FEEDBACK F ON F.VIDEO_ID = VIDEO.ID GROUP BY ACCOUNT.NAME, ACCOUNT.EMAIL, ACCOUNT.PASSWORD, ACCOUNT.NICKNAME, ACCOUNT.PROFILEPIC, VIDEO.ID, VIDEO.TITLE, VIDEO.VIEWS, G.ID, G.NAME, C.NAME, C.VIEWS, ACCOUNT.ID HAVING VIDEO.TITLE LIKE '%' + @search + '%' OR G.NAME LIKE '%' + @search + '%' OR ACCOUNT.NAME LIKE '%' + @search + '%' ORDER BY VIDEO.ID DESC";
                //opent de connectie vanuit de database classe            
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", search);

                bool breakflag = false;
                //uitvoeren van de query
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read() && !breakflag)
                    {
                        if (reader.IsDBNull(5))
                        {
                            return null;
                        }
                        int id = reader.GetInt32(5);
                        string name = reader.GetString(0);
                        string email = reader.GetString(1);
                        string password = reader.GetString(2);
                        string nickname = string.Empty;
                        string profilepic = string.Empty;
                        int authorid = reader.GetInt32(12);
                        if (!reader.IsDBNull(3))
                        {
                            nickname = reader.GetString(3);
                        }
                        if (!reader.IsDBNull(4))
                        {
                            profilepic = reader.GetString(4);
                        }
                        string title = reader.GetString(6);
                        int views = reader.GetInt32(7);
                        int gameid = reader.GetInt32(8);
                        string gameTitle = reader.GetString(9);
                        string categoryName = reader.GetString(10);
                        int categoryViews = reader.GetInt32(11);
                        int likes = 0;
                        int dislikes = 0;
                        if (!reader.IsDBNull(13))
                        {
                            likes = reader.GetInt32(13);
                        }

                        if (!reader.IsDBNull(14))
                        {
                            dislikes = reader.GetInt32(14);
                        }

                        User author = new User(authorid, name, email, password, nickname, profilepic);
                        Game game = new Game(gameid, gameTitle);
                        Video newVideo = new Video(id, author, views, title, new Category(categoryName, categoryViews), new Feedback(likes, dislikes), game);
                        result.Add(newVideo);
                    }
                    // Check wat role is returned, based on role it initializes a different account


                }
            }
            return result;
        }

        public bool InsertFeedback(Feedback feedback)
        {
            using (SqlConnection connection = new SqlConnection(Database.Connection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO FEEDBACK(USER_ID, [LIKE], VIDEO_ID, DISLIKE) VALUES (@account_id, @like, @videoid, @dislike)";
                    command.Parameters.AddWithValue("@account_id", feedback.UserID);
                    command.Parameters.AddWithValue("@like", feedback.Like);
                    command.Parameters.AddWithValue("@videoid", feedback.VideoID);
                    command.Parameters.AddWithValue("@dislike", feedback.Dislike);
                   

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }

                }
            }
            return true;
        }

        public bool View(int id)
        {
            using (SqlConnection connection = new SqlConnection(Database.Connection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "ADDVIEW @ID = @videoid";
                    command.Parameters.AddWithValue("@videoid", id);
                    
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }

                }
            }
            return true;
        }
    }
}
