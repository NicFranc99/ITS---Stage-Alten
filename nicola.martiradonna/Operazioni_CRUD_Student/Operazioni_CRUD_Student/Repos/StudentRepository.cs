using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Operazioni_CRUD_Student.Interfaces;
using System.Data.SqlClient;

namespace Operazioni_CRUD_Student.Repos
{
    public class StudentRepository : IStudentRepository
    {
        readonly string _connectionstring = @"Server=tcp:its-alen-bari.database.windows.net,1433;Initial Catalog=its-alten-bari;Persist Security Info=False;User ID=nicola.francavilla;Password=2Vm&aic&AMo-#pxL;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
        public bool SelectAllStudent()
        {
            string query = "SELECT * FROM Student ORDER BY Id";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Console.WriteLine("\nStudent:\n");
                            Console.WriteLine($"ID: {reader.GetInt32(0)} Name: {reader.GetString(1)} Surname: {reader.GetString(2)} Age: {reader.GetInt32(3)} Country: {reader.GetString(4)}");
                        }
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("!!No rows with that condiction!!");
                            return false;
                        }

                    }
                }
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Query non riuscita");
                return false;
            }

        }

        public bool SelectStudentById(int id)
        {
            //command.Parameters.AddWithValue("@",id)
            string query = "SELECT * FROM Student WHERE Id=@id ORDER BY Id";
                
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
                            Console.WriteLine($"Studente trovato con id: {id}");
                            Console.WriteLine($"Id: {reader.GetInt32(0)} Name: {reader.GetString(1)} Surname: {reader.GetString(2)} Age: {reader.GetInt32(3)} Country: {reader.GetString(4)}");
                        }
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("!!No rows with that condiction!!");
                            return false;
                        }

                    }
                }
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Query non riuscita");
                return false;
            }


        }

        public bool CreateNewStudent(Student student)
        {
            string query = @"INSERT INTO Student (Id,Name,Surname,Age,Country)
                               VALUES (@id,@name,@surname,@age,@country)";
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@id", student.Id);
                        command.Parameters.AddWithValue("@name", student.Name);
                        command.Parameters.AddWithValue("@surname", student.Surname);
                        command.Parameters.AddWithValue("@age", student.Age);
                        command.Parameters.AddWithValue("@country", student.Country);


                         int rowsAffect = command.ExecuteNonQuery();

                        if (rowsAffect > 0)
                        {
                            Console.WriteLine($"Righe colpite: {rowsAffect}");
                            return true;
                        }
                        else
                        {
                            return false;
                        }


                    }
                }

            }
            catch(SqlException ex) 
            {
                Console.WriteLine("Query non riuscita");
                return false;
            }
        }
        public bool UpdateStudent(int id, Student updatedStudent)
        {
            string query = @"UPDATE Student
                           SET Id=@id, Name= @name, Surname=@surname, Age= @age,Country=@country
                            WHERE Id=@idUpdate";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@id", updatedStudent.Id);
                        command.Parameters.AddWithValue("@name", updatedStudent.Name);
                        command.Parameters.AddWithValue("@surname", updatedStudent.Surname);
                        command.Parameters.AddWithValue("@age", updatedStudent.Age);
                        command.Parameters.AddWithValue("@country", updatedStudent.Country);
                        command.Parameters.AddWithValue("@idUpdate", id);

                        int rowsAffect = command.ExecuteNonQuery();

                        if (rowsAffect>0)
                        {
                            Console.WriteLine($"Righe affette: {rowsAffect}");
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Query non riuscita");
                return false;
            }



        }
        public bool DeleteStudentById(int id)
        {
            string query = "DELETE FROM Student WHERE Id=@id";

            try
            {
                using(SqlConnection  connection = new SqlConnection(_connectionstring))
                {
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@id", id);

                        var rowsAffected= command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Le righe affette sono: {rowsAffected}");
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Query non riuscita");
                return false;
            }
        }
    }
}
