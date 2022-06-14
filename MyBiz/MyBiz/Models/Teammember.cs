using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace MyBiz.Models
{
	public class Teammember
	{
		public int Id { get; set; }
		public int PositionId { get; set; }
		[Required]
		[MaxLength(50)]
		public string FullName { get; set; }
		[MaxLength(150)]
		public string Description { get; set; }
		[MaxLength(100)]
		public string TwitterUsername { get; set; }
		[MaxLength(100)]
		public string FacebookUsername { get; set; }
		[MaxLength(100)]
		public string InstagramUsername { get; set; }
		[MaxLength(100)]
		public string LinkedInUsername { get; set; }
		public string ImageUrl { get; set; }

		public Position Position { get; set; }

		[NotMapped]
		public IFormFile ImageFile { get; set; }
	}
}

