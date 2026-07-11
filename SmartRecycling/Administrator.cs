using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartRecycling
{
    public class Administrator
    {
        [Key]
        public int AdminID { get; set; }

        [Required]
        public string AdminName { get; set; }

        [Required]
        public string AdminSurname { get; set; }

        //Foreign Key
        public Resident Residents { get; set; }
        public virtual string MaterialType { get; set; }
        public virtual double MaterialWeight { get; set; }

        //Calculating of points in our system
        public double CalcPoints()
        {
            double points = 0;

            if (MaterialType == "Glass")
            {
                points = MaterialWeight * 15;

            }
            else if (MaterialType == "Paper")
            {
                points = MaterialWeight * 10;

            }
            else if (MaterialType == "Metal")
            {
                points = MaterialWeight * 25;

            }
            else if (MaterialType == "Plastic")
            {
                points = MaterialWeight * 20;

            }
            else if (MaterialType == "Organic")
            {
                points = MaterialWeight * 5;
            }

            return points;
        }
    }
}