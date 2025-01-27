using Application.Responses;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
	public class GetMoviesByDirectorNameQuery : IRequest<IEnumerable<MovieResponse>>
	{
        public string DirectorName { get; set; }

        public GetMoviesByDirectorNameQuery(string directorName)
        {
            DirectorName = directorName;
        }
    }
}
