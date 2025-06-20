internal interface IDatabaseClient
{
    bool CreateClient(Client client);
}
public class CustomerRepository : IDatabaseClient
{
    public bool CreateClient(Client client)
    {
        // Implementation for creating a client in the database  
        Console.WriteLine($"Client {client.FirstName} {client.LastName} created successfully.");
        return true;
    }
}
