using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TABLES
{
	public class User:IEntity
	{
		[Key]
		public int UserID { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public int UserRole { get; set; }
		public int IsAdmin { get; set; }
		public int Status { get; set; }
	}
}
