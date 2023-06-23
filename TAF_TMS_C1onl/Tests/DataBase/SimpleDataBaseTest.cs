using NLog;
using Npgsql;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Services.DataBase;

namespace TAF_TMS_C1onl.Tests.DataBase;

public class SimpleDataBaseTest
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    
    private SimpleDBConnector _simpleDbConnector;
    private CustomersService _customersService;

    [OneTimeSetUp]
    public void SetUp()
    {
        _simpleDbConnector = new SimpleDBConnector();
        _customersService = new CustomersService(_simpleDbConnector.Connection); 
    }
    
    [OneTimeTearDown]
    public void TearDown()
    {
        _simpleDbConnector.CloseConnection();
    }
    
    [Test]
    public void GetAllCustomersTest()
    {
        var customersList = _customersService.GetAllCustomers();
        
        Assert.That(customersList, Has.Count.GreaterThanOrEqualTo(2));
    }
    
    [Test]
    public void AddCustomerTest()
    {
        _logger.Info("AddCustomer Test started ...");
        
        int affectedRows = _customersService.AddCustomer(new Customers
        {
            FirstName = "Petr",
            LastName = "Sidorov",
            Email = "ps@test.com",
            Age = 34
            
        });
        
        Assert.That(affectedRows, Is.EqualTo(1));
        
        _logger.Info("AddCustomer Test ended ...");
    }
    
    [Test]
    public void DeleteCustomerTest()
    {
        _logger.Info("AddCustomer Test started ...");
        
        int affectedRows = _customersService.DeleteCustomer("Petr", "Sidorov");
        
        Assert.That(affectedRows, Is.EqualTo(1));
        
        _logger.Info("AddCustomer Test ended ...");
    }
}