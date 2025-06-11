// See https://aka.ms/new-console-template for more information


using Microsoft.Data.SqlClient;
using System;

//Connessione al database
const string connectionString =
@"Server=tcp:its-alen-bari.database.windows.net,1433;Initial Catalog=its-alten-bari;Persist Security Info=False;User ID=nicola.francavilla;Password=2Vm&aic&AMo-#pxL;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

// Provide the query string with a parameter placeholder.
const string selectQuery =
    @"SELECT Id, Name, Address, PostalCode from dbo.Customers
        WHERE Country = @country;";

const string insertQuery =
    @"INSERT INTO Customers (Id,Name,Address,PostalCode,Country,PhoneNumber) VALUES (@id,@name,@address,@postalCode,@country,@phoneNumber)";

// Specify the parameter value.
const string country = "Sweden";
Guid id = Guid.NewGuid();
const string postalCode = "76016";
const string phoneNumber = "32977355234";
const string name = "colino";
const string address = "Margherita di savoia";

// Create and open the connection in a using block. This
// ensures that all resources will be closed and disposed
// when the code exits.
SqlConnection connection = new(connectionString);
    // Create the Command and Parameter objects.
    SqlCommand command = new(insertQuery, connection);
    command.Parameters.AddWithValue("@country", country);
    command.Parameters.AddWithValue("@id", id);
    command.Parameters.AddWithValue("@name", name);
    command.Parameters.AddWithValue("@postalCode", postalCode);
    command.Parameters.AddWithValue("@address", address);
    command.Parameters.AddWithValue("@phoneNumber", phoneNumber);

// Open the connection in a try/catch block.
// Create and execute the DataReader, writing the result
// set to the console window.
try
    {
        connection.Open();
        //SqlDataReader reader = command.ExecuteReader();

        int rowNumber = command.ExecuteNonQuery();

    if(rowNumber > 0)
    {
        Console.WriteLine("Colonna inserita");
        Console.ReadLine();
    }

    Console.WriteLine("nesuna colonna inserita");
        //while (reader.Read())
       // {
        //    Console.WriteLine($"{reader[0]} {reader[1]} {reader[2]} {reader[3]}\n");
       // }
        //reader.Close();
    }
    catch (SqlException ex)
    {
        Console.WriteLine(ex.Message);
    }
    Console.ReadLine();
connection.Close();
