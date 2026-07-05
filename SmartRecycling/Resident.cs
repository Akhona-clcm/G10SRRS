using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartRecycling
{
    public class Resident
    {
        [Key]
        //[MinLength(13), MaxLength(13)]
        //Should the ID be generated for Resident safety?
        public int ResidentID { get; set; }

        [Required]
        public string ResidentName { get; set; }

        [Required]
        public string ResidentSurname { get; set; }

        [Required]
        public string ResidentialArea { get; set; }

        [Required]
        public string MaterialType { get; set; }

        [Required]
        public double MaterialWeight { get; set; }

        [Required]
        public string DateDropped { get; set; }

        [Required]
        public string DropOffPoint { get; set; }

        //For Admin
        public double CalcPoints()
        {
            double points = 0;

            if (MaterialType == "Glass")
            {
                points = MaterialWeight * 5;

            } else if (MaterialType == "Paper")
            {
                points = MaterialWeight * 3;

            } else if (MaterialType == "Metal")
            {
                points = MaterialWeight * 6;

            } else if (MaterialType == "Plastic")
            {
                points = MaterialWeight * 7;

            } else if (MaterialType == "Organic")
            {
                points = MaterialWeight * 2;
            }

            return points;
        }

    }
}