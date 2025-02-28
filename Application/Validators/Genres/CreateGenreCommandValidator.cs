using Application.Commands.Genres;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Genres
{
	public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
	{
		public CreateGenreCommandValidator()
		{
			RuleFor(x => x.Name)
			.NotEmpty().WithMessage("The genre's name is required")
			.MaximumLength(65).WithMessage("The genre's name must not exceed 255 characters.")
			;
		}
	}
}
