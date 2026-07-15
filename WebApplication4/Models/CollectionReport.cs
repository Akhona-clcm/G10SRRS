using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Collection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Collection_ID { get; set; }

        // Foreign Keys
        public int Resident_ID { get; set; }
        public int Officer_ID { get; set; }
        public int Material_ID { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public double Points_Earned { get; set; }

        public DateTime Collection_Date { get; set; }

        public string Collection_Status { get; set; }

        public Collection()
        {
            Collection_Date = DateTime.Now;
            Collection_Status = "Pending";
        }
    }
}