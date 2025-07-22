using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenAIS.Core.Repositories
{
    public class VehicleRepository
    {
        public List<VehicleInfo> GetAllVehicleInfo()
        {
            using (var db = new SenAISDB_HDEntities())
            {
                return db.VehicleInfoes
                         .OrderByDescending(v => v.VehicleID)
                         .ToList();
            }
        }
        public VehicleInfo GetVehicleDetails(string serialNumber)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                return db.VehicleInfoes
                         .Include("Speeds")
                         .Include("SideSlips")
                         .Include("Weights")
                         .Include("BrakeForces")
                         .Include("Noises")
                         .Include("Headlights")
                         .Include("GasEmission_Petrol")
                         .Include("GasEmission_Diesel")
                         .Include("SteerAngles")
                         .FirstOrDefault(v => v.SerialNumber == serialNumber);
            }
        }

        public VehicleInfo GetBySerial(string serialNumber)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                return db.VehicleInfoes
                         .FirstOrDefault(v => v.SerialNumber == serialNumber);
            }
        }

        public List<VehicleInfo> Search(string searchTerm)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var query = db.VehicleInfoes.AsQueryable();

                string trimmed = searchTerm.Trim();

                // Tìm theo ngày đầy đủ (yyyy-MM-dd, dd/MM/yyyy, v.v.)
                if (DateTime.TryParse(trimmed, out DateTime exactDate))
                {
                    query = query.Where(v => DbFunctions.TruncateTime(v.InspectionDate) == exactDate.Date);
                }
                // Tìm theo khoảng ngày: "dd/MM/yyyy - dd/MM/yyyy"
                else if (trimmed.Contains("-"))
                {
                    string[] parts = trimmed.Split('-');
                    if (parts.Length == 2 &&
                        DateTime.TryParse(parts[0].Trim(), out DateTime fromDate) &&
                        DateTime.TryParse(parts[1].Trim(), out DateTime toDate))
                    {
                        query = query.Where(v => DbFunctions.TruncateTime(v.InspectionDate) >= fromDate.Date &&
                                                 DbFunctions.TruncateTime(v.InspectionDate) <= toDate.Date);
                    }
                }
                // Ngày + tháng: "dd/MM" hoặc "dd-MM"
                else if (DateTime.TryParseExact(trimmed, new[] { "dd/MM", "dd-MM" },
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dayMonthOnly))
                {
                    int d = dayMonthOnly.Day;
                    int m = dayMonthOnly.Month;
                    query = query.Where(v => v.InspectionDate.HasValue &&
                                             v.InspectionDate.Value.Day == d &&
                                             v.InspectionDate.Value.Month == m);
                }
                // Các trường văn bản khác
                else
                {
                    query = query.Where(v =>
                        v.SerialNumber.Contains(searchTerm) ||
                        v.FrameNumber.Contains(searchTerm) ||
                        v.VehicleType.Contains(searchTerm) ||
                        v.Inspector.Contains(searchTerm) ||
                        v.Fuel.Contains(searchTerm)
                    );
                }

                return query.OrderByDescending(v => v.InspectionDate).ToList();
            }
        }
        public string GetFuelTypeBySerialNumber(string serialNumber)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                return db.VehicleInfoes
                         .Where(v => v.SerialNumber == serialNumber)
                         .Select(v => v.Fuel)
                         .FirstOrDefault();
            }
        }
        public string GetNextSerialNumber(string currentSerialNumber)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                return db.VehicleInfoes
                         .Where(v => string.Compare(v.SerialNumber, currentSerialNumber) > 0)
                         .OrderBy(v => v.SerialNumber)
                         .Select(v => v.SerialNumber)
                         .FirstOrDefault();
            }
        }

        public string GetPreviousSerialNumber(string currentSerialNumber)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                return db.VehicleInfoes
                         .Where(v => string.Compare(v.SerialNumber, currentSerialNumber) < 0)
                         .OrderByDescending(v => v.SerialNumber)
                         .Select(v => v.SerialNumber)
                         .FirstOrDefault();
            }
        }
        public void SaveVehicleInfo(string vehicleType, string inspector, string frameNumber, string serialNumber, DateTime inspectionDate, string fuelType)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.VehicleInfoes.FirstOrDefault(v => v.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.VehicleType = vehicleType;
                    existing.Inspector = inspector;
                    existing.FrameNumber = frameNumber;
                    existing.InspectionDate = inspectionDate;
                    existing.Fuel = fuelType;
                }
                else
                {
                    var newVehicle = new VehicleInfo
                    {
                        VehicleType = vehicleType,
                        Inspector = inspector,
                        FrameNumber = frameNumber,
                        SerialNumber = serialNumber,
                        InspectionDate = inspectionDate,
                        Fuel = fuelType
                    };
                    db.VehicleInfoes.Add(newVehicle);
                }

                db.SaveChanges();
            }
        }
    }
}
