using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public interface IRentalService
    {
        Task<RentalReadDto> GetRentalByIdAsync(int rentalId);
        Task<IEnumerable<RentalReadDto>> GetAllRentalsAsync();
        Task<RentalReadDto> CreateRentalAsync(RentalCreateDto rentalCreateDto);
        Task<RentalReadDto> UpdateRentalAsync(RentalUpdateDto rentalUpdateDto);
        Task<bool> DeleteRentalAsync(int rentalId);
        Task<IEnumerable<RentalReadDto>> GetRentalsByCustomerAsync(int customerId);
        Task<IEnumerable<RentalReadDto>> GetOverdueRentalsAsync();
        Task<IEnumerable<RentalReadDto>> GetActiveRentalsAsync();
    }
}
