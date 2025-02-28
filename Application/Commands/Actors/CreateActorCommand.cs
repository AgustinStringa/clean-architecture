using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Actors
{
	public class CreateActorCommand : IRequest<ActorResponse>
	{
		public string Name { get; set; }
		public string LastName { get; set; }
		public int Height { get; set; }
		public DateTime BirthDate { get; set; }

		public CreateActorCommand(string name, string lastname, int height, DateTime birthdate)
		{
			Name = name;
			LastName = lastname;
			Height = height;
			BirthDate = birthdate;
		}
	}
}
