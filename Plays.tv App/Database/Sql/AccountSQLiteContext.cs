using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plays.tv_App;
using Plays.tv_App.Database;

namespace Plays.tv.Database
{
    public class AccountSQLiteContext : IAccountContext
    {
        // Login, verschillende constructors afhankelijk van user of admin
        public Account Login(string username, string pw)
        {
            int id = int.MinValue;
            string name = string.Empty;
            string email = string.Empty;
            string password = string.Empty;
            string role = string.Empty;
            string nickname = string.Empty;
            string profilepic = string.Empty;
            Account login = null;
            using (SqlConnection conn = Database.Connection)
            {
                //query 
                string query =
                    "SELECT * FROM ACCOUNT A WHERE A.NAME = @name AND A.PASSWORD = @password";
                //opent de connectie vanuit de database classe            
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@name", username));
                cmd.Parameters.Add(new SqlParameter("@password", pw));

                //uitvoeren van de query
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader.GetInt32(0));
                        name = Convert.ToString(reader.GetString(1));
                        email = Convert.ToString(reader.GetString(2));
                        password = reader.GetString(3);
                        role = reader.GetString(4);
                        if (!reader.IsDBNull(5))
                        {
                            nickname = reader.GetString(5);
                        }
                        if (!reader.IsDBNull(6))
                        {
                            profilepic = reader.GetString(6);
                        }
                        
                    }
                }
            }

            if (role == "ADMIN")
            {
                Permissions permission = GetPermissions(id);
                return new Admin(id, name, email, password, permission);
            }
            
                return new User(id, name, email, password, nickname,profilepic);
            
        }
        // Wanneer er een admin wordt opgehaald moeten ook de permissions van de admin geladen worden
        public Permissions GetPermissions(int id)
        {
            Permissions permission = Permissions.FULLCONTROL;
            Admin login = null;
            using (SqlConnection conn = Database.Connection)
            {
                //query 
                string query =
                   "SELECT P.NAME FROM PERMISSION P, PERMISSION_ACCOUNT PA, ACCOUNT A WHERE PA.PERMISSION_ID = P.ID AND A.ID = PA.ACCOUNT_ID AND A.ID = @id";
                //opent de connectie vanuit de database classe            
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                
                //uitvoeren van de query
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        permission = (Permissions)System.Enum.Parse(typeof(Permissions), reader.GetString(0));
                        
                    }



                }
            }
            return permission;
            
        }
        // Ophalen van alle Users, er wordt ook afgehandeld of er een user of admin wordt opgehaald
        public List<Account> GetAll()
        {
            int id = int.MinValue;
            string name = string.Empty;
            string email = string.Empty;
            string password = string.Empty;
            string role = string.Empty;
            string nickname = string.Empty;
            string profilepic = string.Empty;
            int numberVideos = 0;
            List<Account> result = new List<Account>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "select a.ID, a.name, a.EMAIL, a.PASSWORD, a.ROLE, a.nickname, a. profilepic, count(v.id) from account a left join video v on a.id = v.account_id group by a.id, a.name, a.EMAIL, a.password, a.role, a.nickname, a.profilepic";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                             id = reader.GetInt32(0);
                             name = reader.GetString(1);
                             email = reader.GetString(2);
                             password = reader.GetString(3);
                             role = reader.GetString(4);
                            if (!reader.IsDBNull(5))
                            {
                                nickname = reader.GetString(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                profilepic = reader.GetString(6);
                            }
                            numberVideos = reader.GetInt32(7);
                            if (role == "ADMIN")
                            {
                                Permissions permission = GetPermissions(id);
                                Admin admin = new Admin(id, name, email, password, permission);
                                result.Add(admin);
                            }
                            else if (role == "USER")
                            {
                                User user = new User(id, name, email, password, nickname, profilepic);
                                result.Add(user);
                            }
                            
                            
                        }
                    }
                }
            }
            return result;
        }

        public bool Delete(int id)
        {
            return true;
        }
        // User creation
        public bool CreateUser(User user)
        {

            using (SqlConnection connection = new SqlConnection(Database.Connection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;            
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO ACCOUNT(NAME, EMAIL, PASSWORD, ROLE, NICKNAME, PROFILEPIC) VALUES(@name, @email, @password, @role, @nickname, 'test.png')";
                    command.Parameters.AddWithValue("@name", user.Name);
                    command.Parameters.AddWithValue("@email", user.Email);
                    command.Parameters.AddWithValue("@password", user.Password);
                    command.Parameters.AddWithValue("@role", "USER");
                    command.Parameters.AddWithValue("@nickname", user.Nickname);

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

        public bool CreateAdmin(Admin admin)
        {
            throw new NotImplementedException();
        }
        
    }
}


