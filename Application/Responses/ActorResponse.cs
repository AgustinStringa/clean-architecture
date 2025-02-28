using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
	public class ActorResponse
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public int Height { get; set; }
		public DateTime BirthDate { get; set; }
		public int Age => CalculateAge(BirthDate);
		private static int CalculateAge(DateTime birthDate)
		{
			var today = DateTime.Today;
			int age = today.Year - birthDate.Year;
			if (birthDate.Date > today.AddYears(-age))
			{
				age--;
			}
			return age;
		}
	}
}
