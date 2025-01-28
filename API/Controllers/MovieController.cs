using Application.Commands;
using Application.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class MovieController : ApiController
	{
		private readonly IMediator Mediator;
		public MovieController(IMediator mediator)
		{
			Mediator = mediator;
		}

		[HttpGet]
		[ProducesResponseType(200)]
		public async Task<ActionResult<IEnumerable<MovieResponse>>> GetMoviesByDirectorName(string directorName)
		{
			var query = new GetMoviesByDirectorNameQuery(directorName);
			var result = await Mediator.Send(query);
			return Ok(result);
		}

		[HttpPost]
		[ProducesResponseType(201)]
		public async Task<ActionResult<MovieResponse>> CreateMovie([FromBody] CreateMovieCommand command)
		{
			var result = await Mediator.Send(command);
			return Ok(result);
		}
	}
}
