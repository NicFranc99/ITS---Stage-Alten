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
            string query = @"SELECT username,password,dbo.users.id_role
                             FROM dbo.users 
                             JOIN dbo.roles on users.id_role=roles.id_role 
                             WHERE dbo.users.username=@username AND password=@password 
                             AND (dbo.users.id_role = 3 OR dbo.users.id_role=4);";
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
                            Console.WriteLine("Utente:\n");
                            Console.WriteLine($"Username: {reader.GetString(0)} Password: {reader.GetString(1)}");

                            user.Id_ruolo = (int)reader.GetInt64(2);
                        }

                        if (!reader.HasRows)
                        {
                            Console.WriteLine("!! Nessun Utente Trovato !!");
                            user.Id_ruolo = 0;
                            
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
