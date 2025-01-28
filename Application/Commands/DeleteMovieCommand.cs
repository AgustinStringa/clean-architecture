using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
	public class DeleteMovieCommand : IRequest<MovieResponse>
	{
		public int Id { get; set; }
		public DeleteMovieCommand(int id)
		{
			Id = id;
		}
	}
}
