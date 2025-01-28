using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
	public class UpdateMovieCommand : IRequest<MovieResponse>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string DirectorName { get; set; }
		public int ReleaseYear { get; set; }

		public UpdateMovieCommand(int id, string name, string directorName, int releaseYear)
		{
			Id = id;
			Name = name;
			DirectorName = directorName;
			ReleaseYear = releaseYear;
		}
	}
}
