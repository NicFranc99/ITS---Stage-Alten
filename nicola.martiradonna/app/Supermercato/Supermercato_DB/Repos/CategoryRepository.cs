using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Supermercato_DB.Interfaces;

namespace Supermercato_DB.Repos
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly string _connectionstring = @"Server=tcp:its-alen-bari.database.windows.net,1433;Initial Catalog=its-alten-bari;Persist Security Info=False;User ID=nicola.francavilla;Password=2Vm&aic&AMo-#pxL;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
        public bool GetProductsDescription()
        {
            string query = @"SELECT Id,Descrizione 
                             FROM market.categoria";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Console.WriteLine($"Id: {reader.GetInt64(0)} Categoria: {reader.GetString(1)}");

                        }
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("Nessuna categoria trovata");
                            return false;

                        }
                        return true;
                    }
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("!! Query non riuscita !!");
                return false;
            }
        }

        public bool GetProductDescriptionById(int id)
        {
            string query = @"SELECT Id,Descrizione 
                             FROM market.categoria 
                             WHERE Id=@id;";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("id", id);

                        var reader = command.ExecuteReader();

                        if (!reader.HasRows)
                        {
                            return false;

                        }
                        return true;
                    }
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("!! Query non riuscita !!");
                return false;
            }
        }
    }
}
