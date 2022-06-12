using System;
using System.ComponentModel.DataAnnotations;

namespace MyBiz.Models
{
	public class Position
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(50)]
		public string Name { get; set; }
	}
}

