using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TABLES
{
	public class TypeTBL:IEntity
	{
		[Key]
		public int TypeID { get; set; }
		public string TypeName { get; set; }
		public string TypeTitle { get; set; }
		public string TypeCode { get; set; }
		public string TypeCode2 { get; set; }
		public string TypeCode3 { get; set; }
	}
}
