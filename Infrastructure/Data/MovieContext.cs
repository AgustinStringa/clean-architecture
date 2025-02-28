using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
	public class MovieContext : DbContext
	{
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Actor> Actors { get; set; }
		public DbSet<Artist> Artists { get; set; }
		public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Movie>()
				.HasMany(m => m.Genres)
				.WithMany(g => g.Movies)
				.UsingEntity<Dictionary<string, object>>(
					"genres_movies",
					l => l.HasOne<Genre>().WithMany().HasForeignKey("id_genre"),
					r => r.HasOne<Movie>().WithMany().HasForeignKey("id_movie")
				);

			modelBuilder.Entity<Actor>().ToTable("actors");
		}
	}
}
