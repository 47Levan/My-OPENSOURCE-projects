using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ZenchenkoProject.Models.Entities
{
    public enum TypesOfWire
    {
        OneWire,
        TwoWires,
        ThreeWires,
        FourWires,
    }
    public enum Manufacturers
    {
        Nexans,
        ProfiTherm,
        ProfiThermEko,
        ProfiThermSlims,
    }
    public enum TypesOfRoom
    {
        Kitchen,
        Bathroom,
        Corridor,
        Room,
        Lavatory,
    }

    public enum MethodsOfHeat
    {
        Comfort,
        Main,
    }
    public enum MethodsOfinstallation
    {
        InMortar,
        InTileAdhesive,
        UnderTheTopcoat
    }


    public class WarmFloor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        #region PreviewData
        public string Article { get; set; }
        public int Power { get; set; }
        public string SpaceHeating { get; set; }
        public int Garanty { get; set; }
        public string CountryOfProduction { get; set; }
        public decimal Price { get; set; }
        public bool IsInStock { get; set; }

        #endregion
        #region DataFilters
        public TypesOfWire TypeOfWire { get; set; }
        public Manufacturers Manufacturer { get; set; }
        [NotMapped]
        public List<string> TypesOfRoom
        {
            get
            {
                List<string> ranges =
             new JavaScriptSerializer().Deserialize<List<string>>(this.TypeOfRoom);
                return ranges;
            }
            set
            {
                this.TypeOfRoom = new JavaScriptSerializer().Serialize(value);
            }
        }
        public string TypeOfRoom { get; set; }
        [NotMapped]
        public List<List<double>> Ranges
        {
            get
            {
                List<List<double>> ranges =
             new JavaScriptSerializer().Deserialize<List<List<double>>>(this.WarmSquere);
                return ranges;
            }
            set
            {
                this.WarmSquere = new JavaScriptSerializer().Serialize(value);
            }
        }
        public string WarmSquere { get; set; }
        public MethodsOfHeat MethodOfHeat { get; set; }
        public MethodsOfinstallation MethodOfInstallation { get; set; }
        #endregion
        #region DetailsData
        public string ConductorOfTheHeating { get; set; }
        public string PowerCable { get; set; }
        public string GroundingConductor { get; set; }
        public string InsulationOfTheHeatingElement { get; set; }
        public string ProtectScreen { get; set; }
        public string OuterSheald { get; set; }
        public string ConnectionsOfTheHeatingCable { get; set; }
        public string MarkingDirectCoupledConnections { get; set; }
        public string WireMarking { get; set; }
        public double OuterDiameter { get; set; }
        public string LinearPower { get; set; }
        public string MinimumBendingRadius { get; set; }
        public string PermissibleResistanceElement { get; set; }
        public string TypeOfConnectionOfHeatingElement { get; set; }
        public int RatedVoltage { get; set; }
        public int TheMaximumVoltage { get; set; }
        public int MaximumOperatingTempOfHeatingConductor { get; set; }
        public int  MaximumTempOfTheOuterShell { get; set; }

        #endregion
        public string PictureRef { get; set; }
        public string Description { get; set; }

    }
}
