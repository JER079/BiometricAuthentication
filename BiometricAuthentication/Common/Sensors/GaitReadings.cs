namespace BiometricAuthentication.Common.Sensors
{
    public class GaitReadings
    {
        public readonly AccelerometerReadings AccelerometerReadings;

        public GaitReadings(AccelerometerReadings accelerometerReadings)
        {
            AccelerometerReadings = accelerometerReadings;
        }
    }
}
