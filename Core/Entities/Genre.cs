﻿using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class Genre : Entity
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public ICollection<Movie> Movies { get; set; } = new List<Movie>();
	}
}
