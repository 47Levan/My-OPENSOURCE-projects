namespace ZenchenkoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WarmFloorUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WarmFloors", "ConductorOfTheHeating", c => c.String());
            AddColumn("dbo.WarmFloors", "InsulationOfTheHeatingElement", c => c.String());
            AddColumn("dbo.WarmFloors", "OuterDiameter", c => c.Double(nullable: false));
            AddColumn("dbo.WarmFloors", "MinimumBendingRadius", c => c.String());
            AddColumn("dbo.WarmFloors", "TypeOfConnectionOfHeatingElement", c => c.String());
            AddColumn("dbo.WarmFloors", "MaximumOperatingTempOfHeatingConductor", c => c.Int(nullable: false));
            AddColumn("dbo.WarmFloors", "MaximumTempOfTheOuterShell", c => c.Int(nullable: false));
            AlterColumn("dbo.WarmFloors", "RatedVoltage", c => c.Int(nullable: false));
            AlterColumn("dbo.WarmFloors", "TheMaximumVoltage", c => c.Int(nullable: false));
            DropColumn("dbo.WarmFloors", "TheConductorOfTheHeating");
            DropColumn("dbo.WarmFloors", "TheInsulationOfTheHeatingElement");
            DropColumn("dbo.WarmFloors", "TheOuterDiameter");
            DropColumn("dbo.WarmFloors", "TheMinimumBendingRadius");
            DropColumn("dbo.WarmFloors", "MaximumOperatingTheHeatingConductor");
            DropColumn("dbo.WarmFloors", "MaximumUseOfTheOuterShell");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WarmFloors", "MaximumUseOfTheOuterShell", c => c.String());
            AddColumn("dbo.WarmFloors", "MaximumOperatingTheHeatingConductor", c => c.String());
            AddColumn("dbo.WarmFloors", "TheMinimumBendingRadius", c => c.String());
            AddColumn("dbo.WarmFloors", "TheOuterDiameter", c => c.String());
            AddColumn("dbo.WarmFloors", "TheInsulationOfTheHeatingElement", c => c.String());
            AddColumn("dbo.WarmFloors", "TheConductorOfTheHeating", c => c.String());
            AlterColumn("dbo.WarmFloors", "TheMaximumVoltage", c => c.String());
            AlterColumn("dbo.WarmFloors", "RatedVoltage", c => c.String());
            DropColumn("dbo.WarmFloors", "MaximumTempOfTheOuterShell");
            DropColumn("dbo.WarmFloors", "MaximumOperatingTempOfHeatingConductor");
            DropColumn("dbo.WarmFloors", "TypeOfConnectionOfHeatingElement");
            DropColumn("dbo.WarmFloors", "MinimumBendingRadius");
            DropColumn("dbo.WarmFloors", "OuterDiameter");
            DropColumn("dbo.WarmFloors", "InsulationOfTheHeatingElement");
            DropColumn("dbo.WarmFloors", "ConductorOfTheHeating");
        }
    }
}
