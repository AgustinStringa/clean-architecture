using Application.Commands.Actors;
using Application.Commands.Genres;
using Application.Commands.Movies;
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
		public MovieMapperProfile()
		{
			CreateMap<Movie, MovieResponse>().ReverseMap();
			CreateMap<CreateMovieCommand, Movie>().ReverseMap();
			CreateMap<UpdateMovieCommand, Movie>().ReverseMap();
			CreateMap<Genre, GenreResponse>().ReverseMap();
			CreateMap<CreateGenreCommand, Genre>().ReverseMap();
			CreateMap<UpdateGenreCommand, Genre>().ReverseMap();
			CreateMap<ActorResponse, Actor>().ReverseMap();
			CreateMap<CreateActorCommand, Actor>().ReverseMap();
		}
	}
}
