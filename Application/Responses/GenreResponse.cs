using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
	public class GenreResponse
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<MovieResponse> Movies = new List<MovieResponse>();
	}
}
