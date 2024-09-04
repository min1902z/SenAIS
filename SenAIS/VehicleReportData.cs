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
    }
}
