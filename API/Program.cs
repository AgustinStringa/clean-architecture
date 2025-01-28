using Application.Mappers;
using Core.Repositories.Base;
using Core.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddAuthorization();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddControllers();
			builder.Services.AddDbContext<MovieContext>(ctx => ctx.UseSqlServer(
				builder.Configuration.GetConnectionString("MovieConnection")
				), ServiceLifetime.Singleton);
			builder.Services.AddAutoMapper(typeof(MovieMapperProfile));
			//problems with mediatR and executing project or project that install mediatR
			//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
			builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
			builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			builder.Services.AddTransient<IMovieRepository, MovieRepository>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}
