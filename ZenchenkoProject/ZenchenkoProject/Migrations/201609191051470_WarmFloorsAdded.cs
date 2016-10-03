namespace ZenchenkoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WarmFloorsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WarmFloors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Power = c.Int(nullable: false),
                        SpaceHeating = c.String(),
                        Garanty = c.String(),
                        CountryOfProduction = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TypeOfWire = c.Int(nullable: false),
                        Manufacturer = c.Int(nullable: false),
                        TypeOfRoom = c.Int(nullable: false),
                        WarmSquere = c.String(),
                        MethodOfHeat = c.Int(nullable: false),
                        MethodOfInstallation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WarmFloors", "CategoryId", "dbo.Categories");
            DropIndex("dbo.WarmFloors", new[] { "CategoryId" });
            DropTable("dbo.WarmFloors");
        }
    }
}
