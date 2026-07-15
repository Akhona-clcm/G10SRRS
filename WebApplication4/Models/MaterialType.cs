using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
	public class MaterialType
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Material_ID { get; set; }
		[Display(Name ="Please Select the type of Material you wish to deposit.")]

		[Required]
		public string Material_Name { get; set; }

	}
}