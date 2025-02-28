using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Genres
{
	public class UpdateGenreCommand : IRequest<GenreResponse>
	{
		public string Name { get; set; }
		public int Id { get; set; }

		public UpdateGenreCommand(string name, int id)
		{
			Name = name;
			Id = id;
		}
	}
}
