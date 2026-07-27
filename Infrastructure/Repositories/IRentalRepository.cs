using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public interface IRentalRepository : IGenericRepository<Rental>
    {
        Task<IEnumerable<Rental>> GetRentalsByCustomerAsync(int customerId);

        Task<IEnumerable<Rental>> GetOverdueRentalsAsync();

        Task<IEnumerable<Rental>> GetActiveRentalsAsync();
    }
}
