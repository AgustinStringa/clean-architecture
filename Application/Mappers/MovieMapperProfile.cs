using Application.Commands;
using Application.Responses;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
	public class MovieMapperProfile : Profile
	{
		public MovieMapperProfile() {
			CreateMap<Movie, MovieResponse>().ReverseMap();
			CreateMap<CreateMovieCommand, Movie>().ReverseMap();
			CreateMap<UpdateMovieCommand, Movie>().ReverseMap();
			CreateMap<Genre, GenreResponse>().ReverseMap();
			CreateMap<CreateGenreCommand, Genre>().ReverseMap();
			CreateMap<UpdateGenreCommand, Genre>().ReverseMap();
		}
	}
}
