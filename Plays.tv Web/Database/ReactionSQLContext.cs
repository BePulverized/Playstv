using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plays.tv_App;
using Plays.tv_App.Database;

namespace Plays.tv.Database
{
    public class ReactionSQLContext:IReactionContext
    {
        public List<Reaction> GetAll()
        {
            List<Reaction> result = new List<Reaction>();
            //string text = string.Empty;
            //int parentId = 0;
            //using (SqlConnection conn = Database.Connection)
            //{
            //    //query 
            //    string query =
            //        "SELECT * FROM GETALLREACTIONS()";

            //    //opent de connectie vanuit de database classe            
            //    SqlCommand cmd = new SqlCommand(query, conn);
                
            //    //uitvoeren van de query
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {

            //            text = reader.GetString(1);

            //            if (!reader.IsDBNull(2))
            //            {
            //                parentId = reader.GetInt32(2);
            //            }



                        
            //            Reaction reaction = new Reaction(text, parentId);
            //            if (reaction.ParentId != 0)
            //            {
            //                result.Add(reaction);
            //            }
            //            else
            //            {
            //                Reaction parentReaction = new Reaction(text);
            //                result.Add(parentReaction);
            //            }
            //        }
            //        // Check wat role is returned, based on role it initializes a different account


            //    }
            //}
            return result;
        }
    

        
            public List<Reaction> GetReactionsbyVideo(int id)
        {
            List<Reaction> result = new List<Reaction>();
            using (SqlConnection conn = Database.Connection)
            {
                //query 
                string query =
                    "SELECT R.TEXT, A.ID, A.NAME, A.EMAIL, A.PASSWORD, A.NICKNAME, A.PROFILEPIC FROM REACTION R JOIN ACCOUNT A ON A.ID = R.ACCOUNT_ID WHERE R.VIDEO_ID = @videoid";

                //opent de connectie vanuit de database classe            
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@videoid", id));

                //uitvoeren van de query
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int userid = reader.GetInt32(1);
                        string name = reader.GetString(2);
                        string email = reader.GetString(3);
                        string password = reader.GetString(4);
                        string nickname = string.Empty;
                        if (!reader.IsDBNull(5))
                        {
                            nickname = reader.GetString(5);
                        }
                        string profilepic = string.Empty;
                        if (!reader.IsDBNull(6))
                        {
                            profilepic = string.Empty;
                        }
                        string text = reader.GetString(0);
                        User user = new User(id, name, email, password, nickname, profilepic);
                        Reaction reaction = new Reaction(text, user,0);
                        result.Add(reaction);
                    }
                    // Check wat role is returned, based on role it initializes a different account


                }
            }
            return result;
        }

        public bool Insert(string text, int accountid, int videoid)
        {
            using (SqlConnection connection = new SqlConnection(Database.Connection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO REACTION(ACCOUNT_ID, TEXT, VIDEO_ID, PARENTREACTION_ID) VALUES(@accountid, @text, @videoid, 0)";
                    command.Parameters.AddWithValue("@accountid", accountid);
                    command.Parameters.AddWithValue("@text", text);
                    command.Parameters.AddWithValue("@videoid", videoid);


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

        public bool Update(Reaction reaction)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Reaction GetByID(int id)
        {
            Reaction result = null;
            //string text = String.Empty;
            //int parentId = 0;
            //using (SqlConnection conn = Database.Connection)
            //{
            //    //query 
            //    string query =
            //        "SELECT R.TEXT, R.PARENT_ID FROM REACTION R WHERE R.ID = @ID";

            //    //opent de connectie vanuit de database classe            
            //    SqlCommand cmd = new SqlCommand(query, conn);
            //    cmd.Parameters.Add(new SqlParameter("@ID", id));

            //    //uitvoeren van de query
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {

            //            text = reader.GetString(0);
            //            if (!reader.IsDBNull(1))
            //            {
            //                parentId = reader.GetInt32(1);
            //            }
            //            else
            //            {
            //                parentId = 0;
            //            }



            //            result = new Reaction(text, parentId);
                        
            //        }
            //        // Check wat role is returned, based on role it initializes a different account


            //    }
            //}
            return result;
        }

        
    }
}
