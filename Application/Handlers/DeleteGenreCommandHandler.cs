using Application.Commands;
using Application.Mappers;
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
	public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, GenreResponse>
	{
		private readonly IGenreRepository GenreRepository;

		public DeleteGenreCommandHandler(IGenreRepository genreRepository)
		{
			GenreRepository = genreRepository;
		}

		public async Task<GenreResponse> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
		{
			var genre = await GenreRepository.GetByIdAsync(request.Id);
			if (genre is null)
			{
				throw new KeyNotFoundException($"Genre with ID {request.Id} not found.");
			}
			await GenreRepository.DeleteAsync(genre);
			var response = MovieMapper.Mapper.Map<GenreResponse>(genre);
			return response;
		}
	}
}
