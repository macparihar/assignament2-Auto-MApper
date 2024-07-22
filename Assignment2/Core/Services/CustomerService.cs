using Core.Interfaces;
using Core.Models;

namespace Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepo.GetAllCustomers();
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepo.GetCustomerById(id);
        }

        public void CreateCustomer(Customer customer)
        {
            _customerRepo.CreateCustomer(customer);
        }

        public bool UpdateCustomer(int id, Customer customer)
        {
            return _customerRepo.UpdateCustomer(id, customer);
        }

        public bool DeleteCustomer(int id)
        {
            return _customerRepo.DeleteCustomer(id);
        }
    }
}
