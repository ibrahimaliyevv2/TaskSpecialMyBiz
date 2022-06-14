using System;
using Microsoft.EntityFrameworkCore;
using MyBiz.Models;

namespace MyBiz.DAL
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public DbSet<Position> Positions{get;set;}
		public DbSet<Teammember> Teammembers { get; set; }
	}
}

