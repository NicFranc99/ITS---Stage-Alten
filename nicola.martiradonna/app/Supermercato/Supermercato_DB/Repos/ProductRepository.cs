using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Supermercato_DB.Interfaces;

namespace Supermercato_DB.Repos
{
    public class ProductRepository : IProductRepository
    {
        readonly string _connectionstring = @"Server=tcp:its-alen-bari.database.windows.net,1433;Initial Catalog=its-alten-bari;Persist Security Info=False;User ID=nicola.francavilla;Password=2Vm&aic&AMo-#pxL;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";

        

        public bool GetAllProducts()
        {
            string query = @"SELECT market.prodotti.Id,Nome,Prezzo,Descrizione,Quantita 
                             FROM market.prodotti 
                             JOIN market.categoria on Id_Categoria = market.categoria.Id";

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
                            Console.WriteLine("\nProdotto:");
                            Console.WriteLine($"Id: {reader.GetInt64(0)} Nome: {reader.GetString(1)} Prezzo: {reader.GetDecimal(2)} Descrizione: {reader.GetString(3)} Quantità: {reader.GetInt32(4)}");
                        }
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("!!  Nessun prodotto trovato  !!");
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

        public bool CreateNewProduct(Product product,int IdDescription)
        {
            string query = @"INSERT INTO market.prodotti (Nome,Prezzo,Quantita,Id_Categoria) 
                             VALUES(@nome,@prezzo,@quantita,@idDescription);";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("nome", product.Nome);
                        command.Parameters.AddWithValue("prezzo", product.Prezzo);
                        command.Parameters.AddWithValue("quantita", product.Quantita);
                        command.Parameters.AddWithValue("idDescription", IdDescription);

                        var rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Prodotto inserito con successo!");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("!!  Inserimento Prodotto fallito  !!");
                            return false;
                        }
                    }
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("Query non riuscita");
                return false;
            }
        }

        public bool GetProductById(int id)
        {
            string query = @"SELECT market.prodotti.Id,Nome,Prezzo,Descrizione,Quantita
                           FROM market.prodotti 
                           JOIN market.categoria on Id_Categoria = market.categoria.Id  
                           WHERE market.prodotti.Id=@id";
            try
            {

                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("id", id);

                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Console.WriteLine("\nProdotto trovato: \n");
                            Console.WriteLine($"Id: {reader.GetInt64(0)} Nome: {reader.GetString(1)} Prezzo: {reader.GetDecimal(2)} Descrizione: {reader.GetString(3)} Quantità: {reader.GetInt32(4)}");
                        }
                        if (!reader.HasRows)
                        {
                            Console.WriteLine($"\n!!  Nessun prodotto trovato con id: {id}  !!");
                            return false;
                        }
                        return true;
                    }
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("\n!!  Query non riuscita !!");
                return false;
            }
        }

        public bool IsProductQuantityAvaible(int id, int quantita)
        {
            string query = @"SELECT Nome,Quantita 
                             FROM market.prodotti 
                             WHERE @quantita<=Quantita AND Id=@id";


            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("quantita", quantita);
                        command.Parameters.AddWithValue("id", id);

                        var reader = command.ExecuteReader();

                        if (!reader.HasRows)
                        {
                            Console.WriteLine("Non è possibile prendere quella quantità");
                            return false;
                        }


                            return true;
                    }
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("\n!!  Query non riuscita !!");
                return false;
            }
        }

        public bool UpdateProductQuantity(int id, int quantita)
        {
            string query = @"UPDATE market.prodotti 
                             SET Quantita=(Quantita-@quantita) 
                             WHERE Id= @id";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("quantita", quantita);
                        command.Parameters.AddWithValue("id", id);

                        int rowsAffected= command.ExecuteNonQuery();

                        if(rowsAffected > 0)
                        {
                            Console.WriteLine("\n La quantità è stata aggiornata");
                            return true;
                        }

                        return false;
                    }
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("\n!!  Query non riuscita !!");
                return false;
            }
        }

        public Product AddProductToTheCart(int id, Product prodottoCarrello)
        {
            string query = @"SELECT Nome,Prezzo,Quantita 
                             FROM market.prodotti 
                             WHERE Id=@id";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("id", id);

                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            prodottoCarrello.Nome = reader.GetString(0);
                            prodottoCarrello.Prezzo = reader.GetDecimal(1) * prodottoCarrello.Quantita;

                        }

                        return prodottoCarrello;
                    }
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("\n!!  Query non riuscita  !!");
                return null;
            }
        }

        
    }
}
