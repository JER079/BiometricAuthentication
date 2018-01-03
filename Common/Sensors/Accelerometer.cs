using BiometricAuthentication.Common.Sensors;

namespace BiometricAuthentication.Common
{
    public class Accelerometer
    {
        private const int ReadingsLength = 50;

        public AccelerometerReadings GetLatestReadings()
        {
            //this will be refined to get template readings instead of fixed values
            var xReadings = new int[ReadingsLength];
            var yReadings = new int[ReadingsLength];
            var zReadings = new int[ReadingsLength];

            for (int i = 0; i < ReadingsLength; i++)
            {
                xReadings[i] = 34;
                yReadings[i] = 26;
                zReadings[i] = 54;
            }

            return new AccelerometerReadings(xReadings, yReadings, zReadings);
        }
    }
}
