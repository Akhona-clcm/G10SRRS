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

        public virtual DbSet<Resident> Resident { get; set; }
        public virtual DbSet<CollectionOfficer> CollectionOfficer { get; set; }
    }
}