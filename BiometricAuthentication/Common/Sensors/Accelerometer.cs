using BiometricAuthentication.Common.Sensors;
using System;

namespace BiometricAuthentication.Common
{
    public class Accelerometer
    {
        //length of 50 numbers
        private const int ReadingsLength = 50;
        private const double MinReading = 0;
        private const double MaxReading = 1;

        private AccelerometerReadings _lastReadings;

        public Accelerometer()
        {

        }

        public AccelerometerReadings GetLatestReadings()
        {
           if (_lastReadings != null) return _lastReadings;

            //array of x, y and z
            var xReadings = new double[ReadingsLength];
            var yReadings = new double[ReadingsLength];
            var zReadings = new double[ReadingsLength];

            // if i is less than 50, loop until 50 arrays are filled
            for (int i = 0; i < ReadingsLength; i++)
            {
                xReadings[i] = RandomNumberBetween(MinReading, MaxReading);
                yReadings[i] = RandomNumberBetween(MinReading, MaxReading);
                zReadings[i] = RandomNumberBetween(MinReading, MaxReading);
            }

            _lastReadings = new AccelerometerReadings(xReadings, yReadings, zReadings);
            Console.WriteLine("X [i] & Y [i] & Z [i] Gait Readings");
            return _lastReadings;
        }

        //https://stackoverflow.com/questions/17786771/random-double-between-given-numbers/17786955
        private double RandomNumberBetween(double minValue, double maxValue)
        {
            var random = new Random(DateTime.Now.Second);
            var next = random.NextDouble();

            return Math.Round(minValue + (next * (maxValue - minValue)), 4);
        }
    }
}
