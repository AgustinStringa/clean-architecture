using Application.Mappers;
using Core.Repositories.Base;
using Core.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using API.Middlewares;
using FluentValidation;
using Application.Validators;
using FluentValidation.AspNetCore;
using MediatR;
using System.Text.Json.Serialization;

namespace WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddAuthorization();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.Configure<RouteOptions>(opt => opt.LowercaseUrls = true);
			builder.Services.AddSwaggerGen();
			builder.Services.AddControllers()
						.AddJsonOptions(options =>
						{
							options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
						});
			;
			builder.Services.AddFluentValidationAutoValidation(
				cfg => { cfg.DisableDataAnnotationsValidation = true; }
				).AddFluentValidationClientsideAdapters();
			builder.Services.AddDbContext<MovieContext>(ctx => ctx.UseSqlServer(
				builder.Configuration.GetConnectionString("MovieConnection")
				), ServiceLifetime.Singleton);
			builder.Services.AddAutoMapper(typeof(MovieMapperProfile));
			//problems with mediatR and executing project or project that install mediatR
			//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
			builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
			builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			builder.Services.AddTransient<IMovieRepository, MovieRepository>();
			builder.Services.AddTransient<IGenreRepository, GenreRepository>();
			builder.Services.AddTransient<IActorRepository, ActorRepository>();

			builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
			builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.UseMiddleware<ExceptionMiddleware>();
			app.MapControllers();
			app.Run();
		}
	}
}
