using Application.Commands.Actors;
using Application.Commands.Genres;
using Application.Handlers.Actors;
using Application.Queries.Actors;
using Application.Queries.Genres;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

	public class ActorController : ApiController
	{
		private readonly IMediator Mediator;

		public ActorController(IMediator mediator)
		{
			Mediator = mediator;
		}

		[HttpGet]
		[ProducesResponseType(200)]
		public async Task<ActionResult<IEnumerable<ActorResponse>>> GetAllActors()
		{
			var query = new GetAllActorsQuery();
			var result = await Mediator.Send(query);
			return Ok(result);
		}

		[HttpPost]
		[ProducesResponseType(200)]
		public async Task<ActionResult<ActorResponse>> CreateActor([FromBody] CreateActorCommand command)
		{
			var result = await Mediator.Send(command);
			return Ok(result);
		}
	}
}