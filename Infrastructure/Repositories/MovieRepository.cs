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
			//MovieContext is inherir from Repository<T>
			return await MovieContext.Movies.Where(m => m.DirectorName.Contains(directorName)).Include(m => m.Genres).ToListAsync();
		}

		public async Task<IEnumerable<Movie>> GetMoviesWithGenres()
		{
			return await MovieContext.Movies.Include(m => m.Genres).ToListAsync();
		}
	}
}
