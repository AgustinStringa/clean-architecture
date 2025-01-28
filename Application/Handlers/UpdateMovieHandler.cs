using Application.Commands;
using Application.Mappers;
using Application.Responses;
using Core.Entities;
using Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
	public class UpdateMovieHandler : IRequestHandler<UpdateMovieCommand, MovieResponse>
	{
		private readonly IMovieRepository MovieRepository;

		public UpdateMovieHandler(IMovieRepository movieRepository)
		{
			MovieRepository = movieRepository;
		}

		public async Task<MovieResponse> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
		{
			var movie = await MovieRepository.GetByIdAsync(request.Id);
			if (movie is null) throw new KeyNotFoundException($"Movie with ID {request.Id} not found.");
			MovieMapper.Mapper.Map(request, movie);
			await MovieRepository.UpdateAsync(movie);
			var response = MovieMapper.Mapper.Map<MovieResponse>(movie);
			return response;
		}
	}
}
