using Npgsql;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Services.DataBase;

namespace TAF_TMS_C1onl.Tests.DataBase;

public class SimpleDataBaseTest
{
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
}