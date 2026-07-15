using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;
using WebApplication4.Models;
using System.Collections.Generic;

public class Admin
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Admin_ID { get; set; }

    [Required]
    public string Admin_Name { get; set; }

    [Required]
    public string Admin_Surname { get; set; }

    [Required]
    [EmailAddress]
    public string Admin_Email { get; set; }

    [Required]
    public string Admin_Username { get; set; }

    [Required]
    public string Admin_Password { get; set; }

    public DateTime Date_Created { get; set; }

    HDBContext db = new HDBContext();

    public Admin()
    {
        Date_Created = DateTime.Now;
    }

    public int TotalCollections(int month, int year)
    {
        return db.Collections
                 .Where(c => c.Collection_Date.Month == month &&
                             c.Collection_Date.Year == year)
                 .Count();
    }

    public double TotalWeight(int month, int year)
    {
        return db.Collections
                 .Where(c => c.Collection_Date.Month == month &&
                             c.Collection_Date.Year == year)
                 .Sum(c => c.Weight);
    }

    public double TotalPoints(int month, int year)
    {
        return db.Collections
                 .Where(c => c.Collection_Date.Month == month &&
                             c.Collection_Date.Year == year)
                 .Sum(c => c.Points_Earned);
    }

    public string GenerateMonthlyReport(int month, int year)
    {
        string report = "";

        report += "SMART RECYCLING MONTHLY REPORT\n";
        report += "Month: " + month + "/" + year + "\n";
        report += "Total Collections: " + TotalCollections(month, year) + "\n";
        report += "Total Weight: " + TotalWeight(month, year) + " KG\n";
        report += "Total Points: " + TotalPoints(month, year);

        return report;
    }
    public List<string> CommunityLeaderboard()
    {
        var communities = db.Residents
            .GroupBy(r => r.Community_Name)
            .Select(g => new
            {
                Community = g.Key,
                TotalWeight = g.Sum(x => x.Material_Weight)
            })
            .OrderByDescending(x => x.TotalWeight)
            .ToList();

        List<string> board = new List<string>();

        foreach (var item in communities)
        {
            board.Add(item.Community +
                      " - " +
                      item.TotalWeight +
                      " KG");
        }

        return board;
    }
    public List<string> ResidentLeaderboard()
    {
        var residents = db.Residents
            .OrderByDescending(r => r.RewardPoints)
            .Take(10)
            .ToList();

        List<string> board = new List<string>();

        foreach (var resident in residents)
        {
            board.Add(
                resident.Resident_Name + " " +
                resident.Resident_Surname +
                " - " +
                resident.RewardPoints +
                " Points");
        }

        return board;
    }
    public string CheckCommunityAchievement()
    {
        var communities = db.Residents
            .GroupBy(r => r.Community_Name)
            .Select(g => new
            {
                Community = g.Key,
                TotalWeight = g.Sum(x => x.Material_Weight)
            })
            .ToList();

        foreach (var item in communities)
        {
            if (item.TotalWeight >= 1000)
            {
                return "ALERT: " +
                       item.Community +
                       " has reached 1000 KG recycling target!";
            }
        }

        return "No community has reached the target.";
    }
    public string ApproveCommunityReward(string community)
    {
        CommunityReward reward =
            new CommunityReward();

        reward.Community_Name = community;
        reward.TargetWeight = 1000;
        reward.Reward_Name = "Community Garden Upgrade";
        reward.Approved = true;

        db.CommunityRewards.Add(reward);
        db.SaveChanges();

        return "Community Reward Approved.";
    }
    public string CommunityReport()
    {
        string report = "";

        var communities = db.Residents
            .GroupBy(r => r.Community_Name)
            .Select(g => new
            {
                Community = g.Key,
                TotalWeight = g.Sum(x => x.Material_Weight)
            })
            .OrderByDescending(x => x.TotalWeight)
            .ToList();

        foreach (var item in communities)
        {
            report += item.Community +
                      " : " +
                      item.TotalWeight +
                      " KG\n";
        }

        return report;
    }
}