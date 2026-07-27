using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public interface ICustomerService
    {
        Task<CustomerReadDto> GetCustomerByIdAsync(int customerId);
        Task<IEnumerable<CustomerReadDto>> GetAllCustomersAsync();
        Task<CustomerReadDto> CreateCustomerAsync(CustomerCreateDto customerCreateDto);
        Task<CustomerReadDto> UpdateCustomerAsync(CustomerUpdateDto customerUpdateDto);
        Task<bool> DeleteCustomerAsync(int customerId);
        Task<CustomerReadDto> GetCustomerByEmailAsync(string email);
        Task<IEnumerable<CustomerReadDto>> GetActiveCustomersAsync();
    }
}
