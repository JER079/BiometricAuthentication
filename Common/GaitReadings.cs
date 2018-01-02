namespace Common
{
    public class GaitReadings
    {
        private readonly AccelerometerReadings _accelerometerReadings;

        public GaitReadings(AccelerometerReadings accelerometerReadings)
        {
            _accelerometerReadings = accelerometerReadings;
        }
    }
}
