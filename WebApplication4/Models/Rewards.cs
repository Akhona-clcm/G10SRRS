using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    // ---------- Entity (Database Model) ----------
    public class Reward
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Reward_ID { get; set; }

        [Required]
        public string Reward_Name { get; set; }

        [Required]
        public int Points_Required { get; set; }

        public string Reward_Description { get; set; }
    }

    // ---------- DTOs (Service Layer Models) ----------
    public class RewardDto
    {
        public int Reward_ID { get; set; }
        public string Reward_Name { get; set; }
        public int Points_Required { get; set; }
        public string Reward_Description { get; set; }
    }

    public class CreateRewardRequest
    {
        [Required]
        public string Reward_Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Points required must be greater than zero.")]
        public int Points_Required { get; set; }

        public string Reward_Description { get; set; }
    }

    public class UpdateRewardRequest
    {
        [Required]
        public string Reward_Name { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Points_Required { get; set; }

        public string Reward_Description { get; set; }
    }
}