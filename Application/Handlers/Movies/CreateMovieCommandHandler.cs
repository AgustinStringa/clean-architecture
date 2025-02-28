using Application.Responses;
using MediatR;
using Core.Entities;
using Application.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;
using Application.Commands.Movies;

namespace Application.Handlers.Movies
{
	public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, MovieResponse>
	{

		private readonly IMovieRepository MovieRepository;
		public CreateMovieCommandHandler(IMovieRepository movieRepository)
		{
			MovieRepository = movieRepository;
		}
		public async Task<MovieResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
		{
			var movieEntity = MovieMapper.Mapper.Map<Movie>(request);
			if (movieEntity is null)
			{
				throw new ApplicationException("There is an issue with mapping");
			}
			var newMovie = await MovieRepository.AddAsync(movieEntity);
			var movieResponse = MovieMapper.Mapper.Map<MovieResponse>(newMovie);
			return movieResponse;
		}
	}
}
