namespace Cars.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false, maxLength: 20),
                        TransmissionType = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Dealer_Id = c.Int(nullable: false),
                        Manufacturer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dealers", t => t.Dealer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_Id, cascadeDelete: true)
                .Index(t => t.Dealer_Id)
                .Index(t => t.Manufacturer_Id);
            
            CreateTable(
                "dbo.Dealers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 11),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CityDealers",
                c => new
                    {
                        City_Id = c.Int(nullable: false),
                        Dealer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.City_Id, t.Dealer_Id })
                .ForeignKey("dbo.Cities", t => t.City_Id, cascadeDelete: true)
                .ForeignKey("dbo.Dealers", t => t.Dealer_Id, cascadeDelete: true)
                .Index(t => t.City_Id)
                .Index(t => t.Dealer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Manufacturer_Id", "dbo.Manufacturers");
            DropForeignKey("dbo.Cars", "Dealer_Id", "dbo.Dealers");
            DropForeignKey("dbo.CityDealers", "Dealer_Id", "dbo.Dealers");
            DropForeignKey("dbo.CityDealers", "City_Id", "dbo.Cities");
            DropIndex("dbo.CityDealers", new[] { "Dealer_Id" });
            DropIndex("dbo.CityDealers", new[] { "City_Id" });
            DropIndex("dbo.Cars", new[] { "Manufacturer_Id" });
            DropIndex("dbo.Cars", new[] { "Dealer_Id" });
            DropTable("dbo.CityDealers");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Cities");
            DropTable("dbo.Dealers");
            DropTable("dbo.Cars");
        }
    }
}
