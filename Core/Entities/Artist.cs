using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Base;

namespace Core.Entities
{
	[Table("artists")]
	public abstract class Artist : Entity
	{
		[Column("name")]
		public string Name { get; set; }

		[Column("lastname")]
		public string LastName { get; set; }

		[Column("height")]
		public int Height { get; set; }

		[Column("birthdate")]
		public DateTime BirthDate { get; set; }
	}
}
