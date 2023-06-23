using TAF_TMS_C1onl.Models;

namespace TAF_TMS_C1onl.DAO;

public interface ICustomersDao
{
    List<Customers> GetAllCustomers();
    Customers GetById(int id);
    int Add(Customers customer);
    int Delete(int? id);
    
}