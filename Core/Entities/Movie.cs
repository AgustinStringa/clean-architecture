using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class Movie : Entity
	{
		public string Title { get; set; }

		[Column("director_name")]
		public string DirectorName { get; set; }

		[Column("release_year")]
		public int ReleaseYear { get; set; }

		public ICollection<Genre> Genres { get; set; } = new List<Genre>();

		[Column("synopsis")]
		public string Synopsis { get; set; }

		[Column("duration_seconds")]
		public int DurationSeconds { get; set; }
	}
}
