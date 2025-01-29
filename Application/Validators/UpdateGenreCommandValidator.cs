using Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
	public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
	{
		public UpdateGenreCommandValidator()
		{
			RuleFor(x => x.Id)
			.NotEmpty().WithMessage("Genre's Id is required")
			.GreaterThanOrEqualTo(0)
			;

			RuleFor(x => x.Name)
			.NotEmpty().WithMessage("Genre's name is required")
			.MaximumLength(65).WithMessage("Genre's name must not exceed 65 characters.");
		}
	}
}
