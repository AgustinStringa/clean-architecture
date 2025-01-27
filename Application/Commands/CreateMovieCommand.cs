﻿using MediatR;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
	public class CreateMovieCommand : IRequest<MovieResponse>
	{
		public string Name { get; set; }
		public string DirectorName { get; set; }
		public string ReleaseYear { get; set; }

		public CreateMovieCommand(string name, string directorName, string releaseYear) { 
			Name = name;
			DirectorName = directorName;
			ReleaseYear = releaseYear;
		}
	}
}
