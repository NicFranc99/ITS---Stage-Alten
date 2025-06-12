using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermercato_DB.Interfaces;

namespace Supermercato_DB.Repos
{
    public class UserRepository : IUserRepository
    {
        readonly string _connectionstring = @"Server=tcp:its-alen-bari.database.windows.net,1433;Initial Catalog=its-alten-bari;Persist Security Info=False;User ID=nicola.francavilla;Password=2Vm&aic&AMo-#pxL;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
        public bool GetUser(User user)
        {
            string query = "SELECT Username,Password FROM Users WHERE username=@username AND password =@password";
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("username", user.Username);
                        command.Parameters.AddWithValue("password", user.Password);

                        var reader = command.ExecuteReader();


                        while (reader.Read())
                        {
                            Console.WriteLine($"Username :{reader.GetString(0)} Password : {reader.GetString(1)}");
                        }

                        if (!reader.HasRows)
                        {
                            Console.WriteLine("!! Nessun Utente Trovato !!");
                            return false;
                        }
                        return true;
                    }
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("Query non riuscita");
                return false;
            }
        }
    }
}
