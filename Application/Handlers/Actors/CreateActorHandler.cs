using Application.Commands.Actors;
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

namespace Application.Handlers.Actors
{
	public class CreateActorHandler : IRequestHandler<CreateActorCommand, ActorResponse>
	{
		private readonly IActorRepository ActorRepository;
		public CreateActorHandler(IActorRepository actorRepository)
		{
			ActorRepository = actorRepository;
		}

		public async Task<ActorResponse> Handle(CreateActorCommand request, CancellationToken cancellationToken)
		{
			var actorEntity = MovieMapper.Mapper.Map<Actor>(request);
			if (actorEntity is null)
			{
				throw new Exception("There is an issue with mapping.");
			}
			var newActor = await ActorRepository.AddAsync(actorEntity);
			var response = MovieMapper.Mapper.Map<ActorResponse>(newActor);
			return response;
		}
	}
}
