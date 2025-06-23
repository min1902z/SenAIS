using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SenAIS
{
    public class SQLHelper
    {
        private string connectionString;

        public SQLHelper()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["SenAISDBConnectionString"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Chuỗi kết nối không được tìm thấy hoặc rỗng.");
            }
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
        public void SaveGasEmissionData(string serialNumber, decimal hcValue, decimal coValue, decimal co2Value, decimal o2Value, decimal noValue, decimal oilTemp, decimal rpm, decimal lamda)
        {
            string query = @"IF EXISTS (SELECT 1 FROM GasEmission_Petrol WHERE SerialNumber = @SerialNumber)
                         BEGIN
                             UPDATE GasEmission_Petrol 
                             SET HC = @HC, CO = @CO, CO2 = @CO2, O2 = @O2, NO = @NO, OilTemp = @OilTemp, RPM = @RPM , Lambda = @Lambda
                             WHERE SerialNumber = @SerialNumber
                         END
                         ELSE
                         BEGIN
                             INSERT INTO GasEmission_Petrol (SerialNumber, HC, CO, CO2, O2, NO, OilTemp, RPM, Lambda)
                             VALUES (@SerialNumber, @HC, @CO, @CO2, @O2, @NO, @OilTemp, @RPM, @Lambda)
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
            new SqlParameter("@Lambda", lamda),
            new SqlParameter("@SerialNumber", serialNumber)
        };

            ExecuteQuery(query, parameters);
        }
        public void SaveDieselEmissionData(string serialNumber, decimal minSpeed1, decimal maxSpeed1, decimal hsu1, decimal minSpeed2, decimal maxSpeed2, decimal hsu2, decimal minSpeed3, decimal maxSpeed3, decimal hsu3)
        {
            string query = @"IF EXISTS (SELECT 1 FROM GasEmission_Diesel WHERE SerialNumber = @SerialNumber)
                         BEGIN
                             UPDATE GasEmission_Diesel 
                             SET MinSpeed1 = @MinSpeed1, MaxSpeed1 = @MaxSpeed1, HSU1 = @HSU1, MinSpeed2 = @MinSpeed2, MaxSpeed2 = @MaxSpeed2, HSU2 = @HSU2, MinSpeed3 = @MinSpeed3, MaxSpeed3 = @MaxSpeed3, HSU3 = @HSU3
                             WHERE SerialNumber = @SerialNumber
                         END
                         ELSE
                         BEGIN
                             INSERT INTO GasEmission_Diesel (SerialNumber, MinSpeed1, MaxSpeed1, HSU1, MinSpeed2, MaxSpeed2, HSU2,MinSpeed3, MaxSpeed3, HSU3)
                             VALUES (@SerialNumber, @MinSpeed1, @MaxSpeed1, @HSU1, @MinSpeed2, @MaxSpeed2, @HSU2, @MinSpeed3, @MaxSpeed3, @HSU3)
                         END";
            var parameters = new[]
            {
            new SqlParameter("@MinSpeed1", minSpeed1),
            new SqlParameter("@MaxSpeed1", maxSpeed1),
            new SqlParameter("@HSU1", hsu1),
            new SqlParameter("@MinSpeed2", minSpeed2),
            new SqlParameter("@MaxSpeed2", maxSpeed2),
            new SqlParameter("@HSU2", hsu2),
            new SqlParameter("@MinSpeed3", minSpeed3),
            new SqlParameter("@MaxSpeed3", maxSpeed3),
            new SqlParameter("@HSU3", hsu3),
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
                             SET HandBrakeLeft = @HandBrakeLeft, HandBrakeRight = @HandBrakeRight
                             WHERE SerialNumber = @SerialNumber
                         END
                         ELSE
                         BEGIN
                             INSERT INTO BrakeForce (SerialNumber, HandBrakeLeft, HandBrakeRight)
                             VALUES (@SerialNumber, @HandBrakeLeft, @HandBrakeRight)
                         END";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@HandBrakeLeft", leftBrake);
                    cmd.Parameters.AddWithValue("@HandBrakeRight", rightBrake);
                    cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SaveHeadlightsData(string serialNumber, decimal leftHBIntensityValue, decimal leftHBVerticalValue, decimal leftHBHorizontalValue,
                                                                    decimal rightHBIntensityValue, decimal rightHBVerticalValue, decimal rightHBHorizontalValue,
                                                                    decimal leftLBIntensityValue, decimal leftLBVerticalValue, decimal leftLBHorizontalValue,
                                                                    decimal rightLBIntensityValue, decimal rightLBVerticalValue, decimal rightLBHorizontalValue,
                                                                    decimal rightHBHeightValue, decimal rightLBHeightValue, decimal leftHBHeightValue, decimal leftLBHeightValue)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"IF EXISTS (SELECT 1 FROM Headlights WHERE SerialNumber = @SerialNumber)
                         BEGIN
                             UPDATE Headlights 
                             SET LeftHBIntensity = @LeftHBIntensity, LeftHBVerticalDeviation = @LeftHBVerticalDeviation, LeftHBHorizontalDeviation = @LeftHBHorizontalDeviation, 
                                    RightHBIntensity = @RightHBIntensity, RightHBVerticalDeviation = @RightHBVerticalDeviation, RightHBHorizontalDeviation = @RightHBHorizontalDeviation,
                                    LeftLBIntensity = @LeftLBIntensity, LeftLBVerticalDeviation = @LeftLBVerticalDeviation, LeftLBHorizontalDeviation = @LeftLBHorizontalDeviation, 
                                    RightLBIntensity = @RightLBIntensity, RightLBVerticalDeviation = @RightLBVerticalDeviation, RightLBHorizontalDeviation = @RightLBHorizontalDeviation,
                                    RightHBHeight = @RightHBHeight, RightLBHeight = @RightLBHeight, LeftHBHeight = @LeftHBHeight, LeftLBHeight = @LeftLBHeight
                             WHERE SerialNumber = @SerialNumber
                         END
                         ELSE
                         BEGIN
                             INSERT INTO Headlights (SerialNumber, LeftHBIntensity, LeftHBVerticalDeviation, LeftHBHorizontalDeviation, 
                                                                                                    RightHBIntensity, RightHBVerticalDeviation, RightHBHorizontalDeviation, 
                                                                                                    LeftLBIntensity, LeftLBVerticalDeviation, LeftLBHorizontalDeviation, 
                                                                                                    RightLBIntensity, RightLBVerticalDeviation, RightLBHorizontalDeviation,
                                                                                                    RightHBHeight, RightLBHeight, LeftHBHeight, LeftLBHeight)
                             VALUES (@SerialNumber, @LeftHBIntensity, @LeftHBVerticalDeviation, @LeftHBHorizontalDeviation, 
                                                                            @RightHBIntensity, @RightHBVerticalDeviation, @RightHBHorizontalDeviation, 
                                                                            @LeftLBIntensity, @LeftLBVerticalDeviation, @LeftLBHorizontalDeviation, 
                                                                            @RightLBIntensity, @RightLBVerticalDeviation, @RightLBHorizontalDeviation,
                                                                            @RightHBHeight, @RightLBHeight, @LeftHBHeight, @LeftLBHeight)
                         END";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LeftHBIntensity", leftHBIntensityValue);
                    cmd.Parameters.AddWithValue("@LeftHBVerticalDeviation", leftHBVerticalValue);
                    cmd.Parameters.AddWithValue("@LeftHBHorizontalDeviation", leftHBHorizontalValue);
                    cmd.Parameters.AddWithValue("@RightHBIntensity", rightHBIntensityValue);
                    cmd.Parameters.AddWithValue("@RightHBVerticalDeviation", rightHBVerticalValue);
                    cmd.Parameters.AddWithValue("@RightHBHorizontalDeviation", rightHBHorizontalValue);
                    cmd.Parameters.AddWithValue("@LeftLBIntensity", leftHBIntensityValue);
                    cmd.Parameters.AddWithValue("@LeftLBVerticalDeviation", leftHBVerticalValue);
                    cmd.Parameters.AddWithValue("@LeftLBHorizontalDeviation", leftHBHorizontalValue);
                    cmd.Parameters.AddWithValue("@RightLBIntensity", rightHBIntensityValue);
                    cmd.Parameters.AddWithValue("@RightLBVerticalDeviation", rightHBVerticalValue);
                    cmd.Parameters.AddWithValue("@RightLBHorizontalDeviation", rightHBHorizontalValue);
                    cmd.Parameters.AddWithValue("@RightHBHeight", rightHBHeightValue);
                    cmd.Parameters.AddWithValue("@RightLBHeight", rightLBHeightValue);
                    cmd.Parameters.AddWithValue("@LeftHBHeight", leftHBHeightValue);
                    cmd.Parameters.AddWithValue("@LeftLBHeight", leftLBHeightValue);
                    cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SaveFogLightsData(string serialNumber, decimal rightFLIntensityValue, decimal rightFLVerticalValue, decimal rightFLHorizontalValue, decimal rightFLHeightValue,
                                                                                        decimal leftFLIntensityValue, decimal leftFLVerticalValue, decimal leftFLHorizontalValue, decimal leftFLHeightValue)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"IF EXISTS (SELECT 1 FROM Headlights WHERE SerialNumber = @SerialNumber)
                 BEGIN
                     UPDATE Headlights 
                     SET LeftFLIntensity = @LeftFLIntensity, LeftFLVerticalDeviation = @LeftFLVerticalDeviation, LeftFLHorizontalDeviation = @LeftFLHorizontalDeviation, LeftFLHeight = @LeftFLHeight,
                            RightFLIntensity = @RightFLIntensity, RightFLVerticalDeviation = @RightFLVerticalDeviation, RightFLHorizontalDeviation = @RightFLHorizontalDeviation, RightFLHeight = @RightFLHeight
                     WHERE SerialNumber = @SerialNumber
                 END
                 ELSE
                 BEGIN
                     INSERT INTO Headlights (SerialNumber, LeftFLIntensity, LeftFLVerticalDeviation, LeftFLHorizontalDeviation, LeftFLHeight,
                                                       RightFLIntensity, RightFLVerticalDeviation, RightFLHorizontalDeviation, RightFLHeight)
                     VALUES (@SerialNumber, @LeftFLIntensity, @LeftFLVerticalDeviation, @LeftFLHorizontalDeviation, @LeftFLHeight,
                                    @RightFLIntensity, @RightFLVerticalDeviation, @RightFLHorizontalDeviation, @RightFLHeight)
                 END";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LeftFLIntensity", leftFLIntensityValue);
                    cmd.Parameters.AddWithValue("@LeftFLVerticalDeviation", leftFLVerticalValue);
                    cmd.Parameters.AddWithValue("@LeftFLHorizontalDeviation", leftFLHorizontalValue);
                    cmd.Parameters.AddWithValue("@LeftFLHeight", leftFLHeightValue);

                    cmd.Parameters.AddWithValue("@RightFLIntensity", rightFLIntensityValue);
                    cmd.Parameters.AddWithValue("@RightFLVerticalDeviation", rightFLVerticalValue);
                    cmd.Parameters.AddWithValue("@RightFLHorizontalDeviation", rightFLHorizontalValue);
                    cmd.Parameters.AddWithValue("@RightFLHeight", rightFLHeightValue);

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
                    cmd.Parameters.AddWithValue("@Noise", noiseValue);
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
                string query = @"IF EXISTS (SELECT 1 FROM Noise WHERE SerialNumber = @SerialNumber)
                         BEGIN
                             UPDATE Noise 
                             SET Whistle = @Whistle
                             WHERE SerialNumber = @SerialNumber
                         END
                         ELSE
                         BEGIN
                             INSERT INTO Noise (SerialNumber, Whistle)
                             VALUES (@SerialNumber, @Whistle)
                         END";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Whistle", whistle);
                    cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SaveSteerAngleData(string serialNumber, decimal leftSteerLW, decimal rightSteerLW, decimal leftSteerRW, decimal rightSteerRW)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"IF EXISTS (SELECT 1 FROM SteerAngle WHERE SerialNumber = @SerialNumber)
                         BEGIN
                             UPDATE SteerAngle 
                             SET LeftSteerLW = @LeftSteerLW, RightSteerLW = @RightSteerLW, LeftSteerRW = @LeftSteerRW, RightSteerRW = @RightSteerRW
                             WHERE SerialNumber = @SerialNumber
                         END
                         ELSE
                         BEGIN
                             INSERT INTO SteerAngle (SerialNumber, LeftSteerLW, RightSteerLW, LeftSteerRW, RightSteerRW)
                             VALUES (@SerialNumber, @LeftSteerLW, @RightSteerLW, @LeftSteerRW, @RightSteerRW)
                         END";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LeftSteerLW", leftSteerLW);
                    cmd.Parameters.AddWithValue("@RightSteerLW", rightSteerLW);
                    cmd.Parameters.AddWithValue("@LeftSteerRW", leftSteerRW);
                    cmd.Parameters.AddWithValue("@RightSteerRW", rightSteerRW);
                    cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SaveVehicleInfo(string vehicleType, string inspector, string frameNumber, string serialNumber, DateTime inspectionDate, string fuelType)
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
                            InspectionDate = @InspectionDate,
                            Fuel = @Fuel
                        WHERE SerialNumber = @SerialNumber
                    END
                    ELSE
                    BEGIN
                        INSERT INTO VehicleInfo (VehicleType, Inspector, FrameNumber, SerialNumber, InspectionDate, Fuel)
                        VALUES (@VehicleType, @Inspector, @FrameNumber, @SerialNumber, @InspectionDate, @Fuel)
                    END";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@VehicleType", vehicleType);
                    cmd.Parameters.AddWithValue("@Inspector", inspector);
                    cmd.Parameters.AddWithValue("@FrameNumber", frameNumber);
                    cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
                    cmd.Parameters.AddWithValue("@InspectionDate", inspectionDate);
                    cmd.Parameters.AddWithValue("@Fuel", fuelType);

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
            SELECT SerialNumber, FrameNumber, VehicleType, Inspector, InspectionDate, Fuel, Color, EngineType
            FROM VehicleInfo 
            WHERE 
                SerialNumber LIKE @SearchTerm OR
                FrameNumber LIKE @SearchTerm OR
                VehicleType LIKE @SearchTerm OR
                Inspector LIKE @SearchTerm OR
                InspectionDate LIKE @SearchTerm OR
                Fuel LIKE @SearchTerm OR
                Color LIKE @SearchTerm OR
                EngineType LIKE @SearchTerm";

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
                            vi.InspectionDate,
                            vi.Fuel,
                            vi.Color,
                            vi.EngineType,
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
	                        hl.[LeftHBIntensity] AS LHLIntensity,
                            hl.[LeftHBVerticalDeviation] AS LHLVertical,
                            hl.[LeftHBHorizontalDeviation] AS LHLHorizontal,
                            hl.[RightHBIntensity] AS RHLIntensity,
                            hl.[RightHBVerticalDeviation] AS RHLVertical,
                            hl.[RightHBHorizontalDeviation] AS RHLHorizontal,
	                        hl.[LeftLBIntensity] AS LLBIntensity,
                            hl.[LeftLBVerticalDeviation] AS LLBVertical,
                            hl.[LeftLBHorizontalDeviation] AS LLBHorizontal,
                            hl.[RightLBIntensity] AS RLBIntensity,
                            hl.[RightLBVerticalDeviation] AS RLBVertical,
                            hl.[RightLBHorizontalDeviation] AS RLBHorizontal,
                            hl.[RightHBHeight] AS RHBHeight,
                            hl.[RightLBHeight] AS RLBHeight,
                            hl.[LeftHBHeight] AS LHBHeight,
                            hl.[LeftLBHeight] AS LLBHeight,
                            hl.[LeftFLHeight] AS LFLHeight,
	                        hl.[LeftFLIntensity] AS LFLIntensity,
                            hl.[LeftFLVerticalDeviation] AS LFLVertical,
                            hl.[LeftFLHorizontalDeviation] AS LFLHorizontal,
                            hl.[RightFLHeight] AS RFLHeight,
	                        hl.[RightFLIntensity] AS RFLIntensity,
                            hl.[RightFLVerticalDeviation] AS RFLVertical,
                            hl.[RightFLHorizontalDeviation] AS RFLHorizontal,
	                        pe.[HC],
                            pe.[CO],
                            pe.[CO2],
                            pe.[O2],
                            pe.[NO],
                            pe.[OilTemp],
                            pe.[RPM],
                            pe.[Lambda],
	                        de.[MinSpeed1],
                            de.[MaxSpeed1],
                            de.[HSU1],
                            de.[MinSpeed2],
                            de.[MaxSpeed2],
                            de.[HSU2],
                            de.[MinSpeed3],
                            de.[MaxSpeed3],
                            de.[HSU3],
                            sa.LeftSteerLW,
                            sa.LeftSteerRW,
                            sa.RightSteerLW,
                            sa.RightSteerRW

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
                            GasEmission_Petrol pe ON vi.SerialNumber = pe.SerialNumber
                        LEFT JOIN 
                            GasEmission_Diesel de ON vi.SerialNumber = de.SerialNumber
                        LEFT JOIN 
                            SteerAngle sa ON vi.SerialNumber = sa.SerialNumber
                        WHERE 
                            vi.SerialNumber = @SerialNumber";

            var parameters = new[]
            {
            new SqlParameter("@SerialNumber", serialNumber)
        };

            DataTable result = TableExecuteQuery(query, parameters);

            return result.Rows.Count > 0 ? result.Rows[0] : null;
        }
        public DataTable GetVehicleStandardsData()
        {
            string query = "SELECT * FROM VehicleStandards";
            return TableExecuteQuery(query, null);
        }

        public void UpdateVehicleStandardsData(DataTable dataTable)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM VehicleStandards";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(dataTable);
            }
        }
        public DataTable GetInspectorData()
        {
            string query = "SELECT * FROM Inspector";
            return TableExecuteQuery(query, null);
        }
        public void UpdateInspectorData(DataTable dataTable)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Inspector";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(dataTable);
            }
        }
        public DataTable GetTypeCarList()
        {
            string query = "SELECT VehicleType FROM VehicleStandards";
            return TableExecuteQuery(query);
        }

        public DataTable GetInspectorList()
        {
            string query = "SELECT InspectorName FROM Inspector";
            return TableExecuteQuery(query);
        }
        public DataTable GetFuelTypeBySerialNumber(string serialNumber)
        {
            string query = "SELECT Fuel FROM VehicleInfo WHERE SerialNumber = @SerialNumber";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SerialNumber", serialNumber)
            };
            return TableExecuteQuery(query, parameters);
        }
        public DataTable GetVehicleStandardsByTypeCar(string vehicleType)
        {
            string query = "SELECT * FROM VehicleStandards WHERE VehicleType = @VehicleType";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@VehicleType", vehicleType)
            };
            return TableExecuteQuery(query, parameters);
        }
        public void UpdateSpeed(string serialNumber, decimal? speed)
        {
            string query = @"
            IF EXISTS (SELECT 1 FROM Speed WHERE SerialNumber = @SerialNumber)
                UPDATE Speed 
                SET Speed = @Speed
                WHERE SerialNumber = @SerialNumber;
            ELSE
                INSERT INTO Speed (SerialNumber, Speed)
                VALUES (@SerialNumber, @Speed);";

            var parameters = new[]
            {
        new SqlParameter("@SerialNumber", serialNumber),
        new SqlParameter("@Speed", speed ?? (object)DBNull.Value)
            };

            ExecuteQuery(query, parameters);
        }
        public void UpdateSideSlip(string serialNumber, decimal? sideSlip)
        {
            string query = @"
            IF EXISTS (SELECT 1 FROM SideSlip WHERE SerialNumber = @SerialNumber)
                UPDATE SideSlip 
                SET SideSlip = @SideSlip
                WHERE SerialNumber = @SerialNumber;
            ELSE
                INSERT INTO SideSlip (SerialNumber, SideSlip)
                VALUES (@SerialNumber, @SideSlip);";

            var parameters = new[]
            {
        new SqlParameter("@SerialNumber", serialNumber),
        new SqlParameter("@SideSlip", sideSlip ?? (object)DBNull.Value)
    };

            ExecuteQuery(query, parameters);
        }
        public void UpdateWeight(string serialNumber, decimal? frontLeftWeight, decimal? frontRightWeight, decimal? rearLeftWeight, decimal? rearRightWeight)
        {
            string query = @"
            IF EXISTS (SELECT 1 FROM Weight WHERE SerialNumber = @SerialNumber)
                UPDATE Weight 
                SET FrontLeftWeight = @FrontLeftWeight, 
                    FrontRightWeight = @FrontRightWeight, 
                    RearLeftWeight = @RearLeftWeight, 
                    RearRightWeight = @RearRightWeight
                WHERE SerialNumber = @SerialNumber;
            ELSE
                INSERT INTO Weight (SerialNumber, FrontLeftWeight, FrontRightWeight, RearLeftWeight, RearRightWeight)
                VALUES (@SerialNumber, @FrontLeftWeight, @FrontRightWeight, @RearLeftWeight, @RearRightWeight);";

            var parameters = new[]
            {
        new SqlParameter("@SerialNumber", serialNumber),
        new SqlParameter("@FrontLeftWeight", frontLeftWeight ?? (object)DBNull.Value),
        new SqlParameter("@FrontRightWeight", frontRightWeight ?? (object)DBNull.Value),
        new SqlParameter("@RearLeftWeight", rearLeftWeight ?? (object)DBNull.Value),
        new SqlParameter("@RearRightWeight", rearRightWeight ?? (object)DBNull.Value)
    };

            ExecuteQuery(query, parameters);
        }
        public void UpdateBrakeForce(string serialNumber, decimal? frontLeftBrake, decimal? frontRightBrake, decimal? rearLeftBrake, decimal? rearRightBrake, decimal? handBrakeLeft, decimal? handBrakeRight)
        {
            string query = @"
            IF EXISTS (SELECT 1 FROM BrakeForce WHERE SerialNumber = @SerialNumber)
                UPDATE BrakeForce 
                SET FrontLeftBrake = @FrontLeftBrake, 
                    FrontRightBrake = @FrontRightBrake, 
                    RearLeftBrake = @RearLeftBrake, 
                    RearRightBrake = @RearRightBrake, 
                    HandBrakeLeft = @HandBrakeLeft, 
                    HandBrakeRight = @HandBrakeRight
                WHERE SerialNumber = @SerialNumber;
            ELSE
                INSERT INTO BrakeForce (SerialNumber, FrontLeftBrake, FrontRightBrake, RearLeftBrake, RearRightBrake, HandBrakeLeft, HandBrakeRight)
                VALUES (@SerialNumber, @FrontLeftBrake, @FrontRightBrake, @RearLeftBrake, @RearRightBrake, @HandBrakeLeft, @HandBrakeRight);";

            var parameters = new[]
            {
        new SqlParameter("@SerialNumber", serialNumber),
        new SqlParameter("@FrontLeftBrake", frontLeftBrake ??(object) DBNull.Value),
        new SqlParameter("@FrontRightBrake", frontRightBrake ??(object) DBNull.Value),
        new SqlParameter("@RearLeftBrake", rearLeftBrake ??(object) DBNull.Value),
        new SqlParameter("@RearRightBrake", rearRightBrake ??(object) DBNull.Value),
        new SqlParameter("@HandBrakeLeft", handBrakeLeft ??(object) DBNull.Value),
        new SqlParameter("@HandBrakeRight", handBrakeRight ?? (object)DBNull.Value)
    };

            ExecuteQuery(query, parameters);
        }
        public void UpdateNoise(string serialNumber, decimal? noise, decimal? whistle)
        {
            string query = @"
            IF EXISTS (SELECT 1 FROM Noise WHERE SerialNumber = @SerialNumber)
                UPDATE Noise 
                SET Noise = @Noise, 
                    Whistle = @Whistle
                WHERE SerialNumber = @SerialNumber;
            ELSE
                INSERT INTO Noise (SerialNumber, Noise, Whistle)
                VALUES (@SerialNumber, @Noise, @Whistle);";

            var parameters = new[]
            {
        new SqlParameter("@SerialNumber", serialNumber),
        new SqlParameter("@Noise", noise ?? (object)DBNull.Value),
        new SqlParameter("@Whistle", whistle ?? (object)DBNull.Value)
    };

            ExecuteQuery(query, parameters);
        }
        public void UpdateHeadlights(string serialNumber, decimal? leftHBIntensity, decimal? leftHBVertical, decimal? leftHBHorizontal, decimal? leftHBHeight,
            decimal? rightHBIntensity, decimal? rightHBVertical, decimal? rightHBHorizontal, decimal? rightHBHeight,
            decimal? leftLBIntensity, decimal? leftLBVertical, decimal? leftLBHorizontal, decimal? leftLBHeight,
            decimal? rightLBIntensity, decimal? rightLBVertical, decimal? rightLBHorizontal, decimal? rightLBHeight,
            decimal? leftFLIntensity, decimal? leftFLVertical, decimal? leftFLHorizontal, decimal? leftFLHeight,
            decimal? rightFLIntensity, decimal? rightFLVertical, decimal? rightFLHorizontal, decimal? rightFLHeight)
        {
            string query = @"
            IF EXISTS (SELECT 1 FROM Headlights WHERE SerialNumber = @SerialNumber)
                UPDATE Headlights 
                SET LeftHBIntensity = @LeftHBIntensity, 
                    LeftHBVerticalDeviation = @LeftHBVertical, 
                    LeftHBHorizontalDeviation = @LeftHBHorizontal,
                    LeftHBHeight = @LeftHBHeight, 
                    RightHBIntensity = @RightHBIntensity, 
                    RightHBVerticalDeviation = @RightHBVertical, 
                    RightHBHorizontalDeviation = @RightHBHorizontal,
                    RightHBHeight = @RightHBHeight,
                    LeftLBIntensity = @LeftLBIntensity,
                    LeftLBVerticalDeviation = @LeftLBVertical,
                    LeftLBHorizontalDeviation = @LeftLBHorizontal,
                    LeftLBHeight = @LeftLBHeight,
                    RightLBIntensity = @RightLBIntensity,
                    RightLBVerticalDeviation = @RightLBVertical,
                    RightLBHorizontalDeviation = @RightLBHorizontal,
                    RightLBHeight = @RightLBHeight,
                    LeftFLIntensity = @LeftFLIntensity,
                    LeftFLVerticalDeviation = @LeftFLVertical,
                    LeftFLHorizontalDeviation = @LeftFLHorizontal,
                    LeftFLHeight = @LeftFLHeight,
                    RightFLIntensity = @RightFLIntensity,
                    RightFLVerticalDeviation = @RightFLVertical,
                    RightFLHorizontalDeviation = @RightFLHorizontal,
                    RightFLHeight = @RightFLHeight
                WHERE SerialNumber = @SerialNumber;
            ELSE
                INSERT INTO Headlights 
                (SerialNumber, 
                LeftHBIntensity, LeftHBVerticalDeviation, LeftHBHorizontalDeviation, LeftHBHeight, 
                RightHBIntensity, RightHBVerticalDeviation, RightHBHorizontalDeviation, RightHBHeight,
                LeftLBIntensity, LeftLBVerticalDeviation, LeftLBHorizontalDeviation, LeftLBHeight,
                RightLBIntensity, RightLBVerticalDeviation, RightLBHorizontalDeviation, RightLBHeight,
                LeftFLIntensity, LeftFLVerticalDeviation, LeftFLHorizontalDeviation, LeftFLHeight,
                RightFLIntensity, RightFLVerticalDeviation, RightFLHorizontalDeviation, RightFLHeight)
                VALUES 
                (@SerialNumber, 
                @LeftHBIntensity, @LeftHBVertical, @LeftHBHorizontal, @LeftHBHeight,
                @RightHBIntensity, @RightHBVertical, @RightHBHorizontal, @RightHBHeight,
                @LeftLBIntensity, @LeftLBVertical, @LeftLBHorizontal, @LeftLBHeight,
                @RightLBIntensity, @RightLBVertical, @RightLBHorizontal, @RightLBHeight,
                @LeftFLIntensity, @LeftFLVertical, @LeftFLHorizontal, @LeftFLHeight,
                @RightFLIntensity, @RightFLVertical, @RightFLHorizontal, @RightFLHeight);";

            var parameters = new[]
            {
        new SqlParameter("@SerialNumber", serialNumber),

        new SqlParameter("@LeftHBIntensity", leftHBIntensity ?? (object)DBNull.Value),
        new SqlParameter("@LeftHBVertical", leftHBVertical ?? (object)DBNull.Value),
        new SqlParameter("@LeftHBHorizontal", leftHBHorizontal ?? (object)DBNull.Value),
        new SqlParameter("@LeftHBHeight", leftHBHeight ?? (object)DBNull.Value),

        new SqlParameter("@RightHBIntensity", rightHBIntensity ?? (object)DBNull.Value),
        new SqlParameter("@RightHBVertical", rightHBVertical ?? (object)DBNull.Value),
        new SqlParameter("@RightHBHorizontal", rightHBHorizontal ?? (object)DBNull.Value),
        new SqlParameter("@RightHBHeight", rightHBHeight ?? (object)DBNull.Value),

        new SqlParameter("@LeftLBIntensity", leftLBIntensity ?? (object)DBNull.Value),
        new SqlParameter("@LeftLBVertical", leftLBVertical ?? (object)DBNull.Value),
        new SqlParameter("@LeftLBHorizontal", leftLBHorizontal ?? (object)DBNull.Value),
        new SqlParameter("@LeftLBHeight", leftLBHeight ?? (object)DBNull.Value),

        new SqlParameter("@RightLBIntensity", rightLBIntensity ?? (object)DBNull.Value),
        new SqlParameter("@RightLBVertical", rightLBVertical ?? (object)DBNull.Value),
        new SqlParameter("@RightLBHorizontal", rightLBHorizontal ?? (object)DBNull.Value),
        new SqlParameter("@RightLBHeight", rightLBHeight ?? (object)DBNull.Value),

        new SqlParameter("@LeftFLIntensity", leftFLIntensity ?? (object)DBNull.Value),
        new SqlParameter("@LeftFLVertical", leftFLVertical ?? (object)DBNull.Value),
        new SqlParameter("@LeftFLHorizontal", leftFLHorizontal ?? (object)DBNull.Value),
        new SqlParameter("@LeftFLHeight", leftFLHeight ?? (object)DBNull.Value),

        new SqlParameter("@RightFLIntensity", rightFLIntensity ?? (object)DBNull.Value),
        new SqlParameter("@RightFLVertical", rightFLVertical ?? (object)DBNull.Value),
        new SqlParameter("@RightFLHorizontal", rightFLHorizontal ?? (object)DBNull.Value),
        new SqlParameter("@RightFLHeight", rightFLHeight ?? (object)DBNull.Value)
    };

            ExecuteQuery(query, parameters);
        }
        public void UpdateGasEmissionPetrol(string serialNumber, decimal? hc, decimal? co, decimal? co2, decimal? o2, decimal? no, decimal? oilTemp, decimal? rpm, decimal? lambda)
        {
            string query = @"
            IF EXISTS (SELECT 1 FROM GasEmission_Petrol WHERE SerialNumber = @SerialNumber)
                UPDATE GasEmission_Petrol 
                SET HC = @HC, 
                    CO = @CO, 
                    CO2 = @CO2, 
                    O2 = @O2, 
                    NO = @NO, 
                    OilTemp = @OilTemp, 
                    RPM = @RPM,
                    Lambda = @Lambda
                WHERE SerialNumber = @SerialNumber;
            ELSE
                INSERT INTO GasEmission_Petrol (SerialNumber, HC, CO, CO2, O2, NO, OilTemp, RPM, Lambda)
                VALUES (@SerialNumber, @HC, @CO, @CO2, @O2, @NO, @OilTemp, @RPM, @Lambda);";

            var parameters = new[]
            {
        new SqlParameter("@SerialNumber", serialNumber),
        new SqlParameter("@HC", hc ?? (object)DBNull.Value),
        new SqlParameter("@CO", co ?? (object)DBNull.Value),
        new SqlParameter("@CO2", co2 ?? (object)DBNull.Value),
        new SqlParameter("@O2", o2 ?? (object)DBNull.Value),
        new SqlParameter("@NO", no ?? (object)DBNull.Value),
        new SqlParameter("@OilTemp", oilTemp ?? (object)DBNull.Value),
        new SqlParameter("@RPM", rpm ?? (object)DBNull.Value),
        new SqlParameter("@Lambda", lambda ?? (object)DBNull.Value)
    };

            ExecuteQuery(query, parameters);
        }
        public void UpdateGasEmissionDiesel(string serialNumber, decimal? minSpeed1, decimal? maxSpeed1, decimal? hsu1,
            decimal? minSpeed2, decimal? maxSpeed2, decimal? hsu2,
            decimal? minSpeed3, decimal? maxSpeed3, decimal? hsu3)
        {
            string query = @"
            IF EXISTS (SELECT 1 FROM GasEmission_Diesel WHERE SerialNumber = @SerialNumber)
                UPDATE GasEmission_Diesel 
                SET MinSpeed1 = @MinSpeed1, 
                    MaxSpeed1 = @MaxSpeed1, 
                    HSU1 = @HSU1, 
                    MinSpeed2 = @MinSpeed2, 
                    MaxSpeed2 = @MaxSpeed2, 
                    HSU2 = @HSU2, 
                    MinSpeed3 = @MinSpeed3, 
                    MaxSpeed3 = @MaxSpeed3, 
                    HSU3 = @HSU3
                WHERE SerialNumber = @SerialNumber;
            ELSE
                INSERT INTO GasEmission_Diesel (SerialNumber, MinSpeed1, MaxSpeed1, HSU1, MinSpeed2, MaxSpeed2, HSU2, MinSpeed3, MaxSpeed3, HSU3)
                VALUES (@SerialNumber, @MinSpeed1, @MaxSpeed1, @HSU1, @MinSpeed2, @MaxSpeed2, @HSU2, @MinSpeed3, @MaxSpeed3, @HSU3);";

            var parameters = new[]
            {
        new SqlParameter("@SerialNumber", serialNumber),
        new SqlParameter("@MinSpeed1", minSpeed1 ?? (object)DBNull.Value),
        new SqlParameter("@MaxSpeed1", maxSpeed1 ?? (object)DBNull.Value),
        new SqlParameter("@HSU1", hsu1 ?? (object)DBNull.Value),
        new SqlParameter("@MinSpeed2", minSpeed2 ?? (object)DBNull.Value),
        new SqlParameter("@MaxSpeed2", maxSpeed2 ??(object) DBNull.Value),
        new SqlParameter("@HSU2", hsu2 ??(object) DBNull.Value),
        new SqlParameter("@MinSpeed3", minSpeed3 ??(object) DBNull.Value),
        new SqlParameter("@MaxSpeed3", maxSpeed3 ??(object) DBNull.Value),
        new SqlParameter("@HSU3", hsu3 ??(object) DBNull.Value)
    };

            ExecuteQuery(query, parameters);
        }
        public void UpdateSteerAngle(string serialNumber, decimal? leftSteerLW, decimal? leftSteerRW, decimal? rightSteerLW, decimal? rightSteerRW)
        {
            string query = @"
            IF EXISTS (SELECT 1 FROM SteerAngle WHERE SerialNumber = @SerialNumber)
                UPDATE SteerAngle 
                SET LeftSteerLW = @LeftSteerLW, 
                    LeftSteerRW = @LeftSteerRW, 
                    RightSteerLW = @RightSteerLW, 
                    RightSteerRW = @RightSteerRW
                WHERE SerialNumber = @SerialNumber;
            ELSE
                INSERT INTO SteerAngle (SerialNumber, LeftSteerLW, LeftSteerRW, RightSteerLW, RightSteerRW)
                VALUES (@SerialNumber, @LeftSteerLW, @LeftSteerRW, @RightSteerLW, @RightSteerRW);";

            var parameters = new[]
            {
        new SqlParameter("@SerialNumber", serialNumber),
        new SqlParameter("@LeftSteerLW", leftSteerLW ?? (object)DBNull.Value),
        new SqlParameter("@LeftSteerRW", leftSteerRW ?? (object)DBNull.Value),
        new SqlParameter("@RightSteerLW", rightSteerLW ??(object) DBNull.Value),
        new SqlParameter("@RightSteerRW", rightSteerRW ??(object) DBNull.Value)
    };

            ExecuteQuery(query, parameters);
        }
        public string GetPreviousSerialNumber(string currentSerialNumber)
        {
            string query = @"SELECT TOP 1 SerialNumber FROM VehicleInfo 
                     WHERE VehicleID < (SELECT VehicleID FROM VehicleInfo WHERE SerialNumber = @currentSerialNumber)
                     ORDER BY VehicleID DESC";

            var parameters = new[] { new SqlParameter("@currentSerialNumber", currentSerialNumber) };
            DataTable result = TableExecuteQuery(query, parameters);

            return result.Rows.Count > 0 ? result.Rows[0]["SerialNumber"].ToString() : null;
        }
        public string GetNextSerialNumber(string currentSerialNumber)
        {
            string query = @"SELECT TOP 1 SerialNumber FROM VehicleInfo 
                     WHERE VehicleID > (SELECT VehicleID FROM VehicleInfo WHERE SerialNumber = @currentSerialNumber)
                     ORDER BY VehicleID ASC";

            var parameters = new[] { new SqlParameter("@currentSerialNumber", currentSerialNumber) };
            DataTable result = TableExecuteQuery(query, parameters);

            return result.Rows.Count > 0 ? result.Rows[0]["SerialNumber"].ToString() : null;
        }
        public bool CheckValueAgainstStandard(string valueType, decimal value, string serialNumber)
        {
            // Bước 1: Lấy VehicleType dựa trên SerialNumber
            string vehicleTypeQuery = "SELECT VehicleType FROM VehicleInfo WHERE SerialNumber = @SerialNumber";
            var vehicleTypeParams = new[]
            {
                new SqlParameter("@SerialNumber", serialNumber)
            };

            DataTable vehicleTypeResult = TableExecuteQuery(vehicleTypeQuery, vehicleTypeParams);
            if (vehicleTypeResult.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy Tiêu chuẩn cho SerialNumber này.");
                return false;
            }

            string vehicleType = vehicleTypeResult.Rows[0]["VehicleType"].ToString();

            // Bước 2: Lấy tiêu chuẩn từ VehicleStandards dựa trên VehicleType
            string query = "";
            switch (valueType)
            {
                case "Noise":
                    query = "SELECT MaxNoise FROM VehicleStandards WHERE VehicleType = @VehicleType";
                    break;
                case "Whistle":
                    query = "SELECT MinWhistle, MaxWhistle FROM VehicleStandards WHERE VehicleType = @VehicleType";
                    break;
                case "Speed":
                    query = "SELECT MinSpeed, MaxSpeed FROM VehicleStandards WHERE VehicleType = @VehicleType";
                    break;
                case "SideSlip":
                    query = "SELECT MinSideSlip, MaxSideSlip FROM VehicleStandards WHERE VehicleType = @VehicleType";
                    break;
                case "HSU":
                    query = "SELECT MaxHSU FROM VehicleStandards WHERE VehicleType = @VehicleType";
                    break;
                case "DiffFrontBrake":
                    query = "SELECT MaxDiffFrontBrake FROM VehicleStandards WHERE VehicleType = @VehicleType";
                    break;
                case "FrontBrake":
                    query = "SELECT MinFrontBrake FROM VehicleStandards WHERE VehicleType = @VehicleType";
                    break;
                case "DiffHandBrake":
                    query = "SELECT MaxDiffHandBrake FROM VehicleStandards WHERE VehicleType = @VehicleType";
                    break;
                case "HandBrake":
                    query = "SELECT MinHandBrake FROM VehicleStandards WHERE VehicleType = @VehicleType";
                    break;
                case "DiffRearBrake":
                    query = "SELECT MaxDiffRearBrake FROM VehicleStandards WHERE VehicleType = @VehicleType";
                    break;
                case "RearBrake":
                    query = "SELECT MinRearBrake FROM VehicleStandards WHERE VehicleType = @VehicleType";
                    break;
                case "HC":
                    query = "SELECT MaxHC FROM VehicleStandards WHERE VehicleType = @VehicleType";
                    break;
                case "CO":
                    query = "SELECT MaxCO FROM VehicleStandards WHERE VehicleType = @VehicleType";
                    break;
                    // Thêm các loại giá trị khác nếu cần
            }

            var standardParams = new[]
            {
                new SqlParameter("@VehicleType", vehicleType)
            };

            DataTable result = TableExecuteQuery(query, standardParams);
            if (result.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy tiêu chuẩn cho loại xe này.");
                return false;
            }

            // Bước 3: Kiểm tra giá trị so với tiêu chuẩn
            decimal? minValue = result.Rows[0].Field<decimal?>("Min" + valueType);
            decimal? maxValue = result.Rows[0].Field<decimal?>("Max" + valueType);

            if (minValue.HasValue && value < minValue.Value) return false;
            if (maxValue.HasValue && value > maxValue.Value) return false;

            return true; // Nếu giá trị nằm trong tiêu chuẩn
        }
    }
}
