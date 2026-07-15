using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication4.Models
{
	public class HDBContext : DbContext
	{
		public HDBContext() : base("Smart Recycling System")
		{

		}
		public DbSet<Admin> Administrators { get; set; }
		public DbSet<Residents> Residents { get; set; }
		public DbSet<CollectionOfficer> collectionOfficers { get; set; }
		public DbSet<MaterialType> materials { get; set; }

		public DbSet<Collection> Collections { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<CommunityReward> CommunityRewards { get; set; }


	}

	
}