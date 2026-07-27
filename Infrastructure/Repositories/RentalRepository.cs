using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
        public class RentalRepository : GenericRepository<Rental>, IRentalRepository
        {
            public RentalRepository(MovieRentalDbContext context) : base(context)
            {
            }

            public async Task<IEnumerable<Rental>> GetRentalsByCustomerAsync(int customerId)
            {
                return await _context.Rentals
                    .Where(r => r.CustomerId == customerId)
                    .Include(r => r.Movie)
                    .ToListAsync();
            }

            public async Task<IEnumerable<Rental>> GetOverdueRentalsAsync()
            {
                return await _context.Rentals
                    .Where(r => r.DueDate < DateTime.UtcNow && r.Status == "Active")
                    .Include(r => r.Customer)
                    .Include(r => r.Movie)
                    .ToListAsync();
            }

            public async Task<IEnumerable<Rental>> GetActiveRentalsAsync()
            {
                return await _context.Rentals
                    .Where(r => r.Status == "Active")
                    .Include(r => r.Customer)
                    .Include(r => r.Movie)
                    .ToListAsync();
            }
        }
    }
