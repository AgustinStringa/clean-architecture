using Application.Mappers;
using Application.Queries.Movies;
using Application.Responses;
using Core.Entities;
using Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Movies
{
	public class GetMoviesByDirectorNameHandler : IRequestHandler<GetMoviesByDirectorNameQuery, IEnumerable<MovieResponse>>
	{
		private readonly IMovieRepository MovieRepository;

		public GetMoviesByDirectorNameHandler(IMovieRepository movieRepository)
		{
			MovieRepository = movieRepository;
		}
		public async Task<IEnumerable<MovieResponse>> Handle(GetMoviesByDirectorNameQuery request, CancellationToken cancellationToken)
		{
			var movieEntities = await MovieRepository.GetMoviesByDirectorName(request.DirectorName);
			if (movieEntities is null)
			{
				throw new ApplicationException("There is an issue with the movies");
			}
			var movieResponses = MovieMapper.Mapper.Map<IEnumerable<MovieResponse>>(movieEntities);
			return movieResponses;
			//IEnumerable<MovieResponse> movieResponses = [];
			//foreach (var movieEntity in movieEntities) {
			//	var movieResponse = MovieMapper.Mapper.Map<MovieResponse>(movieEntity);
			//	movieResponses.Append<MovieResponse>(movieResponse);
			//}
			//return movieResponses;
		}
	}
}
