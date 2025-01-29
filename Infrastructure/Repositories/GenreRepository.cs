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
	public class GenreRepository : Repository<Genre>, IGenreRepository
	{
		public GenreRepository(MovieContext movieContext) : base(movieContext) {}
	}
}
