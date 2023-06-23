using NLog;
using Npgsql;
using TAF_TMS_C1onl.Models;

namespace TAF_TMS_C1onl.DAO;

public class CustomersDao : ICustomersDao
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    
    private NpgsqlConnection _connection;

    public CustomersDao(NpgsqlConnection connection)
    {
        _connection = connection;
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

    public Customers GetById(int id)
    {
        var sqlQuery = "Select * FROM customers WHERE id = @id;";
        
        using (var cmd = new NpgsqlCommand(sqlQuery, _connection))
        {
            cmd.Parameters.AddWithValue("id", id);
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Customers()
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(reader.GetOrdinal("firstname")),
                        LastName = reader.GetString(reader.GetOrdinal("lastname")),
                        Email = reader.GetString(reader.GetOrdinal("email")),
                        Age = reader.GetInt32(reader.GetOrdinal("age"))
                    };
                }
            }
        }

        return null;

    }

    public int Add(Customers customer)
    {
        throw new NotImplementedException();
    }

    public int Delete(int? id)
    {
        throw new NotImplementedException();
    }
}