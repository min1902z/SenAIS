using System;
using System.Collections.Generic;
using System.Data;
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
        public void SaveDieselEmissionData(string serialNumber, decimal minSpeed, decimal maxSpeed, decimal hsu)
        {
            string query = @"IF EXISTS (SELECT 1 FROM GasEmission_Diesel WHERE SerialNumber = @SerialNumber)
                         BEGIN
                             UPDATE GasEmission_Diesel 
                             SET MinSpeed = @MinSpeed, MaxSpeed = @MaxSpeed, HSU = @HSU 
                             WHERE SerialNumber = @SerialNumber
                         END
                         ELSE
                         BEGIN
                             INSERT INTO GasEmission_Diesel (SerialNumber, MinSpeed, MaxSpeed, HSU)
                             VALUES (@SerialNumber, @MinSpeed, @MaxSpeed, @HSU)
                         END";
            var parameters = new[]
            {
            new SqlParameter("@MinSpeed", minSpeed),
            new SqlParameter("@MaxSpeed", maxSpeed),
            new SqlParameter("@HSU", hsu),
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
        public void SaveSideSlipData(string serialNumber, decimal sideSlip)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"IF EXISTS (SELECT 1 FROM SideSlip WHERE SerialNumber = @SerialNumber)
                         BEGIN
                             UPDATE SideSlip 
                             SET SideSlip = @SideSlip
                             WHERE SerialNumber = @SerialNumber
                         END
                         ELSE
                         BEGIN
                             INSERT INTO SideSlip (SerialNumber, SideSlip)
                             VALUES (@SerialNumber, @SideSlip)
                         END";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SideSlip", sideSlip);
                    cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SaveFrontWeightData(string serialNumber, decimal leftWeight, decimal rightWeight)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"IF EXISTS (SELECT 1 FROM Weight WHERE SerialNumber = @SerialNumber)
                         BEGIN
                             UPDATE Weight 
                             SET FrontLeftWeight = @FrontLeftWeight, FrontRightWeight = @FrontRightWeight
                             WHERE SerialNumber = @SerialNumber
                         END
                         ELSE
                         BEGIN
                             INSERT INTO Weight (SerialNumber, FrontLeftWeight, FrontRightWeight)
                             VALUES (@SerialNumber, @FrontLeftWeight, @FrontRightWeight)
                         END";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FrontLeftWeight", leftWeight);
                    cmd.Parameters.AddWithValue("@FrontRightWeight", rightWeight);
                    cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SaveRearWeightData(string serialNumber, decimal leftWeight, decimal rightWeight)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"IF EXISTS (SELECT 1 FROM Weight WHERE SerialNumber = @SerialNumber)
                         BEGIN
                             UPDATE Weight 
                             SET RearLeftWeight = @RearLeftWeight, RearRightWeight = @RearRightWeight
                             WHERE SerialNumber = @SerialNumber
                         END
                         ELSE
                         BEGIN
                             INSERT INTO Weight (SerialNumber, RearLeftWeight, RearRightWeight)
                             VALUES (@SerialNumber, @RearLeftWeight, @RearRightWeight)
                         END";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RearLeftWeight", leftWeight);
                    cmd.Parameters.AddWithValue("@RearRightWeight", rightWeight);
                    cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SaveFrontBrakeData(string serialNumber, decimal leftBrake, decimal rightBrake)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"IF EXISTS (SELECT 1 FROM BrakeForce WHERE SerialNumber = @SerialNumber)
                         BEGIN
                             UPDATE BrakeForce 
                             SET FrontLeftBrake = @FrontLeftBrake, FrontRightBrake = @FrontRightBrake
                             WHERE SerialNumber = @SerialNumber
                         END
                         ELSE
                         BEGIN
                             INSERT INTO BrakeForce (SerialNumber, FrontLeftBrake, FrontRightBrake)
                             VALUES (@SerialNumber, @FrontLeftBrake, @FrontRightBrake)
                         END";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FrontLeftBrake", leftBrake);
                    cmd.Parameters.AddWithValue("@FrontRightBrake", rightBrake);
                    cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SaveRearBrakeData(string serialNumber, decimal leftBrake, decimal rightBrake)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"IF EXISTS (SELECT 1 FROM BrakeForce WHERE SerialNumber = @SerialNumber)
                         BEGIN
                             UPDATE BrakeForce 
                             SET RearLeftBrake = @RearLeftBrake, RearRightBrake = @RearRightBrake
                             WHERE SerialNumber = @SerialNumber
                         END
                         ELSE
                         BEGIN
                             INSERT INTO BrakeForce (SerialNumber, RearLeftBrake, RearRightBrake)
                             VALUES (@SerialNumber, @RearLeftBrake, @RearRightBrake)
                         END";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RearLeftBrake", leftBrake);
                    cmd.Parameters.AddWithValue("@RearRightBrake", rightBrake);
                    cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SaveHandBrakeData(string serialNumber, decimal leftBrake, decimal rightBrake)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"IF EXISTS (SELECT 1 FROM BrakeForce WHERE SerialNumber = @SerialNumber)
                         BEGIN
                             UPDATE BrakeForce 
                             SET HandLeftBrake = @HandLeftBrake, HandRightBrake = @HandRightBrake
                             WHERE SerialNumber = @SerialNumber
                         END
                         ELSE
                         BEGIN
                             INSERT INTO BrakeForce (SerialNumber, HandLeftBrake, HandRightBrake)
                             VALUES (@SerialNumber, @HandLeftBrake, @HandRightBrake)
                         END";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@HandLeftBrake", leftBrake);
                    cmd.Parameters.AddWithValue("@HandRightBrake", rightBrake);
                    cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SaveLeftLowBeamData(string serialNumber, decimal intensity, decimal veritiDeviation, decimal horiDeviation)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"IF EXISTS (SELECT 1 FROM LowBeam WHERE SerialNumber = @SerialNumber)
                         BEGIN
                             UPDATE LowBeam 
                             SET LeftIntensity = @LeftIntensity, LeftVerticalDeviation = @LeftVerticalDeviation, LeftHorizontalDeviation = @LeftHorizontalDeviation
                             WHERE SerialNumber = @SerialNumber
                         END
                         ELSE
                         BEGIN
                             INSERT INTO LowBeam (SerialNumber, LeftIntensity, LeftVerticalDeviation, LeftHorizontalDeviation)
                             VALUES (@SerialNumber, @LeftIntensity, @LeftVerticalDeviation, @LeftHorizontalDeviation)
                         END";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LeftIntensity", intensity);
                    cmd.Parameters.AddWithValue("@LeftVerticalDeviation", veritiDeviation);
                    cmd.Parameters.AddWithValue("@LeftHorizontalDeviation", horiDeviation);
                    cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SaveLeftHeadLightData(string serialNumber, decimal intensity, decimal veritiDeviation, decimal horiDeviation)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"IF EXISTS (SELECT 1 FROM HeadLights WHERE SerialNumber = @SerialNumber)
                         BEGIN
                             UPDATE HeadLights 
                             SET LeftIntensity = @LeftIntensity, LeftVerticalDeviation = @LeftVerticalDeviation, LeftHorizontalDeviation = @LeftHorizontalDeviation
                             WHERE SerialNumber = @SerialNumber
                         END
                         ELSE
                         BEGIN
                             INSERT INTO HeadLights (SerialNumber, LeftIntensity, LeftVerticalDeviation, LeftHorizontalDeviation)
                             VALUES (@SerialNumber, @LeftIntensity, @LeftVerticalDeviation, @LeftHorizontalDeviation)
                         END";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LeftIntensity", intensity);
                    cmd.Parameters.AddWithValue("@LeftVerticalDeviation", veritiDeviation);
                    cmd.Parameters.AddWithValue("@LeftHorizontalDeviation", horiDeviation);
                    cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SaveRightLowBeamData(string serialNumber, decimal intensity, decimal veritiDeviation, decimal horiDeviation)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"IF EXISTS (SELECT 1 FROM LowBeam WHERE SerialNumber = @SerialNumber)
                         BEGIN
                             UPDATE LowBeam 
                             SET RightIntensity = @RightIntensity, RightVerticalDeviation = @RightVerticalDeviation, RightHorizontalDeviation = @RightHorizontalDeviation
                             WHERE SerialNumber = @SerialNumber
                         END
                         ELSE
                         BEGIN
                             INSERT INTO LowBeam (SerialNumber, RightIntensity, RightVerticalDeviation, RightHorizontalDeviation)
                             VALUES (@SerialNumber, @RightIntensity, @RightVerticalDeviation, @RightHorizontalDeviation)
                         END";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RightIntensity", intensity);
                    cmd.Parameters.AddWithValue("@RightVerticalDeviation", veritiDeviation);
                    cmd.Parameters.AddWithValue("@RightHorizontalDeviation", horiDeviation);
                    cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SaveRightHeadLightData(string serialNumber, decimal intensity, decimal veritiDeviation, decimal horiDeviation)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"IF EXISTS (SELECT 1 FROM HeadLights WHERE SerialNumber = @SerialNumber)
                         BEGIN
                             UPDATE HeadLights 
                             SET RightIntensity = @RightIntensity, RightVerticalDeviation = @RightVerticalDeviation, RightHorizontalDeviation = @RightHorizontalDeviation
                             WHERE SerialNumber = @SerialNumber
                         END
                         ELSE
                         BEGIN
                             INSERT INTO HeadLights (SerialNumber, RightIntensity, RightVerticalDeviation, RightHorizontalDeviation)
                             VALUES (@SerialNumber, @RightIntensity, @RightVerticalDeviation, @RightHorizontalDeviation)
                         END";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RightIntensity", intensity);
                    cmd.Parameters.AddWithValue("@RightVerticalDeviation", veritiDeviation);
                    cmd.Parameters.AddWithValue("@RightHorizontalDeviation", horiDeviation);
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
        public void SaveWhistleData(string serialNumber, decimal whistle)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"IF EXISTS (SELECT 1 FROM Whistle WHERE SerialNumber = @SerialNumber)
                         BEGIN
                             UPDATE Whistle 
                             SET Whistle = @Whistle
                             WHERE SerialNumber = @SerialNumber
                         END
                         ELSE
                         BEGIN
                             INSERT INTO Whistle (SerialNumber, Whistle)
                             VALUES (@SerialNumber, @Whistle)
                         END";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Speed", whistle);
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
        public DataTable TableExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
        public DataTable SearchVehicleInfo(string searchTerm)
        {
            string query = @"
            SELECT FrameNumber, VehicleType, Inspector, EngineNumber, SerialNumber, InspectionDate 
            FROM VehicleInfo 
            WHERE 
                SerialNumber LIKE @SearchTerm OR
                FrameNumber LIKE @SearchTerm OR
                VehicleType LIKE @SearchTerm OR
                Inspector LIKE @SearchTerm OR
                EngineNumber LIKE @SearchTerm OR
                InspectionDate LIKE @SearchTerm";

            var parameters = new[]
            {
            new SqlParameter("@SearchTerm", "%" + searchTerm + "%")
        };

            return TableExecuteQuery(query, parameters);
        }

        public DataRow GetVehicleDetails(string serialNumber)
        {
            string query = @"SELECT 
                            vi.SerialNumber,
                            vi.FrameNumber,
                            vi.VehicleType,
                            vi.Inspector,
                            vi.EngineNumber,
                            vi.InspectionDate,
                            sp.Speed,
                            ss.SideSlip,
	                        we.FrontLeftWeight,
	                        we.FrontRightWeight,
	                        we.RearLeftWeight,
	                        we.RearRightWeight,
	                        bf.FrontLeftBrake,
	                        bf.FrontRightBrake,
	                        bf.RearLeftBrake,
	                        bf.RearRightBrake,
	                        bf.HandBrakeLeft,
	                        bf.HandBrakeRight,
	                        ns.Noise,
	                        ns.Whistle,
	                        hl.[LeftIntensity] AS LHLIntensity,
                            hl.[LeftVerticalDeviation] AS LHLVertical,
                            hl.[LeftHorizontalDeviation] AS LHLHorizontal,
                            hl.[RightIntensity] AS RHLIntensity,
                            hl.[RightVerticalDeviation] AS RHLVertical,
                            hl.[RightHorizontalDeviation] AS RHLHorizontal,
	                        lb.[LeftIntensity] AS LLBIntensity,
                            lb.[LeftVerticalDeviation] AS LLBVertical,
                            lb.[LeftHorizontalDeviation] AS LLBHorizontal,
                            lb.[RightIntensity] AS RLBIntensity,
                            lb.[RightVerticalDeviation] AS RLBVertical,
                            lb.[RightHorizontalDeviation] AS RLBHorizontal,
	                        pe.[HC],
                            pe.[CO],
                            pe.[CO2],
                            pe.[O2],
                            pe.[NO],
                            pe.[OilTemp],
                            pe.[RPM],
	                        de.[MinSpeed],
                            de.[MaxSpeed],
                            de.[HSU]

                        FROM 
                            VehicleInfo vi
                        LEFT JOIN 
                            Speed sp ON vi.SerialNumber = sp.SerialNumber
                        LEFT JOIN 
                            SideSlip ss ON vi.SerialNumber = ss.SerialNumber
                        LEFT JOIN 
                            Weight we ON vi.SerialNumber = we.SerialNumber
                        LEFT JOIN 
                            BrakeForce bf ON vi.SerialNumber = bf.SerialNumber
                        LEFT JOIN 
                            Noise ns ON vi.SerialNumber = ns.SerialNumber
                        LEFT JOIN 
                            Headlights hl ON vi.SerialNumber = hl.SerialNumber
                        LEFT JOIN 
                            LowBeam lb ON vi.SerialNumber = lb.SerialNumber
                        LEFT JOIN 
                            GasEmission_Petrol pe ON vi.SerialNumber = pe.SerialNumber
                        LEFT JOIN 
                            GasEmission_Diesel de ON vi.SerialNumber = de.SerialNumber
                        WHERE 
                            vi.SerialNumber = @SerialNumber";

            var parameters = new[]
            {
            new SqlParameter("@SerialNumber", serialNumber)
        };

            DataTable result = TableExecuteQuery(query, parameters);

            return result.Rows.Count > 0 ? result.Rows[0] : null;
        }
    }

}
