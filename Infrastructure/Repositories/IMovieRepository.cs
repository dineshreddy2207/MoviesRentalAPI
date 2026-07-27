using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Infrastructure.Repositories
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetMoviesByGenreAsync(string genre);
        Task<IEnumerable<Movie>> GetAvailableMoviesAsync();
    }
}
