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
        public string Name { get; set; }
		[Column("director_name")]

		public string DirectorName { get; set; }

        [Column("release_year")]
        public int ReleaseYear { get; set; }
    }
}
