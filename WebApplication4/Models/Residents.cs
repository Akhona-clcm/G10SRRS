using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace WebApplication4.Models
{
    public class Residents
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Resident_ID { get; set; }

        [Required]
        public string Resident_Name { get; set; }

        [Required]
        public string Resident_Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Resident_Email { get; set; }

        [Required]
        public string Resident_Address { get; set; }

        [Required]
        [Phone]
        [StringLength(10)]
        public string Resident_No { get; set; }

        public MaterialType material { get; set; }
        public int Material_ID { get; set; } //Foreign Key

        public double Material_Weight { get; set; }// calculated in Kilograms

        // Rewards
        public double RewardPoints { get; set; }

        // Referral System
        public string ReferralCode { get; set; }

        public string ReferredBy { get; set; }

        // Community Information
        [Required]
        public string Community_Name { get; set; }

        [Required]
        public string Region { get; set; }

        public void GenerateReferralCode()
        {
            ReferralCode = "REF" + Resident_ID;
        }

        public void AwardReferralPoints(string referralCode)
        {
            using (HDBContext db = new HDBContext())
            {
                var referrer = db.Residents
                    .FirstOrDefault(r => r.ReferralCode == referralCode);

                if (referrer != null)
                {
                    referrer.RewardPoints += 100;
                    db.SaveChanges();
                }
            }
        }
        public void AddPoints()
        {
            RewardPoints += CalculatePoints();
        }


        public string GetMaterial()
        {
            HDBContext DB = new HDBContext();
            var Type = (from D in DB.materials where D.Material_ID == Material_ID select D.Material_Name).Single();
            return Type;
        }


        public double CalculatePoints()
        {
            string material = GetMaterial();

            switch (material)
            {
                case "Plastic":
                    return Material_Weight * 10;

                case "Paper":
                    return Material_Weight * 15;

                case "Cardboard":
                    return Material_Weight * 20;

                case "Metal":
                    return Material_Weight * 25;

                default:
                    return 0;
            }
        }
        public string UserDashboard()
        {
            string msg = "";

            msg += "Welcome " + Resident_Name + "\n";
            msg += "Current Points: " + RewardPoints + "\n";
            msg += "Referral Code: " + ReferralCode + "\n";
            msg += "Community: " + Community_Name + "\n\n";

            if (RewardPoints >= 1000)
            {
                msg += "You qualify for a Shopping Voucher.";
            }
            else if (RewardPoints >= 500)
            {
                msg += "You qualify for a Water Bottle.";
            }
            else if (RewardPoints >= 200)
            {
                msg += "You qualify for an Eco Bag.";
            }
            else
            {
                msg += "Keep recycling to earn more rewards.";
            }

            return msg;
        }
        public string RedeemReward(int requiredPoints)
        {
            if (RewardPoints >= requiredPoints)
            {
                RewardPoints -= requiredPoints;

                return "Reward Redeemed Successfully!";
            }

            return "Insufficient Points.";
        }

        public string GetBadge()
        {
            if (RewardPoints >= 5000)
            {
                return "Recycling Legend";
            }
            else if (RewardPoints >= 2500)
            {
                return "Eco Hero";
            }
            else if (RewardPoints >= 1000)
            {
                return "Gold Recycler";
            }
            else if (RewardPoints >= 500)
            {
                return "Silver Recycler";
            }
            else if (RewardPoints >= 100)
            {
                return "Bronze Recycler";
            }

            return "New Recycler";
        }
    }
}