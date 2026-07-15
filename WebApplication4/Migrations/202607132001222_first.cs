namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Admin_ID = c.Int(nullable: false, identity: true),
                        Admin_Name = c.String(nullable: false),
                        Admin_Surname = c.String(nullable: false),
                        Admin_Email = c.String(nullable: false),
                        Admin_Username = c.String(nullable: false),
                        Admin_Password = c.String(nullable: false),
                        Date_Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Admin_ID);
            
            CreateTable(
                "dbo.CollectionOfficers",
                c => new
                    {
                        Officer_ID = c.Int(nullable: false, identity: true),
                        Officer_Name = c.String(nullable: false),
                        Officer_Surname = c.String(nullable: false),
                        Officer_Email = c.String(nullable: false),
                        Officer_PhoneNo = c.String(nullable: false, maxLength: 10),
                        Officer_Area = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Date_Registered = c.DateTime(nullable: false),
                        Collection_Status = c.String(),
                    })
                .PrimaryKey(t => t.Officer_ID);
            
            CreateTable(
                "dbo.Collections",
                c => new
                    {
                        Collection_ID = c.Int(nullable: false, identity: true),
                        Resident_ID = c.Int(nullable: false),
                        Officer_ID = c.Int(nullable: false),
                        Material_ID = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        Points_Earned = c.Double(nullable: false),
                        Collection_Date = c.DateTime(nullable: false),
                        Collection_Status = c.String(),
                    })
                .PrimaryKey(t => t.Collection_ID);
            
            CreateTable(
                "dbo.CommunityRewards",
                c => new
                    {
                        CommunityReward_ID = c.Int(nullable: false, identity: true),
                        Community_Name = c.String(),
                        TargetWeight = c.Double(nullable: false),
                        Reward_Name = c.String(),
                        Approved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CommunityReward_ID);
            
            CreateTable(
                "dbo.MaterialTypes",
                c => new
                    {
                        Material_ID = c.Int(nullable: false, identity: true),
                        Material_Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Material_ID);
            
            CreateTable(
                "dbo.Residents",
                c => new
                    {
                        Resident_ID = c.Int(nullable: false, identity: true),
                        Resident_Name = c.String(nullable: false),
                        Resident_Surname = c.String(nullable: false),
                        Resident_Email = c.String(nullable: false),
                        Resident_Address = c.String(nullable: false),
                        Resident_No = c.String(nullable: false, maxLength: 10),
                        Material_ID = c.Int(nullable: false),
                        Material_Weight = c.Double(nullable: false),
                        RewardPoints = c.Double(nullable: false),
                        ReferralCode = c.String(),
                        ReferredBy = c.String(),
                        Community_Name = c.String(nullable: false),
                        Region = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Resident_ID)
                .ForeignKey("dbo.MaterialTypes", t => t.Material_ID, cascadeDelete: true)
                .Index(t => t.Material_ID);
            
            CreateTable(
                "dbo.Rewards",
                c => new
                    {
                        Reward_ID = c.Int(nullable: false, identity: true),
                        Reward_Name = c.String(nullable: false),
                        Points_Required = c.Int(nullable: false),
                        Reward_Description = c.String(),
                    })
                .PrimaryKey(t => t.Reward_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Residents", "Material_ID", "dbo.MaterialTypes");
            DropIndex("dbo.Residents", new[] { "Material_ID" });
            DropTable("dbo.Rewards");
            DropTable("dbo.Residents");
            DropTable("dbo.MaterialTypes");
            DropTable("dbo.CommunityRewards");
            DropTable("dbo.Collections");
            DropTable("dbo.CollectionOfficers");
            DropTable("dbo.Admins");
        }
    }
}
