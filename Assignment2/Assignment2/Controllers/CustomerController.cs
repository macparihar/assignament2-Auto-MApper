using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet("GetAllCustomers")]
        public ActionResult<List<CustomerDto>> GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            var customerDtos = _mapper.Map<List<CustomerDto>>(customers);
            return Ok(customerDtos);
        }

        [HttpGet("GetCustomerById/{id}")]
        public ActionResult<CustomerDto> GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NoContent();
            }
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return Ok(customerDto);
        }

        [HttpPost]
        public ActionResult<CustomerDto> CreateCustomer([FromBody] CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            _customerService.CreateCustomer(customer);
            var createdCustomerDto = _mapper.Map<CustomerDto>(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, createdCustomerDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            if (!_customerService.UpdateCustomer(id, customer))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            if (!_customerService.DeleteCustomer(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
