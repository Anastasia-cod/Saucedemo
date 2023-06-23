using NLog;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Models;

namespace TAF_TMS_C1onl.Tests.DataBase;

public class AdvancedDataBaseTest
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private DataBaseConnector _databaseConnector;
    
    [OneTimeSetUp]
    public void SetUp()
    {
        _databaseConnector = new DataBaseConnector();
    }

    [Test]
    public void SelectTest()
    {
        _logger.Info("Start Advanced SelectTest...");

        using (var dbConnector = _databaseConnector)
        {
            var customer1 = new Customers { FirstName = "Alex", LastName = "Sidorov", Email = "ps@test.com", Age = 34 };
            var customer2 = new Customers { FirstName = "Alina", LastName = "Petrov" };

            var entityCustomer1 = dbConnector.Customers.Add(customer1);
            var entityCustomer2 = dbConnector.Customers.Add(customer2);
            dbConnector.SaveChanges();
            _logger.Info(entityCustomer1.ToString);
            _logger.Info(entityCustomer2.ToString);

            _logger.Info($"FirstName: {dbConnector.Customers.Find(entityCustomer1.Entity.Id)?.FirstName}");
            
            var customers = dbConnector.Customers.ToList();

            foreach (var customer in customers)
            {
                _logger.Info($"{customer.FirstName}.{customer.LastName}");
                dbConnector.Customers.Remove(customer);
            }
            
            dbConnector.SaveChanges();
        }
    }
}