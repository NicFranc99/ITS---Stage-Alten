using BarberApplication.@class;
using BarberApplication.Interfaces;
using Microsoft.Data.SqlClient;

namespace BarberApplication.Repos
{
    internal class Cliente_ServizioRepository : IDatabaseCliente_Servizio
    {
        readonly string _connectionstring = @"Server=tcp:its-alen-bari.database.windows.net,1433;Initial Catalog=its-alten-bari;Persist Security Info=False;User ID=nicola.francavilla;Password=2Vm&aic&AMo-#pxL;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
        public bool AssociaServizio(Cliente_Servizio cliente_servizio)
        {
            string query = "INSERT INTO barber.clienti_servizi (ClienteId, ServizioId) VALUES (@clienteId, @servizioId)";

            try
            {

                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {

                        sqlCommand.Parameters.Add(new SqlParameter("ClienteId", cliente_servizio.ClienteId));
                        sqlCommand.Parameters.Add(new SqlParameter("ServizioId", cliente_servizio.ServizioId));


                        sqlCommand.ExecuteNonQuery();
                        return true;
                    }

                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore di connessione al database");
                return false;
            }
        }

        public bool RemoveServizio(Cliente_Servizio cliente_servizio)
        {
            string query = "DELETE FROM barber.clienti_servizi WHERE ClienteId = @ClienteId AND ServizioId = @ServizioId";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("ClienteId", cliente_servizio.ClienteId));
                        sqlCommand.Parameters.Add(new SqlParameter("ServizioId", cliente_servizio.ServizioId));

                        int righeCancellate = sqlCommand.ExecuteNonQuery();

                        if (righeCancellate > 0)
                        {
                            Console.WriteLine("Associazione rimossa correttamente.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Nessun'associazione trovata per i parametri specificati.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore di connessione al database");
                return false;
            }
        }



        public bool VisualizzaServizioPerCliente(Cliente_Servizio cliente_servizio)

        {
            string query = "SELECT s.ServiceName, s.ServicePrice FROM barber.servizi s INNER JOIN barber.clienti_servizi cs ON s.Id = cs.ServizioId WHERE cs.ClienteId = @ClienteId";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("ClienteId", cliente_servizio.ClienteId));

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Console.WriteLine("Nessun servizio associato per il cliente specificato.");
                                return false;
                            }

                            while (reader.Read())
                            {
                                Console.WriteLine($"- {reader["ServiceName"]}: €{reader["ServicePrice"]}");
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore di connessione al database");
                return false;
            }
        }
    }
}

