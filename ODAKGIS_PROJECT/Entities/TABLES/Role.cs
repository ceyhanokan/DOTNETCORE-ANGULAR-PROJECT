using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TABLES
{
	public class Role:IEntity
	{
		[Key]
		public int RoleID { get; set; }
		public string RoleName { get; set; }
		public string RoleTitle { get; set; }
		public string Authorizations { get; set; }
		public int Status { get; set; }
	}
}
