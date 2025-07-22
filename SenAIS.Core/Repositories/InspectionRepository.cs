using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenAIS.Core.Repositories
{
    public class InspectionRepository
    {
        public void SaveSpeedData(string serialNumber, decimal speedValue)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.Speeds.FirstOrDefault(s => s.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.Speed1 = speedValue;
                }
                else
                {
                    var newSpeed = new Speed
                    {
                        SerialNumber = serialNumber,
                        Speed1 = speedValue
                    };
                    db.Speeds.Add(newSpeed);
                }
                db.SaveChanges();
            }
        }

        public void SaveFrontBrakeData(string serialNumber, decimal leftBrake, decimal rightBrake)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.BrakeForces.FirstOrDefault(b => b.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.FrontLeftBrake = leftBrake;
                    existing.FrontRightBrake = rightBrake;
                }
                else
                {
                    var newData = new BrakeForce
                    {
                        SerialNumber = serialNumber,
                        FrontLeftBrake = leftBrake,
                        FrontRightBrake = rightBrake
                    };
                    db.BrakeForces.Add(newData);
                }
                db.SaveChanges();
            }
        }

        public void SaveRearBrakeData(string serialNumber, decimal leftBrake, decimal rightBrake)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.BrakeForces.FirstOrDefault(b => b.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.RearLeftBrake = leftBrake;
                    existing.RearRightBrake = rightBrake;
                }
                else
                {
                    var newData = new BrakeForce
                    {
                        SerialNumber = serialNumber,
                        RearLeftBrake = leftBrake,
                        RearRightBrake = rightBrake
                    };
                    db.BrakeForces.Add(newData);
                }
                db.SaveChanges();
            }
        }

        public void SaveHandBrakeData(string serialNumber, decimal leftBrake, decimal rightBrake)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.BrakeForces.FirstOrDefault(b => b.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.HandBrakeLeft = leftBrake;
                    existing.HandBrakeRight = rightBrake;
                }
                else
                {
                    var newData = new BrakeForce
                    {
                        SerialNumber = serialNumber,
                        HandBrakeLeft = leftBrake,
                        HandBrakeRight = rightBrake
                    };
                    db.BrakeForces.Add(newData);
                }
                db.SaveChanges();
            }
        }

        public void SaveFrontWeightData(string serialNumber, decimal leftWeight, decimal rightWeight)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.Weights.FirstOrDefault(w => w.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.FrontLeftWeight = leftWeight;
                    existing.FrontRightWeight = rightWeight;
                }
                else
                {
                    var newData = new Weight
                    {
                        SerialNumber = serialNumber,
                        FrontLeftWeight = leftWeight,
                        FrontRightWeight = rightWeight
                    };
                    db.Weights.Add(newData);
                }
                db.SaveChanges();
            }
        }

        public void SaveRearWeightData(string serialNumber, decimal leftWeight, decimal rightWeight)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.Weights.FirstOrDefault(w => w.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.RearLeftWeight = leftWeight;
                    existing.RearRightWeight = rightWeight;
                }
                else
                {
                    var newData = new Weight
                    {
                        SerialNumber = serialNumber,
                        RearLeftWeight = leftWeight,
                        RearRightWeight = rightWeight
                    };
                    db.Weights.Add(newData);
                }
                db.SaveChanges();
            }
        }

        public void SaveHeadlightsData(string serialNumber,
            decimal leftHBIntensityValue, decimal leftHBVerticalValue, decimal leftHBHorizontalValue,
            decimal rightHBIntensityValue, decimal rightHBVerticalValue, decimal rightHBHorizontalValue,
            decimal leftLBIntensityValue, decimal leftLBVerticalValue, decimal leftLBHorizontalValue,
            decimal rightLBIntensityValue, decimal rightLBVerticalValue, decimal rightLBHorizontalValue)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.Headlights.FirstOrDefault(h => h.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.LeftHBIntensity = leftHBIntensityValue;
                    existing.LeftHBVerticalDeviation = leftHBVerticalValue;
                    existing.LeftHBHorizontalDeviation = leftHBHorizontalValue;
                    existing.RightHBIntensity = rightHBIntensityValue;
                    existing.RightHBVerticalDeviation = rightHBVerticalValue;
                    existing.RightHBHorizontalDeviation = rightHBHorizontalValue;
                    existing.LeftLBIntensity = leftLBIntensityValue;
                    existing.LeftLBVerticalDeviation = leftLBVerticalValue;
                    existing.LeftLBHorizontalDeviation = leftLBHorizontalValue;
                    existing.RightLBIntensity = rightLBIntensityValue;
                    existing.RightLBVerticalDeviation = rightLBVerticalValue;
                    existing.RightLBHorizontalDeviation = rightLBHorizontalValue;
                }
                else
                {
                    var newData = new Headlight
                    {
                        SerialNumber = serialNumber,
                        LeftHBIntensity = leftHBIntensityValue,
                        LeftHBVerticalDeviation = leftHBVerticalValue,
                        LeftHBHorizontalDeviation = leftHBHorizontalValue,
                        RightHBIntensity = rightHBIntensityValue,
                        RightHBVerticalDeviation = rightHBVerticalValue,
                        RightHBHorizontalDeviation = rightHBHorizontalValue,
                        LeftLBIntensity = leftLBIntensityValue,
                        LeftLBVerticalDeviation = leftLBVerticalValue,
                        LeftLBHorizontalDeviation = leftLBHorizontalValue,
                        RightLBIntensity = rightLBIntensityValue,
                        RightLBVerticalDeviation = rightLBVerticalValue,
                        RightLBHorizontalDeviation = rightLBHorizontalValue
                    };
                    db.Headlights.Add(newData);
                }
                db.SaveChanges();
            }
        }

        public void SaveGasEmissionPetrol(string serialNumber, decimal hc, decimal co, decimal co2, decimal o2, decimal no, decimal oilTemp, decimal rpm)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.GasEmission_Petrol.FirstOrDefault(g => g.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.HC = hc;
                    existing.CO = co;
                    existing.CO2 = co2;
                    existing.O2 = o2;
                    existing.NO = no;
                    existing.OilTemp = oilTemp;
                    existing.RPM = (int?)rpm;
                }
                else
                {
                    var newData = new GasEmission_Petrol
                    {
                        SerialNumber = serialNumber,
                        HC = hc,
                        CO = co,
                        CO2 = co2,
                        O2 = o2,
                        NO = no,
                        OilTemp = oilTemp,
                        RPM = (int?)rpm
                    };
                    db.GasEmission_Petrol.Add(newData);
                }
                db.SaveChanges();
            }
        }

        public void SaveGasEmissionDiesel(string serialNumber,
            decimal minSpeed1, decimal maxSpeed1, decimal hsu1,
            decimal minSpeed2, decimal maxSpeed2, decimal hsu2,
            decimal minSpeed3, decimal maxSpeed3, decimal hsu3)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.GasEmission_Diesel.FirstOrDefault(g => g.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.MinSpeed1 = minSpeed1;
                    existing.MaxSpeed1 = maxSpeed1;
                    existing.HSU1 = hsu1;
                    existing.MinSpeed2 = minSpeed2;
                    existing.MaxSpeed2 = maxSpeed2;
                    existing.HSU2 = hsu2;
                    existing.MinSpeed3 = minSpeed3;
                    existing.MaxSpeed3 = maxSpeed3;
                    existing.HSU3 = hsu3;
                }
                else
                {
                    var newData = new GasEmission_Diesel
                    {
                        SerialNumber = serialNumber,
                        MinSpeed1 = minSpeed1,
                        MaxSpeed1 = maxSpeed1,
                        HSU1 = hsu1,
                        MinSpeed2 = minSpeed2,
                        MaxSpeed2 = maxSpeed2,
                        HSU2 = hsu2,
                        MinSpeed3 = minSpeed3,
                        MaxSpeed3 = maxSpeed3,
                        HSU3 = hsu3
                    };
                    db.GasEmission_Diesel.Add(newData);
                }
                db.SaveChanges();
            }
        }
        public void SaveNoiseData(string serialNumber, decimal noiseValue)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.Noises.FirstOrDefault(n => n.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.Noise1 = noiseValue;
                }
                else
                {
                    var newData = new Noise
                    {
                        SerialNumber = serialNumber,
                        Noise1 = noiseValue
                    };
                    db.Noises.Add(newData);
                }
                db.SaveChanges();
            }
        }

        public void SaveWhistleData(string serialNumber, decimal whistle)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.Noises.FirstOrDefault(n => n.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.Whistle = whistle;
                }
                else
                {
                    var newData = new Noise
                    {
                        SerialNumber = serialNumber,
                        Whistle = whistle
                    };
                    db.Noises.Add(newData);
                }
                db.SaveChanges();
            }
        }

        public void SaveSideSlipData(string serialNumber, decimal sideSlip)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.SideSlips.FirstOrDefault(s => s.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.SideSlip1 = sideSlip;
                }
                else
                {
                    var newData = new SideSlip
                    {
                        SerialNumber = serialNumber,
                        SideSlip1 = sideSlip
                    };
                    db.SideSlips.Add(newData);
                }
                db.SaveChanges();
            }
        }

        public void SaveSteerAngleData(string serialNumber, decimal leftSteerLW, decimal rightSteerLW, decimal leftSteerRW, decimal rightSteerRW)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.SteerAngles.FirstOrDefault(s => s.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.LeftSteerLW = leftSteerLW;
                    existing.RightSteerLW = rightSteerLW;
                    existing.LeftSteerRW = leftSteerRW;
                    existing.RightSteerRW = rightSteerRW;
                }
                else
                {
                    var newData = new SteerAngle
                    {
                        SerialNumber = serialNumber,
                        LeftSteerLW = leftSteerLW,
                        RightSteerLW = rightSteerLW,
                        LeftSteerRW = leftSteerRW,
                        RightSteerRW = rightSteerRW
                    };
                    db.SteerAngles.Add(newData);
                }
                db.SaveChanges();
            }
        }
        // Cập nhật giá trị tại bảng thống kê
        public void UpdateSpeed(string serialNumber, decimal? speed)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.Speeds.FirstOrDefault(s => s.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.Speed1 = speed;
                }
                else
                {
                    db.Speeds.Add(new Speed { SerialNumber = serialNumber, Speed1 = speed });
                }
                db.SaveChanges();
            }
        }

        public void UpdateSideSlip(string serialNumber, decimal? sideSlip)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.SideSlips.FirstOrDefault(s => s.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.SideSlip1 = sideSlip;
                }
                else
                {
                    db.SideSlips.Add(new SideSlip { SerialNumber = serialNumber, SideSlip1 = sideSlip });
                }
                db.SaveChanges();
            }
        }

        public void UpdateWeight(string serialNumber, decimal? frontLeftWeight, decimal? frontRightWeight, decimal? rearLeftWeight, decimal? rearRightWeight)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.Weights.FirstOrDefault(w => w.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.FrontLeftWeight = frontLeftWeight;
                    existing.FrontRightWeight = frontRightWeight;
                    existing.RearLeftWeight = rearLeftWeight;
                    existing.RearRightWeight = rearRightWeight;
                }
                else
                {
                    db.Weights.Add(new Weight
                    {
                        SerialNumber = serialNumber,
                        FrontLeftWeight = frontLeftWeight,
                        FrontRightWeight = frontRightWeight,
                        RearLeftWeight = rearLeftWeight,
                        RearRightWeight = rearRightWeight
                    });
                }
                db.SaveChanges();
            }
        }

        public void UpdateBrakeForce(string serialNumber, decimal? frontLeftBrake, decimal? frontRightBrake, decimal? rearLeftBrake, decimal? rearRightBrake, decimal? handBrakeLeft, decimal? handBrakeRight)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.BrakeForces.FirstOrDefault(b => b.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.FrontLeftBrake = frontLeftBrake;
                    existing.FrontRightBrake = frontRightBrake;
                    existing.RearLeftBrake = rearLeftBrake;
                    existing.RearRightBrake = rearRightBrake;
                    existing.HandBrakeLeft = handBrakeLeft;
                    existing.HandBrakeRight = handBrakeRight;
                }
                else
                {
                    db.BrakeForces.Add(new BrakeForce
                    {
                        SerialNumber = serialNumber,
                        FrontLeftBrake = frontLeftBrake,
                        FrontRightBrake = frontRightBrake,
                        RearLeftBrake = rearLeftBrake,
                        RearRightBrake = rearRightBrake,
                        HandBrakeLeft = handBrakeLeft,
                        HandBrakeRight = handBrakeRight
                    });
                }
                db.SaveChanges();
            }
        }

        public void UpdateNoise(string serialNumber, decimal? noise, decimal? whistle)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.Noises.FirstOrDefault(n => n.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.Noise1 = noise;
                    existing.Whistle = whistle;
                }
                else
                {
                    db.Noises.Add(new Noise { SerialNumber = serialNumber, Noise1 = noise, Whistle = whistle });
                }
                db.SaveChanges();
            }
        }

        public void UpdateHeadlights(string serialNumber, decimal? leftHBIntensity, decimal? leftHBVertical, decimal? leftHBHorizontal,
            decimal? rightHBIntensity, decimal? rightHBVertical, decimal? rightHBHorizontal,
            decimal? leftLBIntensity, decimal? leftLBVertical, decimal? leftLBHorizontal,
            decimal? rightLBIntensity, decimal? rightLBVertical, decimal? rightLBHorizontal)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.Headlights.FirstOrDefault(h => h.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.LeftHBIntensity = leftHBIntensity;
                    existing.LeftHBVerticalDeviation = leftHBVertical;
                    existing.LeftHBHorizontalDeviation = leftHBHorizontal;
                    existing.RightHBIntensity = rightHBIntensity;
                    existing.RightHBVerticalDeviation = rightHBVertical;
                    existing.RightHBHorizontalDeviation = rightHBHorizontal;
                    existing.LeftLBIntensity = leftLBIntensity;
                    existing.LeftLBVerticalDeviation = leftLBVertical;
                    existing.LeftLBHorizontalDeviation = leftLBHorizontal;
                    existing.RightLBIntensity = rightLBIntensity;
                    existing.RightLBVerticalDeviation = rightLBVertical;
                    existing.RightLBHorizontalDeviation = rightLBHorizontal;
                }
                else
                {
                    db.Headlights.Add(new Headlight
                    {
                        SerialNumber = serialNumber,
                        LeftHBIntensity = leftHBIntensity,
                        LeftHBVerticalDeviation = leftHBVertical,
                        LeftHBHorizontalDeviation = leftHBHorizontal,
                        RightHBIntensity = rightHBIntensity,
                        RightHBVerticalDeviation = rightHBVertical,
                        RightHBHorizontalDeviation = rightHBHorizontal,
                        LeftLBIntensity = leftLBIntensity,
                        LeftLBVerticalDeviation = leftLBVertical,
                        LeftLBHorizontalDeviation = leftLBHorizontal,
                        RightLBIntensity = rightLBIntensity,
                        RightLBVerticalDeviation = rightLBVertical,
                        RightLBHorizontalDeviation = rightLBHorizontal
                    });
                }
                db.SaveChanges();
            }
        }

        public void UpdateGasEmissionPetrol(string serialNumber, decimal? hc, decimal? co, decimal? co2, decimal? o2, decimal? no, decimal? oilTemp, decimal? rpm)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.GasEmission_Petrol.FirstOrDefault(g => g.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.HC = hc;
                    existing.CO = co;
                    existing.CO2 = co2;
                    existing.O2 = o2;
                    existing.NO = no;
                    existing.OilTemp = oilTemp;
                    existing.RPM = (int?)rpm;
                }
                else
                {
                    db.GasEmission_Petrol.Add(new GasEmission_Petrol
                    {
                        SerialNumber = serialNumber,
                        HC = hc,
                        CO = co,
                        CO2 = co2,
                        O2 = o2,
                        NO = no,
                        OilTemp = oilTemp,
                        RPM = (int?)rpm
                    });
                }
                db.SaveChanges();
            }
        }

        public void UpdateGasEmissionDiesel(string serialNumber, decimal? minSpeed1, decimal? maxSpeed1, decimal? hsu1,
            decimal? minSpeed2, decimal? maxSpeed2, decimal? hsu2,
            decimal? minSpeed3, decimal? maxSpeed3, decimal? hsu3)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.GasEmission_Diesel.FirstOrDefault(g => g.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.MinSpeed1 = minSpeed1;
                    existing.MaxSpeed1 = maxSpeed1;
                    existing.HSU1 = hsu1;
                    existing.MinSpeed2 = minSpeed2;
                    existing.MaxSpeed2 = maxSpeed2;
                    existing.HSU2 = hsu2;
                    existing.MinSpeed3 = minSpeed3;
                    existing.MaxSpeed3 = maxSpeed3;
                    existing.HSU3 = hsu3;
                }
                else
                {
                    db.GasEmission_Diesel.Add(new GasEmission_Diesel
                    {
                        SerialNumber = serialNumber,
                        MinSpeed1 = minSpeed1,
                        MaxSpeed1 = maxSpeed1,
                        HSU1 = hsu1,
                        MinSpeed2 = minSpeed2,
                        MaxSpeed2 = maxSpeed2,
                        HSU2 = hsu2,
                        MinSpeed3 = minSpeed3,
                        MaxSpeed3 = maxSpeed3,
                        HSU3 = hsu3
                    });
                }
                db.SaveChanges();
            }
        }
        
        public void UpdateSteerAngle(string serialNumber, decimal? leftSteerLW, decimal? leftSteerRW, decimal? rightSteerLW, decimal? rightSteerRW)
        {
            using (var db = new SenAISDB_HDEntities())
            {
                var existing = db.SteerAngles.FirstOrDefault(s => s.SerialNumber == serialNumber);
                if (existing != null)
                {
                    existing.LeftSteerLW = leftSteerLW;
                    existing.LeftSteerRW = leftSteerRW;
                    existing.RightSteerLW = rightSteerLW;
                    existing.RightSteerRW = rightSteerRW;
                }
                else
                {
                    db.SteerAngles.Add(new SteerAngle
                    {
                        SerialNumber = serialNumber,
                        LeftSteerLW = leftSteerLW,
                        LeftSteerRW = leftSteerRW,
                        RightSteerLW = rightSteerLW,
                        RightSteerRW = rightSteerRW
                    });
                }
                db.SaveChanges();
            }
        }
    }
}
