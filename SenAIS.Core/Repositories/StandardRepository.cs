using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenAIS.Core.Repositories
{
    public class StandardRepository
    {
        public DataTable GetVehicleStandardsData()
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var list = db.VehicleStandards.ToList();
                var table = new DataTable();
                var props = typeof(VehicleStandard).GetProperties();
                foreach (var prop in props)
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                foreach (var item in list)
                {
                    var row = table.NewRow();
                    foreach (var prop in props)
                    {
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    }
                    table.Rows.Add(row);
                }
                return table;
            }
        }

        public void UpdateVehicleStandardsData(DataTable dataTable)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.RowState == DataRowState.Deleted) continue;

                    string vehicleType = row["VehicleType"].ToString();
                    var existing = db.VehicleStandards.FirstOrDefault(x => x.VehicleType == vehicleType);

                    if (existing != null)
                    {
                        foreach (DataColumn col in dataTable.Columns)
                        {
                            var prop = typeof(VehicleStandard).GetProperty(col.ColumnName);
                            if (prop != null)
                            {
                                var value = row[col.ColumnName];
                                prop.SetValue(existing, value == DBNull.Value ? null : value);
                            }
                        }
                    }
                    else
                    {
                        var newItem = new VehicleStandard();
                        foreach (DataColumn col in dataTable.Columns)
                        {
                            var prop = typeof(VehicleStandard).GetProperty(col.ColumnName);
                            if (prop != null)
                            {
                                var value = row[col.ColumnName];
                                prop.SetValue(newItem, value == DBNull.Value ? null : value);
                            }
                        }
                        db.VehicleStandards.Add(newItem);
                    }
                }
                db.SaveChanges();
            }
        }
        public void DeleteByVehicleType(string vehicleType)
        {
            if (string.IsNullOrWhiteSpace(vehicleType)) return;

            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.VehicleStandards.FirstOrDefault(x => x.VehicleType == vehicleType);
                if (existing != null)
                {
                    db.VehicleStandards.Remove(existing);
                    db.SaveChanges();
                }
            }
        }

        public DataTable GetTypeCarList()
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var table = new DataTable();
                table.Columns.Add("VehicleType", typeof(string));
                foreach (var v in db.VehicleStandards.Select(x => x.VehicleType).Distinct())
                {
                    table.Rows.Add(v);
                }
                return table;
            }
        }

        public VehicleStandard GetVehicleStandardByTypeCar(string vehicleType)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                return db.VehicleStandards
                         .FirstOrDefault(vs => vs.VehicleType == vehicleType);
            }
        }

        public bool CheckValueAgainstStandard(string valueType, decimal value, string serialNumber)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var vehicle = db.VehicleInfoes.FirstOrDefault(v => v.SerialNumber == serialNumber);
                if (vehicle == null)
                {
                    return false;
                }

                string vehicleType = vehicle.VehicleType;

                string minColumn = "";
                string maxColumn = "";

                switch (valueType)
                {
                    case "Speed": minColumn = "MinSpeed"; maxColumn = "MaxSpeed"; break;
                    case "FrontBrake": minColumn = "MinFrontBrake"; break;
                    case "RearBrake": minColumn = "MinRearBrake"; break;
                    case "HandBrake": minColumn = "MinHandBrake"; break;
                    case "DiffFrontBrake": maxColumn = "MaxDiffFrontBrake"; break;
                    case "DiffRearBrake": maxColumn = "MaxDiffRearBrake"; break;
                    case "DiffHandBrake": maxColumn = "MaxDiffHandBrake"; break;
                    case "Noise": maxColumn = "MaxNoise"; break;
                    case "Whistle": minColumn = "MinWhistle"; maxColumn = "MaxWhistle"; break;
                    case "SideSlip": minColumn = "MinSideSlip"; maxColumn = "MaxSideSlip"; break;
                    case "HC": maxColumn = "MaxHC"; break;
                    case "CO": maxColumn = "MaxCO"; break;
                    default:
                        return false;
                }

                var standard = db.VehicleStandards.FirstOrDefault(s => s.VehicleType == vehicleType);
                if (standard == null) return true;

                var minValue = !string.IsNullOrEmpty(minColumn)
                    ? (decimal?)typeof(VehicleStandard).GetProperty(minColumn)?.GetValue(standard)
                    : null;
                var maxValue = !string.IsNullOrEmpty(maxColumn)
                    ? (decimal?)typeof(VehicleStandard).GetProperty(maxColumn)?.GetValue(standard)
                    : null;

                if (!minValue.HasValue && !maxValue.HasValue) return true;
                if (minValue.HasValue && value < minValue.Value) return false;
                if (maxValue.HasValue && value > maxValue.Value) return false;

                return true;
            }
        }

        public string GetVehicleTypeBySampleVin(string inputVin)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                return db.VehicleStandards
                         .Where(v => inputVin.StartsWith(v.SampleVin))
                         .OrderByDescending(v => v.SampleVin.Length)
                         .Select(v => v.VehicleType)
                         .FirstOrDefault();
            }
        }
    }
}
