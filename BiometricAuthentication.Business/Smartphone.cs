using Common;

namespace BiometricAuthentication.Business
{
    public class Smartphone
    {
        

        private WearableDeviceStore _wearableDeviceStore;

        public void ListenNewSession(GaitReadings gaitReadings, SessionEventArgs sessionEventArgs)
        {

        }

        public void SubscribeForEvents(WearableDevice wearableDevice)
        {
            wearableDevice.RaiseStartNewSession += WearableDevice_RaiseStartNewSession;

        }

        private void WearableDevice_RaiseStartNewSession(GaitReadings gaitReadings, SessionEventArgs sessionEventArgs)
        {
            throw new System.NotImplementedException();
        }

        private Session StartNewSession(GaitReadings gaitReadings)
        {
            var deviceEntry = _wearableDeviceStore.Find(gaitReadings);

            if (deviceEntry != null)
            {
                return deviceEntry.CreateNewSessionForDevice();
            }

            //we do not know this device
            else return null;
        }
    }
}
