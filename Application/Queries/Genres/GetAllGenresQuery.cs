﻿using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Genres
{
	public class GetAllGenresQuery : IRequest<IEnumerable<GenreResponse>>
	{
		public GetAllGenresQuery() { }
	}
}
