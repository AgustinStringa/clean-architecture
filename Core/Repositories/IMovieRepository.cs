using Core.Entities;
using Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
	public interface IMovieRepository : IRepository<Movie>
	{
		Task<IEnumerable<Movie>> GetMoviesByDirectorName(string directorName);
		Task<IEnumerable<Movie>> GetMoviesWithGenres();
	}
}
