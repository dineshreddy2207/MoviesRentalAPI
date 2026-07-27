using Application.DTOs;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Repositories;
using Serilog;
using Core.Entities;

namespace Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MovieService> _logger;

        public MovieService(IMovieRepository movieRepository, IMapper mapper, ILogger<MovieService> logger)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MovieReadDto> GetMoviesByIdAsync(int movieId)
        {
            try
            {
                _logger.LogInformation("Fetching movie with ID: {MovieId}", movieId);

                var movie = await _movieRepository.GetByIdAsync(movieId);

                if (movie == null)
                {
                    _logger.LogWarning("Movie with ID: {MovieId} not found.", movieId);
                    return null;
                }

                return _mapper.Map<MovieReadDto>(movie);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching movie with ID: {MovieId}", movieId);
                throw;
            }
        }

        public async Task<IEnumerable<MovieReadDto>> GetAllMoviesAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all movies.");
                var movies = await  _movieRepository.GetAllAsync();
                return (_mapper.Map<IEnumerable<MovieReadDto>>(movies));

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all movies.");
                throw;
            }
        }

        public async Task<MovieReadDto> CreateMovieAsync(MovieCreateDto movieCreateDto)
        {
            try 
            {
                _logger.LogInformation("Creating a new movie with title: {Title}", movieCreateDto.Title);
                var movie= _mapper.Map<Movie>(movieCreateDto);
                var createdMovie = await _movieRepository.AddAsync(movie);
                _logger.LogInformation("Movie created with ID: {MovieId}", createdMovie.MovieId);
                return _mapper.Map<MovieReadDto>(createdMovie);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error creating movie: {Title}", movieCreateDto.Title);
                throw;
            }
        }

        public async Task<MovieReadDto> UpdateMovieAsync(MovieUpdateDto movieUpdateDto)
        {
            try
            {
                _logger.LogInformation("Updating movie with ID: {MovieId}", movieUpdateDto.MovieId);
                var movie = _mapper.Map<Movie>(movieUpdateDto);
                var updatedMovie = await _movieRepository.UpdateAsync(movie);
                _logger.LogInformation("Movie updated with ID: {MovieId}", updatedMovie.MovieId);
                return _mapper.Map<MovieReadDto>(updatedMovie);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating movie with ID: {MovieId}", movieUpdateDto.MovieId);
                throw;
            }
        }
            

        public async Task<bool> DeleteMovieAsync(int movieId)
        {
            try
            {
                _logger.LogInformation("Deleting movie with ID: {MovieId}", movieId);
                var result = await _movieRepository.DeleteAsync(movieId);

                if (result)
                {
                    _logger.LogInformation("Movie deleted successfully with ID: {MovieId}", movieId);
                }
                else
                {
                    _logger.LogWarning("Movie with ID {MovieId} not found for deletion", movieId);
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting movie with ID: {MovieId}", movieId);
                throw;
            }
        }



        public async Task<IEnumerable<MovieReadDto>> GetAvailableMoviesAsync(string genre)
        {
            try
            {
                _logger.LogInformation("Fetching movies by genre: {Genre}", genre);
                var movies = await _movieRepository.GetMoviesByGenreAsync(genre);
                return _mapper.Map<IEnumerable<MovieReadDto>>(movies);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching movies by genre: {Genre}", genre);
                throw;
            }

        }

        public async Task<IEnumerable<MovieReadDto>> GetMoviesByGenreAsync(string genre)
        {
            try
            {
                _logger.LogInformation("Fetching movies by genre: {Genre}", genre);
                var movies = await _movieRepository.GetMoviesByGenreAsync(genre);
                return _mapper.Map<IEnumerable<MovieReadDto>>(movies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching movies by genre: {Genre}", genre);
                throw;
            }
        }

        public async Task<IEnumerable<MovieReadDto>> GetAvailableMoviesAsync()
        {
            try
            {
                _logger.LogInformation("Fetching available movies");
                var movies = await _movieRepository.GetAvailableMoviesAsync();
                return _mapper.Map<IEnumerable<MovieReadDto>>(movies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching available movies");
                throw;
            }
        }
    }
}
