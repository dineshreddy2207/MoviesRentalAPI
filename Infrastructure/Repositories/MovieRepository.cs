using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieRentalDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Movie>> GetAvailableMoviesAsync()
        {
            return await _context.Movies.Where(m => m.AvailableStock > 0).ToListAsync();

        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(string genre)
        {
            return await _context.Movies.Where(m => m.Genre.ToLower() == genre.ToLower()).ToListAsync();
        }
    }
}
