namespace BiometricAuthentication.Business.WearableDevice
{
    public class WearableDevice
    {
        private readonly Accelerometer _accelerometer;

        public WearableDevice(Accelerometer accelerometer)
        {
            _accelerometer = accelerometer;
        }

        public AccelerometerReadings GetLatestReadings()
        {
            return _accelerometer.GetLatestReadings();
        }
    }
}
