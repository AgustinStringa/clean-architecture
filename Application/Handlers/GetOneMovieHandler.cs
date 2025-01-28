using Application.Mappers;
using Application.Queries;
using Application.Responses;
using Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
	public class GetOneMovieHandler : IRequestHandler<GetOneMovieQuery, MovieResponse>
	{
		private readonly IMovieRepository MovieRepository;
		public GetOneMovieHandler(IMovieRepository movieRepository) {
			MovieRepository = movieRepository;
		}
		public async Task<MovieResponse> Handle(GetOneMovieQuery request, CancellationToken cancellationToken)
		{

			var movie = await MovieRepository.GetByIdAsync(request.Id);
			if (movie is null) {
				throw new KeyNotFoundException($"Movie with ID {request.Id} not found.");
			}
			var response = MovieMapper.Mapper.Map<MovieResponse>(movie);
			return response;
		}
	}
}
