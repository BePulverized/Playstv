using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plays.tv_App;
using Plays.tv_App.Database;

namespace Plays.tv.Database
{
    public class GameSQLiteContext:IGameContext
    {
        // Getting a list for all the games available from the database
        public List<Game> GetAll()
        {
            List<Game> result = new List<Game>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM GAME ORDER BY Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Game game = new Game(reader.GetInt32(0),reader.GetString(1));
                            result.Add(game);
                        }
                    }
                }
            }
            return result;
        }
        // Getting all the categories saved in the database
        public List<Category> GetAllCats()
        {
            List<Category> result = new List<Category>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM CATEGORY ORDER BY Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Category cat = new Category(reader.GetString(1), reader.GetInt32(2));
                            result.Add(cat);
                        }
                    }
                }
            }
            return result;
        }

        public Game GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Game Insert(Game game)
        {
            throw new NotImplementedException();
        }

        public bool Update(Game game)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
