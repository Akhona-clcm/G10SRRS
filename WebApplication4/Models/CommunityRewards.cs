using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class CommunityReward
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommunityReward_ID { get; set; }

        public string Community_Name { get; set; }

        public double TargetWeight { get; set; }

        public string Reward_Name { get; set; }

        public bool Approved { get; set; }
    }
}