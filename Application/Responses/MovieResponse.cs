using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
	public class MovieResponse
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string DirectorName { get; set; }
		public int ReleaseYear { get; set; }
		public ICollection<GenreResponse> Genres { get; set; } = new List<GenreResponse>();
		public string Synopsis { get; set; }
		public int DurationSeconds { get; set; }
		public TimeSpan? Duration => TimeSpan.FromSeconds(DurationSeconds);
	}
}
