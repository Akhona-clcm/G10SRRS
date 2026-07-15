using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartRecycling
{
    public class CollectionOfficer
    {
        [Key]
        public int CollOfficerID { get; set; }

        [Required]
        public string CollOfficerName { get; set; }

        [Required]
        public string CollOfficerSurname { get; set; }

        [Required]
        public string DropOffPoint { get; set; }

        //Foreign Key
        public Resident Residents { get; set; }
        public int ResidentID {get; set;}

        //To match the CollectionOfficer to the Residents dropoff points
        public string GetDropOffPoint()
        {
            CommunityResidentsDBContext DB = new CommunityResidentsDBContext();
            var dropoff = (from D in DB.Resident
                           where D.ResidentID == ResidentID
                           select D.DropOffPoint).Single();

            return dropoff;
        }

    }
}