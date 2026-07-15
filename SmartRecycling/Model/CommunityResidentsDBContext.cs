using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SmartRecycling
{
    public class CommunityResidentsDBContext:DbContext
    {
        public CommunityResidentsDBContext(): base("CommunityResidentsDB")
        {

        }

        public DbSet<Resident> resident { get; set; }
        public DbSet<CommunityResidentsDBContext> CommunityRes { get; set; }
    }
}