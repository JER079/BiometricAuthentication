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
        public string Name { get; }

        public string LastMessageReceived = string.Empty;

        public Smartphone(DeviceDiscoveryService deviceDiscoveryService)
        {
            _smartphoneId = Guid.NewGuid();
            Name = "Jeremy's Phone";

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
            //in this step the phone checks the wearableDeviceStore gait readings and compares
            var createSessionResult = StartNewSession(gaitReadings);

            sessionEventArgs.SessionId = createSessionResult.Session.SessionId;
            sessionEventArgs.EncryptionKey = createSessionResult.EncryptionKey;
        }

        private SessionResult StartNewSession(GaitReadings gaitReadings)
        {
            var deviceEntry = _wearableDeviceStore.Find(gaitReadings);

            //in this stage the phone is suppose to recognise the watch
            if (deviceEntry != null)
            {
                //returns gaitReadings to create a new session
                return deviceEntry.CreateNewSessionForDevice(gaitReadings);
            }

            //we do not know this device
            else return null;
        }

        //smartphone sends a broadcast message requesting for any new devices for pairing
        //DeviceDiscoveryService is a class for pairing, which holds info of phone's name & ID as well info of the pairable device, i.e. watch name & ID
        public string DiscoverDevices()
        {
            // var pairingResult will have the variable of the new pairable device, i.e. the watch
            // phone now knows that it will be paired with the watch
            var pairingResult = _deviceDiscoveryService.PairWearableDevice(_smartphoneId, Name);

            //if no reply from any other device, pairing is terminated
            //watch is learnt from the phone, therefore the pairing is succesfull
            if (pairingResult != null)
            {
                //data stored under wearableDeviceStore, device name & ID
                _wearableDeviceStore.AddDevice(pairingResult.WearableDeviceId, pairingResult.WearableDeviceName);
                //returns watch results (name & ID) to Form
                return pairingResult.WearableDeviceName;
            }
            else return "pairing not successful";

        }
    }
}
