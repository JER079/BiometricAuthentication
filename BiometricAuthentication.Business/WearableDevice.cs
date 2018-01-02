using Common;

namespace BiometricAuthentication.Business
{
    public class WearableDevice
    {
        public event SessionHandler RaiseStartNewSession;
        public SessionEventArgs sessionEventArgs;
        public delegate void SessionHandler(GaitReadings gaitReadings, SessionEventArgs sessionEventArgs);

        private readonly Accelerometer _accelerometer;

        public WearableDevice(Accelerometer accelerometer)
        {
            _accelerometer = accelerometer;
        }

        private void StartNewSession()
        {
            var gaitReadings = new GaitReadings(GetLatestReadings());
      
            RaiseStartNewSession(gaitReadings, sessionEventArgs);
        }

        public AccelerometerReadings GetLatestReadings()
        {
            return _accelerometer.GetLatestReadings();
        }
    }
}
