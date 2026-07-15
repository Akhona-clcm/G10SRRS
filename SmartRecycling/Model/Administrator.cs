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
        public  string MaterialType { get; set; }
        public  double MaterialWeight { get; set; }

       
       
    }
}