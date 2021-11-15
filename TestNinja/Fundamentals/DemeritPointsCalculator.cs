using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Fundamentals
{
    public class DemeritPointsCalculator
    {
        private const int SpeedLimit = 65;
        private const int MinSpeed = 0;
        private const int MaxSpeed = 300;

        public int CalculateDemeritPoints(int speed)
        {
            if (speed < MinSpeed || speed > MaxSpeed)
            {
                throw new ArgumentOutOfRangeException("speed", "cannot be below zero");
            }
            if (speed <= SpeedLimit)
            {
                return 0;
            }

            const int kmPerDemeritPoint = 5;
            var demeritPoints = (speed - SpeedLimit) / kmPerDemeritPoint;

            return demeritPoints;
        }
    }
}
