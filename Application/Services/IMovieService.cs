using System;
using System.Collections.Generic;
using System.Text;

using Application.DTOs;

namespace Application.Services
{
    public interface IMovieService
    {
        Task<MovieReadDto> GetMoviesByIdAsync(int movieId);
        Task<IEnumerable<MovieReadDto>> GetAllMoviesAsync();
        Task<MovieReadDto> CreateMovieAsync(MovieCreateDto movieCreateDto);
        Task<MovieReadDto> UpdateMovieAsync(MovieUpdateDto movieUpdateDto);

        Task<bool> DeleteMovieAsync(int movieId);

        Task<IEnumerable<MovieReadDto>> GetMoviesByGenreAsync(string genre);
        Task<IEnumerable<MovieReadDto>> GetAvailableMoviesAsync();
    }
}
