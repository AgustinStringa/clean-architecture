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
		public string Name { get; set; }
		public string DirectorName { get; set; }
		public int ReleaseYear { get; set; }
	}
}
