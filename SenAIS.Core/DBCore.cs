using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenAIS.Core
{
    public class DBCore
    {
        public void Test()
        {
            using (var context = new SenAISDBEntities())
            {
                var result = context.BrakeForces
                                    .Where(v => v.SerialNumber == "12345")
                                    .FirstOrDefault();
                result.FrontLeftBrake = 10;
                result.FrontRightBrake = 10;
                context.SaveChanges();
            }
        }
    }
}
