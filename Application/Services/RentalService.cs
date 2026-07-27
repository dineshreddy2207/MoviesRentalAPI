using Application.DTOs;
using AutoMapper;
using Core.Entities;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RentalService> _logger;

        public RentalService(
            IRentalRepository rentalRepository,
            IMovieRepository movieRepository,
            ICustomerRepository customerRepository,
            IMapper mapper,
            ILogger<RentalService> logger)
        {
            _rentalRepository = rentalRepository;
            _movieRepository = movieRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<RentalReadDto> GetRentalByIdAsync(int rentalId)
        {
            try
            {
                _logger.LogInformation("Fetching rental with ID: {RentalId}", rentalId);
                var rental = await _rentalRepository.GetByIdAsync(rentalId);

                if (rental == null)
                {
                    _logger.LogWarning("Rental with ID {RentalId} not found", rentalId);
                    return null;
                }

                return _mapper.Map<RentalReadDto>(rental);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching rental with ID: {RentalId}", rentalId);
                throw;
            }
        }

        public async Task<IEnumerable<RentalReadDto>> GetAllRentalsAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all rentals");
                var rentals = await _rentalRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<RentalReadDto>>(rentals);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all rentals");
                throw;
            }
        }

        public async Task<RentalReadDto> CreateRentalAsync(RentalCreateDto rentalCreateDto)
        {
            try
            {
                _logger.LogInformation("Creating new rental for customer {CustomerId} and movie {MovieId}",
                    rentalCreateDto.CustomerId, rentalCreateDto.MovieId);

                // Verify customer exists
                var customerExists = await _customerRepository.ExistsAsync(rentalCreateDto.CustomerId);
                if (!customerExists)
                {
                    _logger.LogWarning("Customer with ID {CustomerId} not found", rentalCreateDto.CustomerId);
                    throw new ArgumentException($"Customer with ID {rentalCreateDto.CustomerId} not found");
                }

                // Verify movie exists
                var movie = await _movieRepository.GetByIdAsync(rentalCreateDto.MovieId);
                if (movie == null)
                {
                    _logger.LogWarning("Movie with ID {MovieId} not found", rentalCreateDto.MovieId);
                    throw new ArgumentException($"Movie with ID {rentalCreateDto.MovieId} not found");
                }

                // Check stock availability
                if (movie.AvailableStock <= 0)
                {
                    _logger.LogWarning("Movie with ID {MovieId} is out of stock", rentalCreateDto.MovieId);
                    throw new ArgumentException($"Movie is out of stock");
                }

                var rental = _mapper.Map<Rental>(rentalCreateDto);
                rental.RentalPrice = movie.RentalPrice;
                rental.Status = "Active";
                rental.RentalDate = DateTime.UtcNow;

                var createdRental = await _rentalRepository.AddAsync(rental);

                // Update movie stock
                movie.AvailableStock--;
                await _movieRepository.UpdateAsync(movie);

                _logger.LogInformation("Rental created successfully with ID: {RentalId}", createdRental.RentalId);
                return _mapper.Map<RentalReadDto>(createdRental);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating rental for customer {CustomerId}",
                    rentalCreateDto.CustomerId);
                throw;
            }
        }

        public async Task<RentalReadDto> UpdateRentalAsync(RentalUpdateDto rentalUpdateDto)
        {
            try
            {
                _logger.LogInformation("Updating rental with ID: {RentalId}", rentalUpdateDto.RentalId);
                var rental = _mapper.Map<Rental>(rentalUpdateDto);
                var updatedRental = await _rentalRepository.UpdateAsync(rental);
                _logger.LogInformation("Rental updated successfully with ID: {RentalId}", updatedRental.RentalId);
                return _mapper.Map<RentalReadDto>(updatedRental);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating rental with ID: {RentalId}", rentalUpdateDto.RentalId);
                throw;
            }
        }

        public async Task<bool> DeleteRentalAsync(int rentalId)
        {
            try
            {
                _logger.LogInformation("Deleting rental with ID: {RentalId}", rentalId);
                var result = await _rentalRepository.DeleteAsync(rentalId);

                if (result)
                {
                    _logger.LogInformation("Rental deleted successfully with ID: {RentalId}", rentalId);
                }
                else
                {
                    _logger.LogWarning("Rental with ID {RentalId} not found for deletion", rentalId);
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting rental with ID: {RentalId}", rentalId);
                throw;
            }
        }

        public async Task<IEnumerable<RentalReadDto>> GetRentalsByCustomerAsync(int customerId)
        {
            try
            {
                _logger.LogInformation("Fetching rentals for customer {CustomerId}", customerId);
                var rentals = await _rentalRepository.GetRentalsByCustomerAsync(customerId);
                return _mapper.Map<IEnumerable<RentalReadDto>>(rentals);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching rentals for customer {CustomerId}", customerId);
                throw;
            }
        }

        public async Task<IEnumerable<RentalReadDto>> GetOverdueRentalsAsync()
        {
            try
            {
                _logger.LogInformation("Fetching overdue rentals");
                var rentals = await _rentalRepository.GetOverdueRentalsAsync();
                return _mapper.Map<IEnumerable<RentalReadDto>>(rentals);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching overdue rentals");
                throw;
            }
        }

        public async Task<IEnumerable<RentalReadDto>> GetActiveRentalsAsync()
        {
            try
            {
                _logger.LogInformation("Fetching active rentals");
                var rentals = await _rentalRepository.GetActiveRentalsAsync();
                return _mapper.Map<IEnumerable<RentalReadDto>>(rentals);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching active rentals");
                throw;
            }
        }
    }
}
