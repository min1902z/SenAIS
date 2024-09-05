using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenAIS
{
    public class VehicleReportData
    {
        public string SerialNumber { get; set; }
        public string FrameNumber { get; set; }
        public string VehicleType { get; set; }
        public string Inspector { get; set; }
        public string EngineNumber { get; set; }
        public string InspectionDate { get; set; }
        public decimal Speed { get; set; }
        public decimal? MinSpeed { get; set; }
        public decimal? MaxSpeed { get; set; }
        public bool IsSpeedWithinStandard { get; set; }
        public decimal SideSlip { get; set; }
        public decimal? MinSideSlip { get; set; }
        public decimal? MaxSideSlip { get; set; }
        public bool IsSideSlipWithinStandard { get; set; }
        public decimal Noise { get; set; }
        public decimal? MaxNoise { get; set; }
        public bool IsNoiseWithinStandard { get; set; }
        public decimal Whistle { get; set; }
        public decimal? MinWhistle { get; set; }
        public decimal? MaxWhistle { get; set; }
        public bool IsWhistleWithinStandard { get; set; }
        public decimal FrontLeftWeight { get; set; }
        public decimal FrontRightWeight { get; set; }
        public decimal FrontSumWeight { get; set; }
        public decimal RearLeftWeight { get; set; }
        public decimal RearRightWeight { get; set; }
        public decimal RearSumWeight { get; set; }
        public decimal FrontLeftBrake { get; set; }
        public decimal FrontRightBrake { get; set; }
        public decimal FrontDiffBrake { get; set; }
        public decimal? DiffFrontBrakeMax { get; set; }
        public decimal FrontSumBrake { get; set; }
        public decimal? MinFrontBrake { get; set; }
        public decimal RearLeftBrake { get; set; }
        public decimal RearRightBrake { get; set; }
        public decimal RearDiffBrake { get; set; }
        public decimal? DiffRearBrakeMax { get; set; }
        public decimal RearSumBrake { get; set; }
        public decimal? MinRearBrake { get; set; }
        public decimal HandLeftBrake { get; set; }
        public decimal HandRightBrake { get; set; }
        public decimal HandDiffBrake { get; set; }
        public decimal? DiffHandBrakeMax { get; set; }
        public decimal HandSumBrake { get; set; }
        public decimal? MinHandBrake { get; set; }
        public bool IsBrakeWithinStandard { get; set; }
        public decimal HC { get; set; }
        public decimal? MaxHC { get; set; }
        public decimal CO { get; set; }
        public decimal? MaxCO { get; set; }
        public decimal RPM { get; set; }
        public decimal OilTemp { get; set; }
        public bool IsPetrolWithinStandard { get; set; }
        public decimal MinSpeed1 { get; set; }
        public decimal MinSpeed2 { get; set; }
        public decimal MinSpeed3 { get; set; }
        public decimal MaxSpeed1 { get; set; }
        public decimal MaxSpeed2 { get; set; }
        public decimal MaxSpeed3 { get; set; }
        public decimal HSU1 { get; set; }
        public decimal HSU2 { get; set; }
        public decimal HSU3 { get; set; }
        public decimal AvgHSU { get; set; }
        public decimal? MaxHSU { get; set; }
        public bool IsDieselWithinStandard { get; set; }
        public decimal LHLIntensity { get; set; }
        public decimal RHLIntensity { get; set; }
        public decimal? MinHLIntensity { get; set; }
        public decimal LHLVertical { get; set; }
        public decimal RHLVertical { get; set; }
        public decimal? MinHLVertical { get; set; }
        public decimal? MaxHLVertical { get; set; }
        public decimal LHLHorizontal { get; set; }
        public decimal RHLHorizontal { get; set; }
        public decimal? MinHLHorizontal { get; set; }
        public decimal? MaxHLHorizontal { get; set; }
        public decimal LLBIntensity { get; set; }
        public decimal RLBIntensity { get; set; }
        public decimal? MinLBIntensity { get; set; }
        public decimal LLBVertical { get; set; }
        public decimal RLBVertical { get; set; }
        public decimal? MinLBVertical { get; set; }
        public decimal? MaxLBVertical { get; set; }
        public decimal LLBHorizontal { get; set; }
        public decimal RLBHorizontal { get; set; }
        public decimal? MinLBHorizontal { get; set; }
        public decimal? MaxLBHorizontal { get; set; }
        public decimal? LightHeight { get; set; }
        public bool IsLightWithinStandard { get; set; }
    }
}
