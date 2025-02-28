using Application.Commands.Genres;
using Application.Mappers;
using Application.Responses;
using Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Genres
{
	public class UpdateGenreHandler : IRequestHandler<UpdateGenreCommand, GenreResponse>
	{
		private readonly IGenreRepository GenreRepository;

		public UpdateGenreHandler(IGenreRepository genreRepository)
		{
			GenreRepository = genreRepository;
		}

		public async Task<GenreResponse> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
		{
			var genre = await GenreRepository.GetByIdAsync(request.Id);
			if (genre is null)
			{
				throw new KeyNotFoundException($"Genre with ID {request.Id} not found.");
			}
			MovieMapper.Mapper.Map(request, genre);
			var response = MovieMapper.Mapper.Map<GenreResponse>(genre);
			return response;
		}
	}
}
