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
	public class GetAllGenresHandler : IRequestHandler<GetAllGenresQuery, IEnumerable<GenreResponse>>
	{
		private readonly IGenreRepository GenreRepository;

		public GetAllGenresHandler(IGenreRepository genreRepository)
		{
			GenreRepository = genreRepository;
		}

		public async Task<IEnumerable<GenreResponse>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
		{
			var genres = await GenreRepository.GetAllAsync();
			var response = MovieMapper.Mapper.Map<IEnumerable<GenreResponse>>(genres);
			return response;
		}
	}
}
