using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
	public class DeleteGenreCommand : IRequest<GenreResponse>
	{
		public int Id { get; set; }

		public DeleteGenreCommand(int id)
		{
			Id = id;
		}
	}
}
