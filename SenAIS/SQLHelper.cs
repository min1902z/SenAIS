using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenAIS
{
    public class SQLHelper
    {
        private string connectionString;

        public SQLHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddRange(parameters);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public SqlDataReader ExecuteReader(string query, params SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddRange(parameters);
            connection.Open();
            return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }
        public object GetParameterValue(string paraType, string columnName)
        {
            string query = $"SELECT {columnName} FROM Calibration WHERE ParaType = @ParaType";
            SqlParameter paraTypeParam = new SqlParameter("@ParaType", paraType);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(paraTypeParam);
                connection.Open();
                return command.ExecuteScalar();
            }
        }
        public void UpdateCalibrationData(string paraType, decimal paraA, decimal paraB)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Calibration SET ParaA = @ParaA, ParaB = @ParaB WHERE ParaType = @ParaType";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ParaType", paraType);
                    command.Parameters.AddWithValue("@ParaA", paraA);
                    command.Parameters.AddWithValue("@ParaB", paraB);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public double GetParaValue(string paraType, string columnName)
        {
            // Thực thi truy vấn và lấy giá trị
            object result = GetParameterValue(paraType, columnName);

            // Xác định giá trị mặc định theo cột
            double defaultValue = (columnName == "ParaA") ? 1.0 : 0.0;

            // Chuyển đổi giá trị kết quả về kiểu double
            if (result != null && double.TryParse(result.ToString(), out double paraValue))
            {
                return paraValue;
            }

            // Trả về giá trị mặc định nếu không có kết quả hoặc không thể chuyển đổi
            return defaultValue;
        }
        public void SaveGasEmissionData(string serialNumber, decimal hcValue, decimal coValue, decimal co2Value, decimal o2Value, decimal noValue, decimal oilTemp, decimal rpm)
        {
            string query = @"IF EXISTS (SELECT 1 FROM GasEmission_Petrol WHERE SerialNumber = @SerialNumber)
                         BEGIN
                             UPDATE GasEmission_Petrol 
                             SET HC = @HC, CO = @CO, CO2 = @CO2, O2 = @O2, NO = @NO, OilTemp = @OilTemp, RPM = @RPM 
                             WHERE SerialNumber = @SerialNumber
                         END
                         ELSE
                         BEGIN
                             INSERT INTO GasEmission_Petrol (SerialNumber, HC, CO, CO2, O2, NO, OilTemp, RPM)
                             VALUES (@SerialNumber, @HC, @CO, @CO2, @O2, @NO, @OilTemp, @RPM)
                         END";
            var parameters = new[]
            {
            new SqlParameter("@HC", hcValue),
            new SqlParameter("@CO", coValue),
            new SqlParameter("@CO2", co2Value),
            new SqlParameter("@O2", o2Value),
            new SqlParameter("@NO", noValue),
            new SqlParameter("@OilTemp", oilTemp),
            new SqlParameter("@RPM", rpm),
            new SqlParameter("@SerialNumber", serialNumber)
        };

            ExecuteQuery(query, parameters);
        }
        public void SaveSpeedData(string serialNumber, decimal speedValue)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"IF EXISTS (SELECT 1 FROM Speed WHERE SerialNumber = @SerialNumber)
                         BEGIN
                             UPDATE Speed 
                             SET Speed = @Speed
                             WHERE SerialNumber = @SerialNumber
                         END
                         ELSE
                         BEGIN
                             INSERT INTO Speed (SerialNumber, Speed)
                             VALUES (@SerialNumber, @Speed)
                         END";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Speed", speedValue);
                    cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SaveNoiseData(string serialNumber, decimal noiseValue)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"IF EXISTS (SELECT 1 FROM Noise WHERE SerialNumber = @SerialNumber)
                         BEGIN
                             UPDATE Noise 
                             SET Noise = @Noise
                             WHERE SerialNumber = @SerialNumber
                         END
                         ELSE
                         BEGIN
                             INSERT INTO Noise (SerialNumber, Noise)
                             VALUES (@SerialNumber, @Noise)
                         END";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Speed", noiseValue);
                    cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SaveVehicleInfo(string vehicleType, string inspector, string frameNumber, string engineNumber, string serialNumber, DateTime inspectionDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    IF EXISTS (SELECT 1 FROM VehicleInfo WHERE SerialNumber = @SerialNumber)
                    BEGIN
                        UPDATE VehicleInfo
                        SET VehicleType = @VehicleType,
                            Inspector = @Inspector,
                            FrameNumber = @FrameNumber,
                            EngineNumber = @EngineNumber,
                            InspectionDate = @InspectionDate
                        WHERE SerialNumber = @SerialNumber
                    END
                    ELSE
                    BEGIN
                        INSERT INTO VehicleInfo (VehicleType, Inspector, FrameNumber, EngineNumber, SerialNumber, InspectionDate)
                        VALUES (@VehicleType, @Inspector, @FrameNumber, @EngineNumber, @SerialNumber, @InspectionDate)
                    END";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@VehicleType", vehicleType);
                    cmd.Parameters.AddWithValue("@Inspector", inspector);
                    cmd.Parameters.AddWithValue("@FrameNumber", frameNumber);
                    cmd.Parameters.AddWithValue("@EngineNumber", engineNumber);
                    cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                    cmd.Parameters.AddWithValue("@InspectionDate", inspectionDate);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}
