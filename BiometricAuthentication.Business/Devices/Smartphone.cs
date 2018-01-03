using BiometricAuthentication.Business.Encryption;
using BiometricAuthentication.Common.Events;
using BiometricAuthentication.Common.Sensors;
using System;

namespace BiometricAuthentication.Business.Devices
{
    public class Smartphone
    {
        private readonly WearableDeviceStore _wearableDeviceStore;
        private readonly DeviceDiscoveryService _deviceDiscoveryService;

        private readonly Guid _smartphoneId;
        private readonly string _smartphoneName;

        public string LastMessageReceived = string.Empty;

        public Smartphone(DeviceDiscoveryService deviceDiscoveryService)
        {
            _smartphoneId = Guid.NewGuid();
            _smartphoneName = "Jonathan's Phone";

            _wearableDeviceStore = new WearableDeviceStore();
            _deviceDiscoveryService = deviceDiscoveryService;
        } 

        public void SubscribeForEvents(WearableDevice wearableDevice)
        {
            wearableDevice.RaiseStartNewSession += WearableDevice_RaiseStartNewSession;
            wearableDevice.DataTransmitter.TransmitData += DataTransmitter_TransmitData;
        }

        private void DataTransmitter_TransmitData(Common.Events.CommunicationEventArgs communicationEventArgs)
        {
            var deviceWithId = _wearableDeviceStore.Find(communicationEventArgs.GaitReadings);

            if (deviceWithId == null)
            {
                LastMessageReceived = "Device not found";
                return;
            }
            if (!deviceWithId.IsSessionActive())
            {
                LastMessageReceived = "Session not active";
                return;
            }
            
            var decriptionService = new DecryptionService();
            var decryptedMesage = decriptionService.Decrypt(communicationEventArgs.Data, deviceWithId.GetEncryptionKey());

            LastMessageReceived = decryptedMesage;      
        }

        private void WearableDevice_RaiseStartNewSession(GaitReadings gaitReadings, SessionEventArgs sessionEventArgs)
        {
            var createSessionResult = StartNewSession(gaitReadings);
            sessionEventArgs.SessionId = createSessionResult.Session.SessionId;
            sessionEventArgs.EncryptionKey = createSessionResult.EncryptionKey;
        }

        private SessionResult StartNewSession(GaitReadings gaitReadings)
        {
            var deviceEntry = _wearableDeviceStore.Find(gaitReadings);

            if (deviceEntry != null)
            {
                return deviceEntry.CreateNewSessionForDevice(gaitReadings);
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
