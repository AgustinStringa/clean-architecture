using Application.Mappers;
using Application.Queries.Actors;
using Application.Responses;
using Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Actors
{
	public class GetAllActorsHandler : IRequestHandler<GetAllActorsQuery, IEnumerable<ActorResponse>>
	{
		private readonly IActorRepository ActorRepository;
		public GetAllActorsHandler(IActorRepository actorRepository)
		{
			ActorRepository = actorRepository;
		}
		public async Task<IEnumerable<ActorResponse>> Handle(GetAllActorsQuery request, CancellationToken cancellationToken)
		{
			var actors = await ActorRepository.GetAllAsync();
			var response = MovieMapper.Mapper.Map<IEnumerable<ActorResponse>>(actors);
			return response;
		}
	}
}
