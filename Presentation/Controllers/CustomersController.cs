using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ICustomerService customerService, ILogger<CustomersController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomerReadDto>> GetCustomerById(int id)
        {
            _logger.LogInformation("GET request for customer {CustomerId}", id);
            var customer = await _customerService.GetCustomerByIdAsync(id);

            if (customer == null)
                return NotFound(new { message = $"Customer with ID {id} not found" });

            return Ok(customer);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetAllCustomers()
        {
            _logger.LogInformation("GET request for all customers");
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CustomerReadDto>> CreateCustomer([FromBody] CustomerCreateDto customerCreateDto)
        {
            _logger.LogInformation("POST request to create customer: {Email}", customerCreateDto.Email);
            var createdCustomer = await _customerService.CreateCustomerAsync(customerCreateDto);
            return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.CustomerId }, createdCustomer);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomerReadDto>> UpdateCustomer([FromBody] CustomerUpdateDto customerUpdateDto)
        {
            _logger.LogInformation("PUT request to update customer {CustomerId}", customerUpdateDto.CustomerId);
            var updatedCustomer = await _customerService.UpdateCustomerAsync(customerUpdateDto);
            return Ok(updatedCustomer);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            _logger.LogInformation("DELETE request for customer {CustomerId}", id);
            var result = await _customerService.DeleteCustomerAsync(id);

            if (!result)
                return NotFound(new { message = $"Customer with ID {id} not found" });

            return NoContent();
        }

        [HttpGet("email/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomerReadDto>> GetCustomerByEmail(string email)
        {
            _logger.LogInformation("GET request for customer by email: {Email}", email);
            var customer = await _customerService.GetCustomerByEmailAsync(email);

            if (customer == null)
                return NotFound(new { message = $"Customer with email {email} not found" });

            return Ok(customer);
        }

        [HttpGet("active/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetActiveCustomers()
        {
            _logger.LogInformation("GET request for active customers");
            var customers = await _customerService.GetActiveCustomersAsync();
            return Ok(customers);
        }
    }
}
