using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TABLES
{
	public class Log:IEntity
	{
		[Key]
		public int LogID { get; set; }
		public DateTime CreatedDate { get; set; }
		public int LogType { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int ActionUserID { get; set; }
		public int TargetUserID { get; set; }
		public int TargetImmovableID { get; set; }
	}
}
