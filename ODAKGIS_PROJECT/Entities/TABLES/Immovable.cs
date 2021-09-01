using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TABLES
{
	public class Immovable:IEntity
	{
		[Key]
		public int? ImmovableID { get; set; }
		public int? TypeID { get; set; }
		public string TypeName { get; set; }
		public int? CityID { get; set; }
		public int? DistrictID { get; set; }
		public int? NeighbourhoodID { get; set; }
		public string Adress { get; set; }
		public int? Block { get; set; }
		public int? Plot { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public int? CreatedUser { get; set; }
		public int? UpdatedUser { get; set; }
		public int? Status { get; set; }
	}
}
