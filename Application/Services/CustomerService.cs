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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper, ILogger<CustomerService> logger)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CustomerReadDto> GetCustomerByIdAsync(int customerId)
        {
            try
            {
                _logger.LogInformation("Fetching customer with ID: {CustomerId}", customerId);
                var customer = await _customerRepository.GetByIdAsync(customerId);

                if (customer == null)
                {
                    _logger.LogWarning("Customer with ID {CustomerId} not found", customerId);
                    return null;
                }

                return _mapper.Map<CustomerReadDto>(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching customer with ID: {CustomerId}", customerId);
                throw;
            }
        }

        public async Task<IEnumerable<CustomerReadDto>> GetAllCustomersAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all customers");
                var customers = await _customerRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<CustomerReadDto>>(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all customers");
                throw;
            }
        }

        public async Task<CustomerReadDto> CreateCustomerAsync(CustomerCreateDto customerCreateDto)
        {
            try
            {
                _logger.LogInformation("Creating new customer: {Email}", customerCreateDto.Email);
                var customer = _mapper.Map<Customer>(customerCreateDto);
                var createdCustomer = await _customerRepository.AddAsync(customer);
                _logger.LogInformation("Customer created successfully with ID: {CustomerId}", createdCustomer.CustomerId);
                return _mapper.Map<CustomerReadDto>(createdCustomer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating customer: {Email}", customerCreateDto.Email);
                throw;
            }
        }

        public async Task<CustomerReadDto> UpdateCustomerAsync(CustomerUpdateDto customerUpdateDto)
        {
            try
            {
                _logger.LogInformation("Updating customer with ID: {CustomerId}", customerUpdateDto.CustomerId);
                var customer = _mapper.Map<Customer>(customerUpdateDto);
                var updatedCustomer = await _customerRepository.UpdateAsync(customer);
                _logger.LogInformation("Customer updated successfully with ID: {CustomerId}", updatedCustomer.CustomerId);
                return _mapper.Map<CustomerReadDto>(updatedCustomer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating customer with ID: {CustomerId}", customerUpdateDto.CustomerId);
                throw;
            }
        }

        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            try
            {
                _logger.LogInformation("Deleting customer with ID: {CustomerId}", customerId);
                var result = await _customerRepository.DeleteAsync(customerId);

                if (result)
                {
                    _logger.LogInformation("Customer deleted successfully with ID: {CustomerId}", customerId);
                }
                else
                {
                    _logger.LogWarning("Customer with ID {CustomerId} not found for deletion", customerId);
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting customer with ID: {CustomerId}", customerId);
                throw;
            }
        }

        public async Task<CustomerReadDto> GetCustomerByEmailAsync(string email)
        {
            try
            {
                _logger.LogInformation("Fetching customer by email: {Email}", email);
                var customer = await _customerRepository.GetCustomerByEmailAsync(email);

                if (customer == null)
                {
                    _logger.LogWarning("Customer with email {Email} not found", email);
                    return null;
                }

                return _mapper.Map<CustomerReadDto>(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching customer by email: {Email}", email);
                throw;
            }
        }

        public async Task<IEnumerable<CustomerReadDto>> GetActiveCustomersAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all active customers");
                var customers = await _customerRepository.GetActiveCustomersAsync();
                return _mapper.Map<IEnumerable<CustomerReadDto>>(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching active customers");
                throw;
            }
        }
    }
}
