namespace Cartefact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Ref = c.String(),
                        Description = c.String(),
                        BuyingYear = c.Int(nullable: false),
                        Kilometers = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        NickName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        DrivingHabits = c.String(),
                        DriverExperience = c.Int(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.String(),
                        EndDate = c.String(),
                        Price = c.Int(nullable: false),
                        EstimatedKilometers = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.CarId)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "PersonId", "dbo.People");
            DropForeignKey("dbo.Rentals", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Cars", "Person_Id", "dbo.People");
            DropIndex("dbo.Rentals", new[] { "PersonId" });
            DropIndex("dbo.Rentals", new[] { "CarId" });
            DropIndex("dbo.Cars", new[] { "Person_Id" });
            DropTable("dbo.Rentals");
            DropTable("dbo.People");
            DropTable("dbo.Cars");
        }
    }
}
