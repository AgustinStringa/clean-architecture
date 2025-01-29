using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
	public class CreateGenreCommand : IRequest<GenreResponse>
	{
		public string Name { get; set; }
		public CreateGenreCommand(string name)
		{
			Name = name;
		}
	}
}
