using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TABLES
{
	public class Neighbourhood:IEntity
	{
		[Key]
		public int NeighbourhoodID { get; set; }
		public int DistrictID { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
	}
}
