using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class CollectionOfficer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Officer_ID { get; set; }

        [Required]
        public string Officer_Name { get; set; }

        [Required]
        public string Officer_Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Officer_Email { get; set; }

        [Required]
        [StringLength(10)]
        public string Officer_PhoneNo { get; set; }

        [Required]
        public string Officer_Area { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime Date_Registered { get; set; }

        // Collection Status
        public string Collection_Status { get; set; }

        public CollectionOfficer()
        {
            Date_Registered = DateTime.Now;
            Collection_Status = "Pending";
        }

        // Calculate Points
        public double CalculatePoints(string materialType, double weight)
        {
            switch (materialType)
            {
                case "Plastic":
                    return weight * 10;

                case "Paper":
                    return weight * 15;

                case "Cardboard":
                    return weight * 20;

                case "Metal":
                    return weight * 25;

                default:
                    return 0;
            }
        }

        // Verify Collection
        public string VerifyCollection()
        {
            Collection_Status = "Verified";
            return Collection_Status;
        }

        // Mark Collection as Collected
        public string MarkAsCollected()
        {
            Collection_Status = "Collected";
            return Collection_Status;
        }

        // Mark Collection as Completed
        public string MarkAsCompleted()
        {
            Collection_Status = "Completed";
            return Collection_Status;
        }

        // Mark Collection as Cancelled
        public string CancelCollection()
        {
            Collection_Status = "Cancelled";
            return Collection_Status;
        }

        // View Current Status
        public string ViewStatus()
        {
            return Collection_Status;
        }
    }
}