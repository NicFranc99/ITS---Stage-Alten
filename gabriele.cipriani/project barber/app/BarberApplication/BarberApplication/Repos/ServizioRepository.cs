using BarberApplication.@class;
using BarberApplication.Interfaces;
using Microsoft.Data.SqlClient;

namespace BarberApplication.Repos
{
    public class ServizioRepository : IDatabaseServizio
    {
        readonly string _connectionstring = @"Server=tcp:its-alen-bari.database.windows.net,1433;Initial Catalog=its-alten-bari;Persist Security Info=False;User ID=nicola.francavilla;Password=2Vm&aic&AMo-#pxL;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";

        public bool CreateNewServizio(Servizio servizio)
        {
            string query = @"INSERT INTO barber.servizi (ServiceName, ServicePrice) VALUES (@ServiceName, @ServicePrice)";

            try
            {

                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {

                        sqlCommand.Parameters.Add(new SqlParameter("ServiceName", servizio.ServiceName));
                        sqlCommand.Parameters.Add(new SqlParameter("ServicePrice", servizio.ServicePrice));
                       

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
        

        public bool DeleteServizioByID(int idServizio)
        {
            string query = @"DELETE  FROM barber.servizi  WHERE Id=@Id";

            try
            {

                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", idServizio));

                        var rowsAffected=sqlCommand.ExecuteNonQuery();
                        if (rowsAffected>0)
                        {
                            return true;
                        }
                        return false;



                    }

                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore di connessione al database");
                return false;
            }
        }

        public bool GetAllServizi()
        {
            string query = @"SELECT * FROM  barber.servizi";

            try
            {


                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {
                        using SqlDataReader reader =
                        sqlCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($" Id:{reader["Id"]}\n Servizio:{reader["ServiceName"]}\n Prezzo:{reader["ServicePrice"]} euro \n ");
                        }


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

        public bool GetServizioByID(int idServizio)
        {
            string query = @"SELECT * FROM barber.servizi WHERE Id=@Id";

            try
            {

                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", idServizio));
                        using SqlDataReader reader = sqlCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($" Id:{reader["Id"]}\n Servizio:{reader["ServiceName"]}\n Prezzo:{reader["ServicePrice"]} euro\n");
                        }
                        if(!reader.HasRows)
                        {
                            
                            return false;
                        }


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

        public bool UpdateServizioByID(int idServizio, Servizio servizio)
        {
            string query = @"UPDATE barber.servizi SET ServiceName=@ServiceName, ServicePrice=@ServicePrice";

            try
            {

                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("idTastiera", idServizio));
                        sqlCommand.Parameters.Add(new SqlParameter("ServiceName", servizio.ServiceName));
                        sqlCommand.Parameters.Add(new SqlParameter("ServicePrice", servizio.ServicePrice));
                     

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
    }
}
