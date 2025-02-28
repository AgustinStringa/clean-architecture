using Application.Commands.Movies;
using Application.Queries.Movies;
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
		public async Task<ActionResult<IEnumerable<MovieResponse>>> GetAllMovies()
		{
			var query = new GetAllMoviesQuery();
			var result = await Mediator.Send(query);
			return Ok(result);
		}

		[HttpGet("by-director")]
		[ProducesResponseType(200)]
		public async Task<ActionResult<IEnumerable<MovieResponse>>> GetMoviesByDirectorName([FromQuery] string directorName)
		{
			var query = new GetMoviesByDirectorNameQuery(directorName);
			var result = await Mediator.Send(query);
			return Ok(result);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(200)]
		public async Task<ActionResult<IEnumerable<MovieResponse>>> GetOneMovie([FromRoute] int id)
		{
			var query = new GetOneMovieQuery(id);
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

		[HttpDelete("{id}")]
		[ProducesResponseType(200)]
		public async Task<ActionResult<IEnumerable<MovieResponse>>> DeleteMovie([FromRoute] int id)
		{
			var query = new DeleteMovieCommand(id);
			var result = await Mediator.Send(query);
			return Ok(result);
		}

		[HttpPut("{id}")]
		[ProducesResponseType(200)]
		public async Task<ActionResult<IEnumerable<MovieResponse>>> UpdateMovie([FromBody] UpdateMovieCommand command, [FromRoute] int id)
		{
			if (command.Id != id) return BadRequest(new { Message = "The ID in the URL does not match the ID in the body." });
			var result = await Mediator.Send(command);
			return Ok(result);
		}
	}
}
