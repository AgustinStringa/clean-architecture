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
	public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, GenreResponse>
	{
		private readonly IGenreRepository GenreRepository;
		public CreateGenreCommandHandler(IGenreRepository genreRepository)
		{
			GenreRepository = genreRepository;
		}

		public async Task<GenreResponse> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
		{
			var genreEntity = MovieMapper.Mapper.Map<Genre>(request);
			if (genreEntity is null)
			{
				throw new Exception("There is an issue with mapping.");
			}
			var newGenre = await GenreRepository.AddAsync(genreEntity);
			var response = MovieMapper.Mapper.Map<GenreResponse>(newGenre);
			return response;
		}
	}
}
