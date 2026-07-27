using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;
using Core.Entities;

namespace Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieReadDto>().ReverseMap();
            CreateMap<MovieCreateDto, Movie>().ReverseMap();
            CreateMap<MovieUpdateDto, Movie>();

            CreateMap<Customer, CustomerReadDto>();
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>();

            // Rental Mappings
            CreateMap<Rental, RentalReadDto>();
            CreateMap<RentalCreateDto, Rental>();
            CreateMap<RentalUpdateDto, Rental>();
        }
    }
}
