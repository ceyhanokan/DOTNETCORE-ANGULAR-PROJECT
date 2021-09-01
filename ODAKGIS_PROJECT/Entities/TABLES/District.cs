using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TABLES
{
	public class District:IEntity
	{
		[Key]
		public int DistrictID { get; set; }
		public int CityID { get; set; }
		public string DistrictName { get; set; }
		public string DistrictCode { get; set; }

	}
}
