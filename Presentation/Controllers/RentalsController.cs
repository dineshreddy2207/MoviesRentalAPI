using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        private readonly ILogger<RentalsController> _logger;

        public RentalsController(IRentalService rentalService, ILogger<RentalsController> logger)
        {
            _rentalService = rentalService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RentalReadDto>> GetRentalById(int id)
        {
            _logger.LogInformation("GET request for rental {RentalId}", id);
            var rental = await _rentalService.GetRentalByIdAsync(id);

            if (rental == null)
                return NotFound(new { message = $"Rental with ID {id} not found" });

            return Ok(rental);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<RentalReadDto>>> GetAllRentals()
        {
            _logger.LogInformation("GET request for all rentals");
            var rentals = await _rentalService.GetAllRentalsAsync();
            return Ok(rentals);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RentalReadDto>> CreateRental([FromBody] RentalCreateDto rentalCreateDto)
        {
            _logger.LogInformation("POST request to create rental for customer {CustomerId}", rentalCreateDto.CustomerId);
            var createdRental = await _rentalService.CreateRentalAsync(rentalCreateDto);
            return CreatedAtAction(nameof(GetRentalById), new { id = createdRental.RentalId }, createdRental);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RentalReadDto>> UpdateRental([FromBody] RentalUpdateDto rentalUpdateDto)
        {
            _logger.LogInformation("PUT request to update rental {RentalId}", rentalUpdateDto.RentalId);
            var updatedRental = await _rentalService.UpdateRentalAsync(rentalUpdateDto);
            return Ok(updatedRental);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRental(int id)
        {
            _logger.LogInformation("DELETE request for rental {RentalId}", id);
            var result = await _rentalService.DeleteRentalAsync(id);

            if (!result)
                return NotFound(new { message = $"Rental with ID {id} not found" });

            return NoContent();
        }

        [HttpGet("customer/{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<RentalReadDto>>> GetRentalsByCustomer(int customerId)
        {
            _logger.LogInformation("GET request for rentals by customer {CustomerId}", customerId);
            var rentals = await _rentalService.GetRentalsByCustomerAsync(customerId);
            return Ok(rentals);
        }

        [HttpGet("overdue/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<RentalReadDto>>> GetOverdueRentals()
        {
            _logger.LogInformation("GET request for overdue rentals");
            var rentals = await _rentalService.GetOverdueRentalsAsync();
            return Ok(rentals);
        }

        [HttpGet("active/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<RentalReadDto>>> GetActiveRentals()
        {
            _logger.LogInformation("GET request for active rentals");
            var rentals = await _rentalService.GetActiveRentalsAsync();
            return Ok(rentals);
        }

    }
}
