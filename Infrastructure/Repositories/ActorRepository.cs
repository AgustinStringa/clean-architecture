using Core.Entities;
using Core.Repositories;
using Core.Repositories.Base;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class ActorRepository : Repository<Actor>, IActorRepository
	{
		public ActorRepository(MovieContext movieContext) : base(movieContext) { }
	}
}
