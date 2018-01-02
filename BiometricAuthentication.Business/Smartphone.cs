using Common;
using System;

namespace BiometricAuthentication.Business
{
    public class Smartphone
    {
        private readonly WearableDeviceStore _wearableDeviceStore;
        private readonly DeviceDiscoveryService _deviceDiscoveryService;

        private readonly Guid _smartphoneId;
        private readonly string _smartphoneName;

        public Smartphone(DeviceDiscoveryService deviceDiscoveryService)
        {
            _smartphoneId = Guid.NewGuid();
            _smartphoneName = "Jonathan's Phone";

            _wearableDeviceStore = new WearableDeviceStore();
            this._deviceDiscoveryService = deviceDiscoveryService;
        }
   
        public void SubscribeForEvents(WearableDevice wearableDevice)
        {
            wearableDevice.RaiseStartNewSession += WearableDevice_RaiseStartNewSession;

        }

        private void WearableDevice_RaiseStartNewSession(GaitReadings gaitReadings, SessionEventArgs sessionEventArgs)
        {
            var session = StartNewSession(gaitReadings);
            sessionEventArgs.SessionId = session.SessionId;
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

        public string DiscoverDevices()
        {
            var pairingResult = _deviceDiscoveryService.PairWearableDevice(_smartphoneId, _smartphoneName);

            if (pairingResult != null)
            {
                _wearableDeviceStore.AddDevice(pairingResult.WearableDeviceId, pairingResult.WearableDeviceName);
                return pairingResult.WearableDeviceName;
            }
            else return "pairing not successful";

        }
    }
}
