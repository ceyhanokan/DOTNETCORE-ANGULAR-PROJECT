using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TABLES
{
	public class Authorization:IEntity
	{
		[Key]
		public int? AuthID { get; set; }
		public string Name { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int? Code { get; set; }
		public int? Type { get; set; }
	}
}
