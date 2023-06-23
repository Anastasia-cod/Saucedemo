using NLog;
using Npgsql;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.DAO;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Services.DataBase;

namespace TAF_TMS_C1onl.Tests.DataBase;

public class DAOTest
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    
    private SimpleDBConnector _simpleDbConnector;
    private CustomersDao _customersDao;

    [OneTimeSetUp]
    public void SetUp()
    {
        _simpleDbConnector = new SimpleDBConnector();
        _customersDao = new CustomersDao(_simpleDbConnector.Connection); 
    }
    
    [OneTimeTearDown]
    public void TearDown()
    {
        _simpleDbConnector.CloseConnection();
    }
    
    [Test]
    public void GetAllCustomersTest()
    {
        var customersList = _customersDao.GetAllCustomers();
        
        Assert.That(customersList, Has.Count.GreaterThanOrEqualTo(1));
    }
    
    [Test]
     public void FindCustomerByIdTest()
     {
         _logger.Info("Find Customer Test started ...");

         _logger.Info($"Find Customer: {_customersDao.GetById(16).FirstName}");

         _logger.Info("Find Customer Test ended ...");
     }
}