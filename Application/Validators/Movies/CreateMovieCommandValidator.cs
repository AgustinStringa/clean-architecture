using Application.Commands.Movies;
using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Movies
{
	public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
	{
		public CreateMovieCommandValidator()
		{
			RuleFor(x => x.Name)
		   .NotEmpty().WithMessage("The title is required.")
		   .MaximumLength(255).WithMessage("The title must not exceed 255 characters.");

			RuleFor(x => x.DirectorName)
			.NotEmpty().WithMessage("The director's name is required.")
			.MaximumLength(255).WithMessage("The director's name must not exceed 255 characters.");

			RuleFor(x => x.ReleaseYear)
			.NotNull()
			.NotEmpty()
			.GreaterThan(0)
		   .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("The release date cannot be in the future.");
		}
	}
}
