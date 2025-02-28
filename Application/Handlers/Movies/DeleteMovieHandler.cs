using Application.Commands.Movies;
using Application.Mappers;
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
	public class DeleteMovieHandler : IRequestHandler<DeleteMovieCommand, MovieResponse>
	{
		private readonly IMovieRepository MovieRepository;

		public DeleteMovieHandler(IMovieRepository movieRepository)
		{
			MovieRepository = movieRepository;
		}

		public async Task<MovieResponse> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
		{
			var movie = await MovieRepository.GetByIdAsync(request.Id);
			if (movie is null)
			{
				throw new KeyNotFoundException($"Movie with ID {request.Id} not found.");
			}
			await MovieRepository.DeleteAsync(movie);
			var response = MovieMapper.Mapper.Map<MovieResponse>(movie);
			return response;
		}
	}
}
