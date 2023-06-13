using NLog;
using Npgsql;
using TAF_TMS_C1onl.Models;

namespace TAF_TMS_C1onl.Services.DataBase;

public class CustomersService
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly NpgsqlConnection _connection;

    public CustomersService(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public void CreateTable()
    {
        var sqlQuery = "CREATE TABLE customers (" +
                       "id SERIAL PRIMARY KEY, " +
                       "firstname CHARACTER VARYING(30), " +
                       "lastname CHARACTER VARYING(30), " +
                       "email CHARACTER VARYING(30), " +
                       "age INTEGER" +
                       ");";
        
        using var cmd = new NpgsqlCommand(sqlQuery, _connection);
        cmd.ExecuteNonQuery();
    }

    public void DropTable()
    {
        var sqlQuery = "drop table if exists customers;";

        using var cmd = new NpgsqlCommand(sqlQuery, _connection);
        cmd.ExecuteNonQuery();
    }

    public List<Customers> GetAllCustomers()
    {
        var sqlQuery = "Select * FROM customers;";
        var actualList = new List<Customers>();
        
        //Retrieve all rows from our table
        using var cmd = new NpgsqlCommand(sqlQuery, _connection);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            var customer = new Customers()
            {
                Id = reader.GetInt32(0),
                FirstName = reader.GetString(reader.GetOrdinal("firstname")),
                LastName = reader.GetString(reader.GetOrdinal("lastname")),
                Email = reader.GetString(reader.GetOrdinal("email")),
                Age = reader.GetInt32(reader.GetOrdinal("age"))
            };
            
            _logger.Info(customer);
            actualList.Add(customer);
        }

        return actualList;
    }

    public void AddCustomer(Customers customer)
    {
        
    }
    
    public void DeleteCustomer(Customers customer)
    {
    
    }
}