using Core.Models;

namespace Core.Interfaces
{
    public interface ICustomerRepo
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void CreateCustomer(Customer customer);
        bool UpdateCustomer(int id, Customer customer);
        bool DeleteCustomer(int id);
    }
}
