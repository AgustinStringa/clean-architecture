using Application.Mappers;
using Application.Queries.Movies;
using Application.Responses;
using Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Movies
{
	public class GetAllMoviesHandler : IRequestHandler<GetAllMoviesQuery, IEnumerable<MovieResponse>>
	{
		private readonly IMovieRepository MovieRepository;

		public GetAllMoviesHandler(IMovieRepository movieRepository)
		{
			MovieRepository = movieRepository;
		}
		public async Task<IEnumerable<MovieResponse>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
		{
			var movies = await MovieRepository.GetMoviesWithGenres();
			var response = MovieMapper.Mapper.Map<IEnumerable<MovieResponse>>(movies);
			return response;
		}
	}
}
