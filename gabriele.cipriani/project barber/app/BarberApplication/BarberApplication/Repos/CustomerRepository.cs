using Microsoft.Data.SqlClient;

namespace BarberApplication.Repos
{
    public class CustomerRepository : IDatabaseClient
    {


        readonly string _connectionstring = @"Server=tcp:its-alen-bari.database.windows.net,1433;Initial Catalog=its-alten-bari;Persist Security Info=False;User ID=nicola.francavilla;Password=2Vm&aic&AMo-#pxL;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";



        public bool CreateNewClient(Client client)
        {
            string query = @"INSERT INTO barber.clienti  (FirstName, LastName, Age, Email, PhoneNumber) VALUES(@FirstName,@LastName, @Age,@Email, @PhoneNumber)";

            try
            {

                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {

                        sqlCommand.Parameters.Add(new SqlParameter("FirstName", client.FirstName));
                        sqlCommand.Parameters.Add(new SqlParameter("LastName", client.LastName));
                        sqlCommand.Parameters.Add(new SqlParameter("Age", client.Age));
                        sqlCommand.Parameters.Add(new SqlParameter("Email", client.Email));
                        sqlCommand.Parameters.Add(new SqlParameter("PhoneNumber", client.PhoneNumber));

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


        public bool DeleteClientByID(int idTastiera)
        {


            string query = @"DELETE  FROM barber.clienti  WHERE Id=@Id";

            try
            {

                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", idTastiera));
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


        public bool GetAllClient()
        {
            string query = @"SELECT * FROM  barber.clienti";

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
                            Console.WriteLine($" Id:{reader["Id"]}\n Nome:{reader["FirstName"]}\n Cognome:{reader["LastName"]}\n Età:{reader["Age"]}\n Email:{reader["Email"]}\n Numero di Telefono:{reader["PhoneNumber"]}");
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

        public bool GetClientByID(int idTastiera)
        {
            string query = @"SELECT * FROM barber.clienti WHERE Id=@Id";

            try
            {

                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", idTastiera));
                        using SqlDataReader reader = sqlCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($" Id:{reader["Id"]}\n Nome:{reader["FirstName"]}\n Cognome:{reader["LastName"]}\n Età:{reader["Age"]}\n Email:{reader["Email"]}\n Numero di Telefono:{reader["PhoneNumber"]}");
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

        //public bool UpdateClientByID()
        //{
        //    throw new NotImplementedException();
        //}

    }
}

