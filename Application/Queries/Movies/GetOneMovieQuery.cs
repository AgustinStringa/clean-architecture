using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Movies
{
	public class GetOneMovieQuery : IRequest<MovieResponse>
	{
		public int Id { get; set; }

		public GetOneMovieQuery(int id)
		{
			Id = id;
		}
	}
}
