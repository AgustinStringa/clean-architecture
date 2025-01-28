using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class MovieRepository : Repository<Movie>, IMovieRepository
	{
		public MovieRepository(MovieContext movieContext) : base(movieContext)
		{
		}

		public async Task<IEnumerable<Movie>> GetMoviesByDirectorName(string directorName)
		{
			//_movieContext is inherir from Repository<T>
			return await _movieContext.Movies.Where(m => m.DirectorName.Contains(directorName)).ToListAsync();
		}
	}
}
