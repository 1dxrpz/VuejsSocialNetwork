using System;

namespace SocialNetworkAPI.Models
{
	public class User
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Avatar { get; set; }
		public string About { get; set; }
		public int Age { get; set; }
	}
}
