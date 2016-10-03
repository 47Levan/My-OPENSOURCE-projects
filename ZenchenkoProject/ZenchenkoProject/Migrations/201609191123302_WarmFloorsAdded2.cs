namespace ZenchenkoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WarmFloorsAdded2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WarmFloors", "TheConductorOfTheHeating", c => c.String());
            AddColumn("dbo.WarmFloors", "PowerCable", c => c.String());
            AddColumn("dbo.WarmFloors", "GroundingConductor", c => c.String());
            AddColumn("dbo.WarmFloors", "TheInsulationOfTheHeatingElement", c => c.String());
            AddColumn("dbo.WarmFloors", "Shield", c => c.String());
            AddColumn("dbo.WarmFloors", "ConnectionsOfTheHeatingCable", c => c.String());
            AddColumn("dbo.WarmFloors", "MarkingDirectCoupledConnections", c => c.String());
            AddColumn("dbo.WarmFloors", "WireMarking", c => c.String());
            AddColumn("dbo.WarmFloors", "TheOuterDiameter", c => c.String());
            AddColumn("dbo.WarmFloors", "PvcPuterSheath", c => c.String());
            AddColumn("dbo.WarmFloors", "LinearPower", c => c.String());
            AddColumn("dbo.WarmFloors", "TheMinimumBendingRadius", c => c.String());
            AddColumn("dbo.WarmFloors", "PermissibleResistanceElement", c => c.String());
            AddColumn("dbo.WarmFloors", "RatedVoltage", c => c.String());
            AddColumn("dbo.WarmFloors", "TheMaximumVoltage", c => c.String());
            AddColumn("dbo.WarmFloors", "MaximumOperatingTheHeatingConductor", c => c.String());
            AddColumn("dbo.WarmFloors", "MaximumUseOfTheOuterShell", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WarmFloors", "MaximumUseOfTheOuterShell");
            DropColumn("dbo.WarmFloors", "MaximumOperatingTheHeatingConductor");
            DropColumn("dbo.WarmFloors", "TheMaximumVoltage");
            DropColumn("dbo.WarmFloors", "RatedVoltage");
            DropColumn("dbo.WarmFloors", "PermissibleResistanceElement");
            DropColumn("dbo.WarmFloors", "TheMinimumBendingRadius");
            DropColumn("dbo.WarmFloors", "LinearPower");
            DropColumn("dbo.WarmFloors", "PvcPuterSheath");
            DropColumn("dbo.WarmFloors", "TheOuterDiameter");
            DropColumn("dbo.WarmFloors", "WireMarking");
            DropColumn("dbo.WarmFloors", "MarkingDirectCoupledConnections");
            DropColumn("dbo.WarmFloors", "ConnectionsOfTheHeatingCable");
            DropColumn("dbo.WarmFloors", "Shield");
            DropColumn("dbo.WarmFloors", "TheInsulationOfTheHeatingElement");
            DropColumn("dbo.WarmFloors", "GroundingConductor");
            DropColumn("dbo.WarmFloors", "PowerCable");
            DropColumn("dbo.WarmFloors", "TheConductorOfTheHeating");
        }
    }
}
