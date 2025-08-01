using SenAIS.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenAIS.Core.Repositories
{
    public class CalibrationRepository
    {
        private readonly string _connectionString;
        public CalibrationRepository()
        {
            _connectionString = AppSettingsHelper.GetDatabaseConnectionString();
        }
        public object GetParameterValue(string paraType, string columnName)
        {
            using (var db = new SenAISDB_HDEntities(_connectionString))
            {
                var calibration = db.Calibrations.FirstOrDefault(c => c.ParaType == paraType);

                if (calibration == null)
                    return null;

                switch (columnName)
                {
                    case "ParaA": return calibration.ParaA;
                    case "ParaB": return calibration.ParaB;
                    default: return null;
                }
            }
        }

        public void UpdateCalibrationData(string paraType, decimal paraA, decimal paraB)
        {
            using (var db = new SenAISDB_HDEntities(_connectionString))
            {
                var calibration = db.Calibrations.FirstOrDefault(c => c.ParaType == paraType);

                if (calibration != null)
                {
                    calibration.ParaA = paraA;
                    calibration.ParaB = paraB;
                }

                db.SaveChanges();
            }
        }

        public double GetParaValue(string paraType, string columnName)
        {
            object result = GetParameterValue(paraType, columnName);
            double defaultValue = (columnName == "ParaA") ? 1.0 : 0.0;

            if (result != null && double.TryParse(result.ToString(), out double paraValue))
            {
                return paraValue;
            }

            return defaultValue;
        }
    }
}
