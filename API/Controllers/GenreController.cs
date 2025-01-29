using Application.Commands;
using Application.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class GenreController : ApiController
	{
		private readonly IMediator Mediator;
		public GenreController(IMediator mediator)
		{
			Mediator = mediator;
		}

		[HttpGet]
		[ProducesResponseType(200)]
		public async Task<ActionResult<IEnumerable<GenreResponse>>> GetAllGenres()
		{
			var query = new GetAllGenresQuery();
			var result = await Mediator.Send(query);
			return Ok(result);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(200)]
		public async Task<ActionResult<GenreResponse>> GetOneGenre([FromRoute] int id)
		{
			var query = new GetOneGenreQuery(id);
			var result = await Mediator.Send(query);
			return Ok(result);
		}

		[HttpPost]
		[ProducesResponseType(201)]
		public async Task<ActionResult<MovieResponse>> CreateGenre([FromBody] CreateGenreCommand command)
		{
			var result = await Mediator.Send(command);
			return Ok(result);
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(200)]
		public async Task<ActionResult<GenreResponse>> DeleteGenre([FromRoute] int id)
		{
			var query = new DeleteGenreCommand(id);
			var result = await Mediator.Send(query);
			return Ok(result);
		}

		[HttpPut("{id}")]
		[ProducesResponseType(200)]
		public async Task<ActionResult<GenreResponse>> UpdateGenre([FromRoute] int id, [FromBody] UpdateGenreCommand command)
		{
			if (command.Id != id) return BadRequest(new { Message = "The ID in the URL does not match the ID in the body." });
			var result = await Mediator.Send(command);
			return Ok(result);
		}
	}
}
