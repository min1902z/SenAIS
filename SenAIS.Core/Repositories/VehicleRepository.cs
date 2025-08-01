using SenAIS.Core.Config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenAIS.Core.Repositories
{
    public class VehicleRepository
    {
        private readonly string _connectionString;

        public VehicleRepository()
        {
            _connectionString = AppSettingsHelper.GetDatabaseConnectionString();
        }
        public DataTable GetAllVehicleInfo()
        {
            using (var db = new SenAISDB_HDEntities(_connectionString))
            {
                var vehicles = db.VehicleInfoes
                                 .OrderByDescending(v => v.VehicleID)
                                 .ToList();

                var resultTable = new DataTable();
                resultTable.Columns.Add("SerialNumber", typeof(string));
                resultTable.Columns.Add("FrameNumber", typeof(string));
                resultTable.Columns.Add("VehicleType", typeof(string));
                resultTable.Columns.Add("Inspector", typeof(string));
                resultTable.Columns.Add("InspectionDate", typeof(object));
                resultTable.Columns.Add("Fuel", typeof(string));

                foreach (var v in vehicles)
                {
                    resultTable.Rows.Add(
                        v.SerialNumber,
                        v.FrameNumber,
                        v.VehicleType,
                        v.Inspector,
                        v.InspectionDate.HasValue ? (object)v.InspectionDate.Value : DBNull.Value,
                        v.Fuel
                    );
                }

                return resultTable;
            }
        }
        public VehicleInfo GetVehicleDetails(string serialNumber)
        {
            using (var db = new SenAISDB_HDEntities(_connectionString))
            {
                return db.VehicleInfoes
                     .Include(v => v.Speeds)
                     .Include(v => v.SideSlips)
                     .Include(v => v.Weights)
                     .Include(v => v.BrakeForces)
                     .Include(v => v.Noises)
                     .Include(v => v.Headlights)
                     .Include(v => v.GasEmission_Petrol)
                     .Include(v => v.GasEmission_Diesel)
                     .Include(v => v.SteerAngles)
                     .FirstOrDefault(v => v.SerialNumber == serialNumber);
            }
        }

        public VehicleInfo GetBySerial(string serialNumber)
        {
            using (var db = new SenAISDB_HDEntities(_connectionString))
            {
                return db.VehicleInfoes
                         .FirstOrDefault(v => v.SerialNumber == serialNumber);
            }
        }

        public DataTable Search(string searchTerm)
        {
            using (var db = new SenAISDB_HDEntities(_connectionString))
            {
                var query = db.VehicleInfoes.AsQueryable();

                string trimmed = searchTerm.Trim();

                // Tìm theo ngày đầy đủ (yyyy-MM-dd, dd/MM/yyyy, ...)
                if (DateTime.TryParse(trimmed, out DateTime exactDate))
                {
                    query = query.Where(v => DbFunctions.TruncateTime(v.InspectionDate) == exactDate.Date);
                }
                // Khoảng ngày: "dd/MM/yyyy - dd/MM/yyyy"
                else if (trimmed.Contains("-"))
                {
                    string[] parts = trimmed.Split('-');
                    if (parts.Length == 2 &&
                        DateTime.TryParse(parts[0].Trim(), out DateTime fromDate) &&
                        DateTime.TryParse(parts[1].Trim(), out DateTime toDate))
                    {
                        query = query.Where(v =>
                            DbFunctions.TruncateTime(v.InspectionDate) >= fromDate.Date &&
                            DbFunctions.TruncateTime(v.InspectionDate) <= toDate.Date);
                    }
                }
                // Ngày + tháng không năm: "dd/MM"
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
                        v.Fuel.Contains(searchTerm));
                }

                // Tạo DataTable từ kết quả
                var resultTable = new DataTable();
                resultTable.Columns.Add("SerialNumber", typeof(string));
                resultTable.Columns.Add("FrameNumber", typeof(string));
                resultTable.Columns.Add("VehicleType", typeof(string));
                resultTable.Columns.Add("Inspector", typeof(string));
                resultTable.Columns.Add("InspectionDate", typeof(object)); // Dùng object để chứa DBNull
                resultTable.Columns.Add("Fuel", typeof(string));

                foreach (var vehicle in query.OrderByDescending(v => v.InspectionDate).ToList())
                {
                    resultTable.Rows.Add(
                        vehicle.SerialNumber,
                        vehicle.FrameNumber,
                        vehicle.VehicleType,
                        vehicle.Inspector,
                        vehicle.InspectionDate.HasValue ? (object)vehicle.InspectionDate.Value : DBNull.Value,
                        vehicle.Fuel
                    );
                }

                return resultTable;
            }
        }
        public string GetFuelTypeBySerialNumber(string serialNumber)
        {
            using (var db = new SenAISDB_HDEntities(_connectionString))
            {
                return db.VehicleInfoes
                         .Where(v => v.SerialNumber == serialNumber)
                         .Select(v => v.Fuel)
                         .FirstOrDefault();
            }
        }
        public string GetNextSerialNumber(string currentSerialNumber)
        {
            using (var db = new SenAISDB_HDEntities(_connectionString))
            {
                var currentVehicle = db.VehicleInfoes
                    .FirstOrDefault(v => v.SerialNumber == currentSerialNumber);

                if (currentVehicle == null) return null;

                return db.VehicleInfoes
                         .Where(v => v.VehicleID > currentVehicle.VehicleID)
                         .OrderBy(v => v.VehicleID)
                         .Select(v => v.SerialNumber)
                         .FirstOrDefault();
            }
        }

        public string GetPreviousSerialNumber(string currentSerialNumber)
        {
            using (var db = new SenAISDB_HDEntities(_connectionString))
            {
                var currentVehicle = db.VehicleInfoes
                    .FirstOrDefault(v => v.SerialNumber == currentSerialNumber);

                if (currentVehicle == null) return null;

                return db.VehicleInfoes
                         .Where(v => v.VehicleID < currentVehicle.VehicleID)
                         .OrderByDescending(v => v.VehicleID)
                         .Select(v => v.SerialNumber)
                         .FirstOrDefault();
            }
        }
        public void SaveVehicleInfo(string vehicleType, string inspector, string frameNumber, string serialNumber, DateTime inspectionDate, string fuelType)
        {
            using (var db = new SenAISDB_HDEntities(_connectionString))
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
