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
	public class GetOneGenreHandler : IRequestHandler<GetOneGenreQuery, GenreResponse>
	{
		private readonly IGenreRepository GenreRepository;

		public GetOneGenreHandler(IGenreRepository genreRepository)
		{
			GenreRepository = genreRepository;
		}

		public async Task<GenreResponse> Handle(GetOneGenreQuery request, CancellationToken cancellationToken)
		{
			var genre = await GenreRepository.GetByIdAsync(request.Id);
			if (genre == null)
			{
				throw new KeyNotFoundException($"Genre with ID {request.Id} not found.");
			}
			var response = MovieMapper.Mapper.Map<GenreResponse>(genre);
			return response;
		}
	}
}
